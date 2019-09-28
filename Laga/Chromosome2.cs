using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// IDNA
    /// </summary>
    public class Chromosome2<T>
    {

        public int Count
        {
            get
            {
                return chromosome2.Count;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public List<T> chromosome2 { get; set; }

        /// <summary>
        /// cons 1
        /// </summary>
        public Chromosome2(int size)
        {
            chromosome2 = new List<T>(size);
        }

        public Chromosome2(List<T> lsTDNA)
        {
            chromosome2 = lsTDNA;
        }

        /// <summary>
        /// Get Dna Chromosome at specific index
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>T</returns>
        public T GetDNA(int index)
        {
            return chromosome2[index];
        }

        /// <summary>
        /// Insert DNA in a chromosome at specific Location
        /// </summary>
        /// <param name="index">The location in the chromosome</param>
        /// <param name="DNA">The DNA to insert</para
        public void InsertDNA(int index, T DNA)
        {
            chromosome2[index] = DNA;
        }

        /// <summary>
        /// Add DNA to the Chromosome
        /// </summary>
        /// <param name="DNA">The DNA type</param>
        public void Add(T DNA)
        {
            chromosome2.Add(DNA);
        }

        /// <summary>
        /// Converts DNA Chromosome to a String
        /// </summary>
        /// <param name="sep">separation</param>
        /// <returns>string</returns>
        public string Chrom2String(string sep)
        {
            return string.Join(sep, chromosome2);
        }

    }
}
