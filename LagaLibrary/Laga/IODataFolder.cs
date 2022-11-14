using System.IO;
using System.Collections.Generic;

namespace Laga.IO
{
    /// <summary>
    /// Get Data files information from a folder directory
    /// </summary>
    public class IODataFolder
    {
        private string pathFolder = "";
        private readonly string[] lstPathFileNames;
        private readonly string[] lstFileNames;

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
        /// Get all the files from an specific folder
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
        /// Get the specific files from the filter extension. e: all the ".DWG" files in the folder
        /// </summary>
        /// <param name="PathFolder">The folders path to analize</param>
        /// <param name="Filter">The filter extension</param>
        public IODataFolder(string PathFolder, string Filter)
        {
            pathFolder = PathFolder;
            if (Directory.Exists(pathFolder))
            {
                string[] rawData = Directory.GetFiles(PathFolder);
                lstPathFileNames = ReadSelectiveData(rawData, Filter);
                lstFileNames = new string[lstPathFileNames.Length];

                for (int i = 0; i < lstPathFileNames.Length; i++)
                    lstFileNames[i] = Path.GetFileNameWithoutExtension(lstPathFileNames[i]);
            }



        }

        /// <summary>
        /// Get the file name from a path
        /// </summary>
        /// <param name="PathFile">Path to the file</param>
        /// <returns>string</returns>
        public static string GetFileName(string PathFile)
        {
            string filename = "";
            if (PathFile != null)
                filename = Path.GetFileName(PathFile);

            return filename;
        }

        /// <summary>
        /// Get the specific files from the filter extension.
        /// </summary>
        /// <param name="PathFiles">The path files to filter</param>
        /// <param name="Filter">The filter Extension: like ".jpg"</param>
        /// <returns></returns>
        public string[] ReadSelectiveData(string[] PathFiles, string Filter)
        {
            List<string> strFiles = new List<string>();

            foreach (string strFileName in PathFiles)
            {
                if (Filter == Path.GetExtension(strFileName))
                {
                    strFiles.Add(strFileName);
                }
            }
            return strFiles.ToArray();
        }
    }
}
