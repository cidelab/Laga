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
        /// The size of the chromosome++                                                                        
        /// </summary>
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
        /// <param name="DNA">The DNA to insert</param>
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
        /// Chromosome to String
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "Chr:[" + string.Join(", ", chromosome) + "]";
        }

        /// <summary>
        /// Convert the chromosome in a list
        /// </summary>
        /// <returns>List</returns>
        public List<T> ToList()
        {
            return chromosome;
        }

        /// <summary>
        /// Convert the chromosome in Array;
        /// </summary>
        /// <returns>Array</returns>
        public T[] ToArray()
        {
            return chromosome.ToArray();
        }

        /// <summary>
        /// Fisher_Yates algorithm for the chromosome
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
        /// Make a deep copy from a chromosome.
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