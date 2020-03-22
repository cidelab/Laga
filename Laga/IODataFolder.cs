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
    /// Get Data from a folder
    /// </summary>
    public class IODataFolder
    {
        private string pathFolder = "";
        private string[] lstPathFileNames;
        private List<string> lstFileNames;

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
        /// The Object to extract data from the folder
        /// </summary>
        /// <param name="PathFolder">The folders path to analize</param>
        public IODataFolder(string PathFolder)
        {
            pathFolder = PathFolder;
            if (Directory.Exists(pathFolder))
            {
                lstPathFileNames = Directory.GetFiles(pathFolder);
                
                lstFileNames = new List<string>();

                foreach (string s in lstPathFileNames)
                    lstFileNames.Add(Path.GetFileName(s));
            }
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
