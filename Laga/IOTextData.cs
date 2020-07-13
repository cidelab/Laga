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

        private string GetEncodingString(EncodingType encoding)
        {
            switch (encoding)
            {
                case EncodingType.UTF7:
                    return "_UTF7";
                case EncodingType.UTF8:
                    return "_UTF8";
                case EncodingType.ASCII:
                    return "_ASCII";
                case EncodingType.Unicode:
                    return "_Unicode";
                default:
                    return "_Default";
            }
        }
        private Encoding GetEncoding(EncodingType encoding)
        {
            switch (encoding)
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
        private Encoding GetSourceEncoding(string fileName)
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

        /// <summary>
        /// Construct the class to operate txt files.
        /// </summary>
        /// <param name="TextFileName">The text file name</param>
        public IOTextData(string TextFileName)
        {
            textFileName = TextFileName;
            streamReader = new StreamReader(TextFileName);
            sourceEncoding = GetSourceEncoding(textFileName);
        }

        /// <summary>
        /// Convert a file from one Encoding type to another encoding type
        /// </summary>
        /// <param name="FileName">the full file name to convert</param>
        /// <param name="encodingType">the Encoding type</param>
        public string ConvertFileEncoding(string FileName, EncodingType encodingType)
        {
            Encoding destEncoding = GetEncoding(encodingType);
            string strEncode = GetEncodingString(encodingType);

            string directory = Path.GetDirectoryName(FileName);
            string fileName = Path.GetFileNameWithoutExtension(FileName);
            string PathFolder = Path.Combine(new string[] { directory, "Rep" + strEncode ,fileName + strEncode + ".txt" });
            string nPathFolder = Path.GetDirectoryName(PathFolder);

            // If the destination's parent doesn't exist, create it.
            string parent = Path.GetDirectoryName(Path.GetFullPath(PathFolder));
            if (!Directory.Exists(parent))
            {
                Directory.CreateDirectory(parent);
            }

            // If the source and destination encodings are the same, just copy the file.
            if (sourceEncoding == destEncoding)
            {
                File.Copy(FileName, PathFolder, true);
                return nPathFolder;
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
                File.Move(tempName, PathFolder);
            }
            finally
            {
                File.Delete(tempName);
            }

            return nPathFolder;
        }

        /// <summary>
        /// Creates a text file based on a list of strings
        /// </summary>
        /// <param name="strList">the content for the file</param>
        /// <param name="directory">the path to the directory to save the file</param>
        /// <param name="fileName">name of the txt file</param>
        /// <returns>bool</returns>
        public static bool CreateFile(List<string> strList, string directory, string fileName)
        {
            bool b = false;
            string PathFolder = Path.Combine(new string[] { directory, fileName + ".txt" });

            using (StreamWriter sw = File.CreateText(PathFolder))
            {
                foreach (string s in strList)
                    sw.WriteLine(s);

                b = true;
            }

            return b;
        }

        /// <summary>
        /// Return the n most frequently occuring words in the string
        /// </summary>      
        /// <param name="strMessage">the string</param>
        /// <param name="topN">Top N Numbers to return</param>
        /// <returns>Dictionary</returns>
        public static Dictionary<string, int> CountWordsTopN(string strMessage, int topN)
        {
            string[] arrWords = GetWords(strMessage);
            Dictionary<string, int> dicCountWords = new Dictionary<string, int>();

            foreach(string s in arrWords)
            {
                if(dicCountWords.ContainsKey(s))
                {
                    dicCountWords[s] += 1;
                }
                else
                {
                    dicCountWords[s] = 1;
                }
            }

            //sort the occurrencies in descending order
            var items = from pair in dicCountWords
                        orderby pair.Key ascending
                        select pair;

            Dictionary<string, int> sortDic = new Dictionary<string, int>(dicCountWords.Count);
            
            foreach (KeyValuePair<string, int> pair in items)
                sortDic.Add(pair.Key, pair.Value);

            var topItemsCount = sortDic.OrderByDescending(entry => entry.Value)
                                .Take(topN)
                                .ToDictionary(pair => pair.Key, pair => pair.Value);

            return topItemsCount;
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
        /// Remove the digits from a string
        /// </summary>
        /// <param name="strMessage">The string to remove the digits</param>
        /// <returns>string</returns>
        public static string RemoveNumbers(string strMessage)
        {
            return new String(strMessage.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());
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

        /// <summary>
        /// Remove strings according to a specific Length
        /// </summary>
        /// <param name="strMessages">the Array of strings to make the operations</param>
        /// <param name="Length">The minimum string length</param>
        /// <returns>string[]</returns>
        public static string[] RemoveByLength(string[] strMessages, int Length)
        {
            List<string> lstStrMessage = new List<string>();
            
            foreach(string str in strMessages)
            {
                if(str.Length > Length)
                {
                    lstStrMessage.Add(str);
                }
            }
            return lstStrMessage.ToArray();
        }

        /// <summary>
        /// Remove the words according to a specific length from a string
        /// </summary>
        /// <param name="strMessage">The string to make the operation</param>
        /// <param name="Length">The minimum word length in the string</param>
        /// <param name="separator">A string to specify how combine the new string chain. eg: " "</param>
        /// <returns>string</returns>
        public static string RemoveByLength(string strMessage, int Length, string separator)
        {
            string[] strMessages = GetWords(strMessage);
            List<string> lstStr = new List<string>();

            foreach (string str in strMessages)
            {
                if (str.Length > Length)
                {
                    lstStr.Add(str);
                }
            }
            return string.Join(separator, lstStr);
        }

    }
}
