using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// Chromosome
    /// </summary>
    public class Chromosome<T>
    {

        private double fitness;

        public int Count
        {
            get
            {
                return chromosome.Count;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public List<T> chromosome { get; set; }

        /// <summary>
        /// cons 1
        /// </summary>
        public Chromosome(int size)
        {
            chromosome = new List<T>(size);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ListDna"></param>
        public Chromosome(List<T> ListDna)
        {
            chromosome = ListDna;
        }

        /// <summary>
        /// 
        /// </summary>
        public Chromosome()
        {
            chromosome = new List<T>();
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
        /// Get Dna Chromosome at specific index
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>T</returns>
        public T GetDNA(int index)
        {
            return chromosome[index];
        }

        /// <summary>
        /// Insert DNA in a chromosome at specific Location
        /// </summary>
        /// <param name="index">The location in the chromosome</param>
        /// <param name="DNA">The DNA to insert</para
        public void InsertDNA(int index, T DNA)
        {
            chromosome[index] = DNA;
        }

        /// <summary>
        /// Add DNA to the Chromosome
        /// </summary>
        /// <param name="DNA">The DNA type</param>
        public void Add(T DNA)
        {
            chromosome.Add(DNA);
        }

        /// <summary>
        /// Converts DNA Chromosome to a String
        /// </summary>
        /// <param name="sep">separation</param>
        /// <returns>string</returns>
        public string Chr2Str(string sep)
        {
            return string.Join(sep, chromosome);
        }

    }
}
