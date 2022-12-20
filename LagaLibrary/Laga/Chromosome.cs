using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Laga.Numbers;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// Create and manipulate Chromosomes
    /// </summary>
    public class Chromosome<T> : ICloneable
    {

        private double fitness;

        /// <summary>
        /// The size of the Chr++                                                                        
        /// </summary>
        public int Count
        {
            get
            {
                return Chr.Count;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public List<T> Chr { get; set; }

        /// <summary>
        /// cons 1
        /// </summary>
        public Chromosome(int size)
        {
            Chr = new List<T>(size);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ListDna"></param>
        public Chromosome(List<T> ListDna)
        {
            Chr = ListDna;
        }

        /// <summary>
        /// 
        /// </summary>
        public Chromosome()
        {
            Chr = new List<T>();
        }

        /// <summary>
        /// Get and set the Chr fitness
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
            return Chr[index];
        }

        /// <summary>
        /// Insert DNA in a Chr at specific Location
        /// </summary>
        /// <param name="index">The location in the Chr</param>
        /// <param name="DNA">The DNA to insert</param>
        public void InsertDNA(int index, T DNA)
        {
            Chr[index] = DNA;
        }

        /// <summary>
        /// Add DNA to the Chromosome
        /// </summary>
        /// <param name="DNA">The DNA type</param>
        public void Add(T DNA)
        {
            Chr.Add(DNA);
        }

        /// <summary>
        /// Add data as collection into the Chr
        /// </summary>
        /// <param name="DNACollection">The collection of data</param>
        public void AddRange(IEnumerable<T> DNACollection)
        {
            Chr.AddRange(DNACollection);
        }

        /// <summary>
        /// Chromosome to String
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return string.Join(",", Chr);
        }

        /// <summary>
        /// Convert the Chr in a list
        /// </summary>
        /// <returns>List</returns>
        public List<T> ToList()
        {
            return Chr;
        }

        /// <summary>
        /// Convert the Chr in Array;
        /// </summary>
        /// <returns>Array</returns>
        public T[] ToArray()
        {
            return Chr.ToArray();
        }

        /// <summary>
        /// Fisher_Yates algorithm for the Chr
        /// </summary>
        public void Fisher_Yates() //not working!!!
        {
            int cant = this.Count;
            int index;
            T temp;

            for (int i = 0; i < cant; i++)
            {
                index = Rand.IntNumber(i, cant);

                temp = this.GetDNA(index);
                this.InsertDNA(index, this.GetDNA(i)); //arrMut[index] = arrMut[i];
                this.InsertDNA(i, temp); //arrMut[i] = temp;
            }
        }


        /// <summary>
        /// Make a deep copy from a Chr.
        /// </summary>
        /// <returns>Chromosome</returns>
        public Chromosome<T> Clone() { return new Chromosome<T>(); }
        
        // ICloneable implementation
        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}