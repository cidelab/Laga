﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Laga.Numbers;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// Create and manipulate Chromosomes
    /// </summary>
    public class Chromosome<T>
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
        /// Converts DNA Chromosome to a String
        /// </summary>
        /// <param name="sep">separation</param>
        /// <returns>string</returns>
        public string Chr2Str(string sep)
        {
            return string.Join(sep, chromosome);
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
        /// Fisher-Yates Shuffle Algorithm for array of integers.
        /// </summary>
        /// <param name="chromosome"></param>
        /// <returns></returns>
        /// 
        public static Chromosome<T> Fisher_Yates(Chromosome<T> chromosome) //not working!!!
        {
            int cant = chromosome.Count;
            int index;
            
            Random rnd = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < cant; i++)
            {
                index = i + (int)(rnd.NextDouble() * (cant - i));
                chromosome.InsertDNA(index, chromosome.GetDNA(i)); //arrMut[index] = arrMut[i];
                chromosome.InsertDNA(i, chromosome.GetDNA(index)); //arrMut[i] = temp;
            }
            return chromosome;
        }

    }
}
