using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace Laga.IO
{
    /// <summary>
    /// Read and process text from a txt file
    /// </summary>
    public class IOTextData
    {
        private string textFileName;
        private List<string> dataTextLine = new List<string>();
        private string dataText = "";
        private Encoding sourceEncoding;
        private StreamReader streamReader;

        /// <summary>
        /// Get the Encoding Source from the Text File
        /// </summary>
        public Encoding SourceEncoding
        {
            get { return sourceEncoding; }
        }

        /// <summary>
        /// Get the Data Text as a string
        /// </summary>
        public string DataText
        {
            get
            {
                dataText = streamReader.ReadToEnd();
                return dataText;
            }
        }

        /// <summary>
        /// Get the Data Text as a list of strings
        /// </summary>
        public List<string> DataTextLine
        {
            get
            {
                while (streamReader.Peek() > 0)
                {
                    dataTextLine.Add(streamReader.ReadLine());
                }
                return dataTextLine;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TextFileName"></param>
        /// <param name="encoding"></param>
        public IOTextData(string TextFileName)
        {
            textFileName = TextFileName;
            streamReader = new StreamReader(TextFileName);
            sourceEncoding = GetEncoding(textFileName);
        }

        private Encoding GetEncoding(string fileName)
        {
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="PathToFolder"></param>
        /// <param name="sourceEncoding"></param>
        /// <param name="destEncoding"></param>
        public static void ConvertFileEncoding(string FileName, string PathToFolder,
                                                 Encoding sourceEncoding, Encoding destEncoding)
        {
            // If the destination's parent doesn't exist, create it.
            String parent = Path.GetDirectoryName(Path.GetFullPath(PathToFolder));
            if (!Directory.Exists(parent))
            {
                Directory.CreateDirectory(parent);
            }

            // If the source and destination encodings are the same, just copy the file.
            if (sourceEncoding == destEncoding)
            {
                File.Copy(FileName, PathToFolder, true);
                return;
            }

            // Convert the file.
            String tempName = null;
            try
            {
                tempName = Path.GetTempFileName();
                using (StreamReader sr = new StreamReader(FileName, sourceEncoding, false))
                {
                    using (StreamWriter sw = new StreamWriter(tempName, false, destEncoding))
                    {
                        int charsRead;
                        char[] buffer = new char[128 * 1024];
                        while ((charsRead = sr.ReadBlock(buffer, 0, buffer.Length)) > 0)
                        {
                            sw.Write(buffer, 0, charsRead);
                        }
                    }
                }
                //File.Delete(destPath);
                File.Move(tempName, PathToFolder);
            }
            finally
            {
                File.Delete(tempName);
            }
        }

        /// <summary>
        /// Encoding types Supported
        /// </summary>
        public enum EncodingType
        {
            /// <summary>
            /// UTF7 Encoding
            /// </summary>
            UTF7,
            /// <summary>
            /// UTF8 Encoding
            /// </summary>
            UTF8,
            /// <summary>
            /// ASCII Encoding
            /// </summary>
            ASCII,
            /// <summary>
            /// Unicode Encoding
            /// </summary>
            Unicode,
            /// <summary>
            /// Default Encoding
            /// </summary>
            Default
        }
        
        private Encoding GetEncoding(EncodingType encoding)
        {
            switch(encoding)
            {
                case EncodingType.UTF7:
                    return Encoding.UTF7;
                case EncodingType.UTF8:
                    return Encoding.UTF8;
                case EncodingType.ASCII:
                    return Encoding.ASCII;
                case EncodingType.Unicode:
                    return Encoding.Unicode;
                default:
                    return Encoding.Default;
            }
        }

        /// <summary>
        /// Get The words from a string
        /// </summary>
        /// <param name="strMessage">The string to operate</param>
        /// <returns>string[]</returns>
        public static string[] GetWords(string strMessage)
        {
            var punctuation = strMessage.Where(Char.IsPunctuation).Distinct().ToArray();
            return strMessage.Split().Select(x => x.Trim(punctuation)).ToArray();
        }

        /// <summary>
        /// Remove Diacritcs from string
        /// </summary>
        /// <param name="strMessage">The string to clean</param>
        /// <returns>string</returns>
        public static string RemoveDiacritics(string strMessage)
        {
                string normalizedString = strMessage.Normalize(NormalizationForm.FormD);
                var stringBuilder = new StringBuilder();

                foreach (char c in normalizedString)
                {
                    var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                    if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    {
                        stringBuilder.Append(c);
                    }
                }

                return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
