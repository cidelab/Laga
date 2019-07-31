using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// use this class to creates Chromosomes.
    /// </summary>
    public class GenrChromosome
    {
        private int size;

        /// <summary>
        /// size of the chromosome
        /// </summary>
        public int SizeChrom
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        private Random rnd;

        /// <summary>
        /// Constructor:
        /// </summary>
        /// <param name="Size">The Lengthof the Chromosome</param>
        public GenrChromosome(int Size)
        {
            rnd = new Random(DateTime.Now.Millisecond);
            this.size = Size;
        }

        /// <summary>
        /// the method generates a chromosome composed by random doubles
        /// between min and max.
        /// </summary>
        /// <param name="min">The min value in the chromosome</param>
        /// <param name="max">The max value in the chromosome(exclusive upper bound)</param>
        /// <returns>double[]</returns>
        /// <example> How to implement this class:
        /// <code>
        /// GenrChromosome chromosome = new GenrChromosome(5);
        /// double[] Chrom = chromosome.NumberChromosome(0.0, 1.0);
        /// 
        /// result:
        /// 0.207198212485387, 0.253313632334263, 0.566322204920613, 0.735812343068334, 0.479827285036364
        ///
        /// float[] Chrom = chromosome.NumberChromosome(0.0f, 1.0f);
        /// 
        /// result:
        /// 9.211745E+08, 1.134843E+09, 1.554793E+09, 1.223132E+09, 1.600176E+09
        ///
        /// int[] Chrom = chromosome.NumberChromosome(0, 10);
        /// 
        /// result: 
        /// 8, 3, 7, 2, 1
        /// </code>
        /// </example>
        public double[] NumberChromosome(double min, double max)
        {
            double[] chr = new double[size];

            for (int i = 0; i < size; i++)
            {
                chr[i] = min + rnd.NextDouble() * (max - min);
            }

            return chr;
        }

        /// <summary>
        /// the method generates a chromosome composed by random floats
        /// between min and max.
        /// </summary>
        /// <param name="min">The min value in the chromosome</param>
        /// <param name="max">The max value in the chromosome(exclusive upper bound)</param>
        /// <returns>float[]</returns>
        public float[] NumberChromosome(float min, float max)
        {
            float[] chr = new float[size];

            for (int i = 0; i < size; i++)
            {
                chr[i] = min + rnd.Next() * (max - min);
            }

            return chr;
        }

        /// <summary>
        /// the method generates a chromosome composed by random integers
        /// between min and max.
        /// </summary>
        /// <param name="min">The min value in the chromosome</param>
        /// <param name="max">The max value in the chromosome(exclusive upper bound)</param>
        /// <returns>int[]</returns>
        public int[] NumberChromosome(int min, int max)
        {
            int[] ch = new int[size];

            for (int i = 0; i < size; i++)
            {
                //ch[i] = rnd.Next(min, max);
                ch[i] = LagaTools.GetRandomNumber(min, max);
            }
            return ch;

        }

        /// <summary>
        /// creates a binary chromosome composed by 1s and 0s;
        /// </summary>
        /// <returns> a random list of 1s and 0s</returns>
        /// <example>
        /// <code>
        /// GenrChromosome chromosome = new GenrChromosome(5);
        /// int[] Chrom = chromosome.NumberChromosomeBinary();
        /// 
        /// result:
        /// 1, 1, 0, 1, 1
        /// </code>
        /// </example>
        public int[] NumberChromosomeBinary()
        {
            int[] chr = new int[size];
            int binary;

            double v;

            for (int i = 0; i < size; i++)
            {
                v = rnd.NextDouble();
                binary = (v < 0.5) ? 0 : 1;

                chr[i] = binary;
            }

            return chr;
        }

        /// <summary>
        /// the method generate a number chromosome composed by non repeated numbers between start and start + size(not inclusive).
        /// the method is based on integer numbers. this method is designed by combinatorial problems.
        /// </summary>
        /// <param name="min">the minimum value in the sequence</param>
        /// /// <param name="max">the maximum value in the sequence</param>
        /// <returns>a non repeat random integer list</returns>
        /// <example>
        /// <code>
        /// GenrChromosome chromosome = new GenrChromosome(5);
        /// char[] Chrom = chromosome.NumberChromosomeSwap(0, 4);
        /// 
        /// results:
        /// 4, 1, 0, 2, 3
        /// 3, 1, 2, 0, 4
        /// </code>
        /// </example>
        public int[] NumberChromosomeSwap(int min, int max)
        {
            int[] chr = new int[(max - min) + 1];
            int count = 0;
            for (int i = min; i < max + 1; i++)
            {
                chr[count] = i;
                count++;
            }
            return LagaTools.Fisher_Yates(chr);
        }

        /// <summary>
        /// Generates a binary chromosome of chars.
        /// </summary>
        /// <returns>a random char list of 1s and 0s</returns>
        /// <example>
        /// <code>
        /// GenrChromosome chromosome = new GenrChromosome(5);
        /// char[] Chrom = chromosome.CharChromosomeBinary();
        /// 
        /// result:
        /// 0, 1, 0, 1, 0,
        /// </code>
        /// </example>
        public char[] CharChromosomeBinary()
        {
            char[] arrChr = new char[size];

            for (int i = 0; i < size; i++)
            {
                arrChr[i] = rnd.NextDouble() >= 0.5 ? '1' : '0';

            }

            return arrChr;
        }

        /// <summary>
        /// Generates an random char chromosome composed by characters.
        /// See <a href="http://www.asciitable.com/">this link</a> for more information.
        /// </summary>
        ///<a href = "http://stackoverflow.com" > here </a>
        /// <param name="start">the start number in the table, inclusive</param>
        /// <param name="end">the end number in the table, inclusive</param>
        /// <returns>returns a random list of characters</returns>
        /// <example>
        /// <code>
        /// GenrChromosome chromosome = new GenrChromosome(25);
        /// char[] Chrom = chromosome.CharChromosome(65, 90);
        /// 
        /// result:
        /// E, B, C, N, F, C, O, P, C, H, O, U, Q, U, G, L, K, Z, E, K, X, A, L, B, Q,
        ///
        /// char[] Chrom = chromosome.CharChromosome(33, 47);
        /// 
        /// result
        /// ,, -, !, /, -, ', %, !, %, %, !, /, ,, +, ), *, ), /, |, /, ], +, (, !, +,
        /// 
        /// char[] Chrom = chromosome.CharChromosome(97, 122);
        /// 
        /// result
        /// q, a, h, k, j, d, u, o, d, l, w, b, d, i, l, l, h, c, n, c, s, d, k, r, h,
        /// </code>
        /// </example>
        public char[] CharChromosome(int start, int end)
        {
            char[] chr = new char[size];
            
            for (int i = 0; i < size; i++)
            {
                chr[i] = (char)rnd.Next(start, end + 1);
            }

            return chr;
        }

    }
}
