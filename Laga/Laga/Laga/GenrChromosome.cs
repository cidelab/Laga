using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{
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

        private LagaTools lg;
        private Random rnd;

        /// <summary>
        /// Constructor:
        /// </summary>
        /// <param name="Size">The Size of the Chromosome</param>
        public GenrChromosome(int Size)
        {
            rnd = new Random((int)DateTime.Now.Millisecond);
            this.size = Size;
            lg = new LagaTools();
        }
 
        /// <summary>
        /// the method generates a chromosome composed by random doubles
        /// between min and max.
        /// </summary>
        /// <param name="min">The min value in the chromosome</param>
        /// <param name="max">The max value in the chromosome(exclusive upper bound)</param>
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
        public int[] NumberChromosome(int min, int max)
        {
            int[] ch = new int[size];

            for (int i = 0; i < size; i++)
            {
                ch[i] = rnd.Next(min, max);
            }
            return ch;

        }

        /// <summary>
        /// creates a binary chromosome composed by 1s and 0s;
        /// </summary>
        /// <returns> a random list of 1s and 0s</returns>
        public int[] BinaryChromosome()
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
        /// creates an random char chromosome composed by characters.
        /// based on this link: http://www.asciitable.com/
        /// </summary>
        /// <param name="start">the start number for the table, inclusive</param>
        /// <param name="end">the end number for the table, inclusive</param>
        /// <returns>returns a random list of characters</returns>
        /// 
        public char[] CharChromosome(int start, int end)
        {
            char[] chr = new char[size];
            
            for (int i = 0; i < size; i++)
                chr[i] = (char)rnd.Next(start, end + 1);

            return chr;
        }

        /// <summary>
        /// the method generate a number chromosome composed by non repeated numbers between start and start + size(not inclusive).
	    /// the method is based on integer numbers. this method is designed by combinatorial problems.
        /// </summary>
        /// <param name="min">the minimum value in the sequence</param>
        /// /// <param name="max">the maximum value in the sequence</param>
        /// <returns>a non repeat random integer list</returns>
        public int[] NumberChromosomeSwap(int min, int max)
        {
            int[] chr = new int[(max - min) + 1];
            int count = 0;
            for (int i = min; i < max + 1; i++)
            {
                chr[count] = i;
                count++;
            }
            return lg.Fisher_Yates(chr);
        }

    }
}
