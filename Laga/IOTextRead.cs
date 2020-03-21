using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laga.IO
{
    /// <summary>
    /// Read and process text from a txt file
    /// </summary>
    public class IOTextRead
    {
        private string textFileName;

        /// <summary>
        /// Get the text by lines
        /// </summary>
        public string[] DataTextLines
        {
            get
            {
                return File.ReadAllLines(textFileName);
            }
        }

        /// <summary>
        /// Get the text from the File
        /// </summary>
        public string DataText
        {
            get
            {
                return File.ReadAllText(textFileName);
            }
        }

        /// <summary>
        /// Build the Class Text Read
        /// </summary>
        /// <param name="TextFileName">The File Path</param>
        public IOTextRead(string TextFileName)
        {
            textFileName = TextFileName;
        }
    }
}
