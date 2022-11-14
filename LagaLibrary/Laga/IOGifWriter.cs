using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Laga.IO
{
    /// <summary>
    /// Gif image creation class
    /// from The webpage: 
    /// </summary>
    public class IOGifWriter : IDisposable
    {
        #region fields
        const long SourceGlobalColorInfoPosition = 10,
        SourceImageBlockPosition = 789;

        readonly BinaryWriter _writer;
        bool _firstFrame = true;

        readonly object _syncLock = new object();

        #endregion

        /// <summary>
        /// Creates a new instance of GifWriter.
        /// </summary>
        /// <param name="OutStream">The <see cref="Stream"/> to output the Gif to.</param>
        /// <param name="DefaultFrameDelay">Default Delay between consecutive frames... FrameRate = 1000 / DefaultFrameDelay.</param>
        /// <param name="Repeat">No of times the Gif should repeat... -1 not to repeat, 0 to repeat indefinitely.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IOGifWriter(Stream OutStream, int DefaultFrameDelay = 500, int Repeat = -1)
        {
            if (OutStream == null)
                throw new ArgumentNullException(nameof(OutStream));

            if (DefaultFrameDelay <= 0)
                throw new ArgumentOutOfRangeException(nameof(DefaultFrameDelay));

            if (Repeat < -1)
                throw new ArgumentOutOfRangeException(nameof(Repeat));

            _writer = new BinaryWriter(OutStream);
            this.DefaultFrameDelay = DefaultFrameDelay;
            this.Repeat = Repeat;
        }

        /// <summary>
        /// Create a new instance of the writer
        /// </summary>
        /// <param name="FileName">The path to the file to output the gif to.</param>
        /// <param name="DefaultFrameDelay">Default delay between consecutive frames... FrameRate = 1000 / DefaultFrameDelay</param>
        /// <param name="Repeat">No of times the gif should repeat -1 not to repeat, 0 to repeat indefinetely.</param>
        public IOGifWriter(string FileName, int DefaultFrameDelay = 500, int Repeat = -1)
            : this(new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read), DefaultFrameDelay, Repeat) { }

        #region Properties
        /// <summary>
        /// Gets or Sets the Default Width of a Frame. Used when unspecified.
        /// </summary>
        public int DefaultWidth {get; set;}
        
        /// <summary>
        /// Get or set default height of a frame. Used when unspecified
        /// </summary>
        public int DefaultHeight {get; set;}

        /// <summary>
        /// Get or set the default delay in milliseconds
        /// </summary>
        public int DefaultFrameDelay { get; set;}

        /// <summary>
        /// The number of times the animation repeat
        /// -1 indicate no repeat. 0 indificate indefinitely.
        /// </summary>
        public int Repeat { get;  }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="Delay"></param>
        public void WriteFrame(Image image, int Delay = 0)
        {
            lock(_syncLock)
                using(var gifStream = new MemoryStream())
                {
                    image.Save(gifStream, ImageFormat.Gif);
                    // steal the global color table info.
                    if (_firstFrame)
                        InitHeader(gifStream, _writer, image.Width, image.Height);

                    WriteGraphicControlBlock(gifStream, _writer, Delay == 0 ? DefaultFrameDelay : Delay);
                    WriteImageBlock(gifStream, _writer, !_firstFrame, 0, 0, image.Width, image.Height);
                }
            if(_firstFrame)
                _firstFrame = false;
        }

        void InitHeader(Stream sourceGif, BinaryWriter writer, int width, int height)
        {
            //File header
            writer.Write("GIF".ToCharArray()); // file type
            writer.Write("89a".ToCharArray()); // file version

            writer.Write((short)(DefaultWidth == 0 ? width : DefaultWidth)); //Initial Logical Width
            writer.Write((short)(DefaultHeight == 0 ? height : DefaultHeight));//Initial logical height

            sourceGif.Position = SourceGlobalColorInfoPosition;
            
            writer.Write((byte)sourceGif.ReadByte()); //Global Color table Info
            writer.Write((byte)0); //Background Color Index
            writer.Write((byte)0); //Pixel aspect ratio
            WriteColortable(sourceGif, writer);

            //App Extension Header for repeating
            if (Repeat == -1)
                return;

            writer.Write(unchecked((short)0xff21)); // aplication extension block identifier
            writer.Write((byte)0x0b); // application block size
            writer.Write("NETSCAPE2.0".ToCharArray()); //application identifier
            writer.Write((byte)3); //application block length
            writer.Write((byte)1);
            writer.Write((short)Repeat); // Repeat count for images.
            writer.Write((byte)0); //terminator

        }

        static void WriteColortable(Stream sourceGif, BinaryWriter writer)
        {
            sourceGif.Position = 13; //locating the image color table
            var colorTable = new byte[768];
            sourceGif.Read(colorTable, 0, colorTable.Length);
            writer.Write(colorTable, 0, colorTable.Length);
        }

        static void WriteGraphicControlBlock(Stream sourceGif, BinaryWriter writer, int FrameDelay)
        {
            sourceGif.Position = 781; //locating the source GCE
            var blockhead = new byte[8];
            sourceGif.Read(blockhead, 0, blockhead.Length); //reading source GCE

            writer.Write(unchecked((short)0xf921)); // identifier
            writer.Write((byte)0x04); //blocksize
            writer.Write((byte)(blockhead[3] & 0xf7 | 0x08)); //setting disposal flag
            writer.Write((short)(FrameDelay / 10)); //setting frame delay
            writer.Write(blockhead[6]); //transparent color index
            writer.Write((byte)0); //terminator
        }
        
        static void WriteImageBlock(Stream sourceGif, BinaryWriter writer, bool IncludeColorTable, int X, int Y, int width, int height)
        {
            sourceGif.Position = SourceImageBlockPosition; //Locating the image block
            var header = new byte[11];
            sourceGif.Read(header, 0, header.Length);
            writer.Write(header[0]); //separator
            writer.Write((short)X); //position X
            writer.Write((short)Y); //position Y
            writer.Write((short)width); //Width
            writer.Write((short)height); //height

            if(IncludeColorTable) //if first frame, use global color table - else use local
            {
                sourceGif.Position = SourceGlobalColorInfoPosition;
                writer.Write((byte) (sourceGif.ReadByte() & 0x3f | 0x80)); //enabling local color table 
               WriteColortable(sourceGif, writer);
            }
            else
            {
                writer.Write((byte)(header[9] & 0x07 | 0x07)); //disabling local color table
            }
            writer.Write(header[10]); //LZW min code size

            //read/ write image data
            sourceGif.Position = SourceImageBlockPosition + header.Length;
            var dataLength = sourceGif.ReadByte();
            while(dataLength>0)
            {
                var imgData = new byte[dataLength];
                sourceGif.Read(imgData, 0, dataLength);

                writer.Write((byte)dataLength);
                writer.Write(imgData, 0, dataLength);
                dataLength = sourceGif.ReadByte();
            }
            writer.Write((byte)0); //terminator

        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _writer.Write((byte)0x3b); //file trailer
            _writer.BaseStream.Dispose();
            _writer.Dispose();
        }
    }
}
