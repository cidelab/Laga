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
        private List<string> lstfileNames;

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public List<string> ListFileNames
        {
            get
            {
                if (lstfileNames.Count > 0)
                {
                    return lstfileNames;
                }
                else
                {
                    return new List<string>();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PathFolder"></param>
        public IODataFolder(string PathFolder)
        {
            pathFolder = PathFolder; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="extension">The extension file to filter: ".txt"</param>
        /// <returns></returns>
        public List<string> ReadFolderData(string extension)
        {
            List<string> strFiles = new List<string>();

            if (Directory.Exists(pathFolder))
            {
                lstfileNames = Directory.GetFiles(pathFolder).ToList();

                foreach (string strFileName in lstfileNames)
                {
                    if (extension == Path.GetExtension(strFileName))
                    {
                        strFiles.Add(strFileName);
                    }
                }
            }

            return strFiles;
        }


    }
}
