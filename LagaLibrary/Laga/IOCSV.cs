using Laga.GeneticAlgorithm;
using System.IO;
using System;
using System.Text;
using System.Runtime.ConstrainedExecution;

namespace Laga.IO
{
    /// <summary>
    /// Write CSV data
    /// </summary>
    public class IOCSV
    {
        private readonly string file;
        private readonly string[] features;
        private const string separator = ",";

        private readonly Population<string> strPopulation;
        private readonly StringBuilder output;

        /// <summary>
        /// Write a CSV based on population data
        /// </summary>
        /// <param name="FileName">The file name to save the CSV file</param>
        /// <param name="Features">Array of strings representing the features</param>
        /// /// <param name="Data">the data to write in the CSV file</param>
        public IOCSV(string FileName, string[] Features, Population<string> Data)
        {
            this.file = FileName;
            this.features = Features;
            strPopulation = Data;
            
            output = new StringBuilder();

            if (features.Length == strPopulation.GetChromosome(0).Count)
            {
                output.AppendLine(string.Join(separator, features));

                foreach (Chromosome<string> chr in strPopulation)
                {
                    output.AppendLine(string.Join(separator, chr.ToList()));
                }

                SaveAndClose();
            }
            else
            {
                Console.WriteLine("The number of features should be the same as the number of columns");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName">The file name to save the CSV file</param>
        /// <param name="Features">Array of strings representing the features</param>
        public IOCSV(string FileName, string[] Features)
        {
            this.file = FileName;
            this.features = Features;
            output = new StringBuilder();
            output.AppendLine(string.Join(separator, features));
        }

        /// <summary>
        /// Append a row data
        /// </summary>
        /// <param name="chromosome">row data to append</param>
        public void AddRowData(Chromosome<string> chromosome)
        {
            output.AppendLine(chromosome.ToString());
        }

        /// <summary>
        /// Save and close the CSV file. Do not use when the constructor use a population
        /// </summary>
        public void SaveAndClose()
        {
            try
            {
                File.AppendAllText(file, output.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + " Data could not be written to the CSV file.");
                return;
            }
        }
    }
}
