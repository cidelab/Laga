﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laga.Numbers;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// Generate DNA for Chromosome classes
    /// </summary>
    public static class GenrDNA
    {

        /// <summary>
        /// The method generates a chromosome composed by random doubles between min and max.
        /// </summary>
        /// <param name="size">the total doubles in the chromosome</param>
        /// <param name="min">The min value in the chromosome</param>
        /// <param name="max">The max value in the chromosome (excluded)</param>
        /// <returns>double Chromosome</returns>
        public static Chromosome<double> Rand_Double(int size, double min, double max)
        {
            Chromosome<double> chrom = new Chromosome<double>();
            for (int i = 0; i < size; i++)
                chrom.Add(min + Rand.DblNumber() * (max - min));

            return chrom;
        }

        /// <summary>
        /// Generates a float chromosome between min and max
        /// </summary>
        /// <param name="size">the number of floats in the chromosome</param>
        /// <param name="min">min value</param>
        /// <param name="max">max value</param>
        /// <returns>float Chromosome</returns>
        public static Chromosome<float> Rand_Float(int size, float min, float max)
        {
            Chromosome<float> ch = new Chromosome<float>();

            for (int i = 0; i < size; i++)
                ch.Add(Rand.FltNumber(min, max));

            return ch;
        }

        /// <summary>
        /// Generates a Chromosome composed by random integers
        /// </summary>
        /// <param name="size">the number of characters in the chromosome</param>
        /// <param name="min">min value</param>
        /// <param name="max">max value</param>
        /// <returns>int Chromosome</returns>
        public static Chromosome<int> Rand_Integer(int size, int min, int max)
        {
            Chromosome<int> ch = new Chromosome<int>();

            for (int i = 0; i < size; i++)
                ch.Add(Rand.IntNumber(min, max));

            return ch;
        }

        /// <summary>
        /// Generates a binary Chromosome of 1s and 0s int type.
        /// </summary>
        /// /// <param name="size">the number of integers in the chromosome</param> 
        /// <returns>int Chromosome</returns>
        public static Chromosome<int> Binary_Integer(int size)
        {
            Chromosome<int> arrChr = new Chromosome<int>();

            for (int i = 0; i < size; i++)
                arrChr.Add(Rand.DblNumber() >= 0.5 ? 1 : 0);

            return arrChr;
        }

        /// <summary>
        /// Generate a Chromosome composed by non repeated integers between min and max included, designed for combinatorial problems.
        /// </summary>
        /// <param name="min">min value</param>
        /// <param name="max">max value</param>
        /// <returns>int Chromosome</returns>
        public static Chromosome<int> Shuffle_Integer(int min, int max)
        {
            Chromosome<int> chr = new Chromosome<int>();

            for (int i = min; i < max + 1; i++)
                chr.Add(i);

            int n = chr.Count;
            int index, temp;
            for (int i = 0; i < n; i++)
            {
                index = Rand.IntNumber(i, n);
                temp = chr.GetDNA(index);
                chr.InsertDNA(index, chr.GetDNA(i));
                chr.InsertDNA(i, temp);
            }

            return chr;
        }

        /// <summary>
        /// Generates a binary Chromosome of 1s and 0s char type.
        /// </summary>
        /// <param name="size">the length in the chromosome</param> 
        /// <returns>char Chromosome</returns>
        public static Chromosome<char> Binary_Char(int size)
        {
            Chromosome<char> arrChr = new Chromosome<char>();

            for (int i = 0; i < size; i++)
                arrChr.Add(Rand.DblNumber() >= 0.5 ? '1' : '0');

            return arrChr;
        }

        /// <summary>
        /// Generates a random char Chromosome composed by characters.
        /// See <a href="http://www.asciitable.com/">this link</a> for more information.
        /// </summary>
        /// <param name="size">the length of characters in the chromosome</param>
        /// <param name="start">the start number in the table, inclusive</param>
        /// <param name="end">the end number in the table, exclusive</param>
        /// <returns>char Chromosome</returns>
        public static Chromosome<char> Rand_Char(int size, int start, int end)
        {
            Chromosome<char> chr = new Chromosome<char>(size);

            for (int i = 0; i < size; i++)
                chr.Add((char)Rand.IntNumber(start, end)); //chr.Add((char)rnd.Next(start, end)); 

            return chr;
        }

    }
}
