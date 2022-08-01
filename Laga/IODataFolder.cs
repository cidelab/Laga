using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laga.GeneticAlgorithm;

namespace Laga.IO
{ 
    /// <summary>
    /// Get Data files information from a folder directory
    /// </summary>
    public class IODataFolder
    {
        private string pathFolder = "";
        private readonly string[] lstPathFileNames;
        private string[] lstFileNames;

        /// <summary>
        /// The Roof folder with the files
        /// </summary>
        public string RootFolder
        {
            get
            {
                if (pathFolder != "")
                {
                    return pathFolder;
                }
                else
                {
                    return "!=";
                }
            }
            set 
            {
                pathFolder = value; 
            }
        }

        /// <summary>
        /// The List of file names including the path
        /// </summary>
        public string[] ListPathFileNames
        {
            get
            {
                return lstPathFileNames;
            }
        }

        /// <summary>
        /// The list of file names without extension
        /// </summary>
        public string[] ListFileNames
        {
            get
            {
                return lstFileNames;
            }
        }

        /// <summary>
        /// The Object to extract data from the folder
        /// </summary>
        /// <param name="PathFolder">The folders path to analize</param>
        public IODataFolder(string PathFolder)
        {
            pathFolder = PathFolder;
            if (Directory.Exists(pathFolder))
            {
                lstPathFileNames = Directory.GetFiles(pathFolder);
            
                lstFileNames = new string[lstPathFileNames.Length];

                int c = 0;
                foreach (string s in lstPathFileNames)
                {
                    lstFileNames[c] = Path.GetFileNameWithoutExtension(s);
                    c++;
                }
            }
        }

        /// <summary>
        /// Get the file name from a path
        /// </summary>
        /// <param name="dir">path</param>
        /// <returns>string</returns>
        public static string GetFileName(string dir)
        {
            string filename = "";
            if (dir != null)
                filename = Path.GetFileName(dir);

            return filename;
        }

        /// <summary>
        /// The List of files according to the specified extension
        /// </summary>
        /// <param name="extension">The extension file to filter: ".txt"</param>
        /// <returns>List</returns>
        public List<string> ReadSelectiveData(string extension)
        {
            List<string> strFiles = new List<string>();

            foreach (string strFileName in lstPathFileNames)
            {
                if (extension == Path.GetExtension(strFileName))
                {
                    strFiles.Add(strFileName);
                }
            }
            return strFiles;
        }
    }
}
