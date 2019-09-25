using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// Chromosome Class, a collection of DNA.
    /// </summary>
    public class Chromosome
    {
        private int count;
        private double fitness;

        /// <summary>
        /// The chromosome count
        /// </summary>
        public int Count
        {
            get
            {
                return chromosome.Count;
            }
        }

        /// <summary>
        /// chromosome list
        /// </summary>
        public List<DNA> chromosome { get; set; }

        /// <summary>
        /// Get chromosome DNA at specific index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public DNA GetDNA(int index)
        {
            return chromosome[index];
        }

        /// <summary>
        /// Get and set the chromosome fitness
        /// </summary>
        public double Fitness
        {
            get
            {
                return fitness;
            }
            set
            {
                fitness = value;
            }
        }

        /// <summary>
        /// Insert DNA in a chromosome at specific Location
        /// </summary>
        /// <param name="index">The location in the chromosome</param>
        /// <param name="DNA">The DNA to insert</param>
        public void InsertDNA(int index, DNA dna)
        {
            chromosome[index] = dna;
        }

        /*
        /// <summary>
        /// A char chromosome, defined by random characters based on the ASCII table
        /// </summary>
        /// <param name="Size">the length of the list</param>
        /// <param name="Start">the start index in the ASCII table</param>
        /// <param name="End">the end index in the ASCII table</param>
        public Chromosome(int Size, int Start, int End)
        {
            count = Size;
            chromosome = new GenrChromosome(Size).CharChromosome(Start, End).ToList<char>();
        }
        */

        /// <summary>
        /// Build a binary char chromosome
        /// </summary>
        /// <param name="Size">the length of the chromosome</param>
        public Chromosome(int Size)
        {
            count = Size;
            chromosome = new List<DNA>(Size);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ListDNA"></param>
        public Chromosome(List<DNA> ListDNA)
        {
            chromosome = ListDNA;
        }
        /// <summary>
        /// and empty builder.
        /// </summary>
        public Chromosome()
        {
            chromosome = new List<DNA>();
        }

        /// <summary>
        /// Add DNA to the Chromosome
        /// </summary>
        /// <param name="Dna">the char to add</param>
        public void Add(DNA dna)
        {
            chromosome.Add(dna);
        }

        /// <summary>
        /// Converts DNA Chromosome to a String
        /// </summary>
        /// <param name="sep">separation</param>
        /// <returns>string</returns>
        public string Chrom2String(string sep)
        {
            return string.Join(sep, chromosome);
        }

    }
}
