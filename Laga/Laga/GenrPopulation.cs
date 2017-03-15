using System;
using System.Collections.Generic;
using System.Text;

namespace Laga
{
    public class GenrPopulation
    {
        private LagaTools lgTools;
        private Random rnd;
        private int sizePopulation;

        /// <summary>
        /// SizePopulation
        /// </summary>
        public int SizePop
        {
            get
            {
                return sizePopulation;
            }
            set
            {
                sizePopulation = value;
            }
        }
        
        /// <summary>
        /// Constructor:
        /// </summary>
        /// <param name="SizePopulation">The size of the Population</param>
        public GenrPopulation(int SizePopulation)
        {
            sizePopulation = SizePopulation;
            lgTools = new LagaTools();
            rnd = new Random((int)DateTime.Now.Millisecond);
        }

        /// <summary>
        /// Genr8 a random population based on a chromosome of objects[].
        /// </summary>
        /// <param name="sizePopulation">The size of the population</param>
        /// <param name="SeedChromosome">The seed chromosome to genr8 the population</param>
        /// <param name="percent">the mutation percent in the population</param>
        /// <param name="InOut">true to include the seed chromosome in the population</param>
        /// <returns>Population object [][]</returns>
        public object[][] ObjectPopulationSwap(object[] SeedChromosome, float percent, bool InOut)
        {
            object[][] pop = new object[sizePopulation][];

            int s = 0;
            if (InOut)
            {
                pop[s] = SeedChromosome;
                s++;
                          
                for (int i = s; i < sizePopulation; ++i)
                {
                    SeedChromosome = pop[i - 1];
                    pop[i] = lgTools.Fisher_YatesPercent(SeedChromosome, percent);
                }
            }
             

            return pop;
        }

        /// <summary>
        /// Genr8 a Population of random double.
        /// </summary>
        /// <param name="sizePopulation">The size of the population</param>
        /// <param name="sizeChromosome">The size of the chromosome</param>
        /// <param name="min">The minimum value in the chromosome, inclusive</param>
        /// <param name="max">The maximum value in the chromosome, inclusive</param>
        /// <returns>Population double[][]</returns>
        public double[][] NumPopulation(int sizeChromosome, double min, double max)
        {
            double[][] pop = new double[sizePopulation][];
            double[] chromosome;

            for (int i = 0; i < sizePopulation; ++i)
            {
                chromosome = new double[sizeChromosome];
                for (int j = 0; j < sizeChromosome; ++j)
                {
                    chromosome[j] = min + rnd.NextDouble() * (max - min);
                }
                pop[i] = chromosome;
            }
            return pop;
        }

        /// <summary>
        /// Genr8 a Population of random float.
        /// </summary>
        /// <param name="sizePopulation">The size of the population</param>
        /// <param name="sizeChromosome">The size of the chromosome</param>
        /// <param name="min">The minimum value in the chromosome, inclusive</param>
        /// <param name="max">The maximum value in the chromosome, inclusive</param>
        /// <returns>Population float[][]</returns>
        public float[][] NumPopulation(int sizeChromosome, float min, float max)
        {
            float[][] pop = new float[sizePopulation][];
            float[] chromosome;

            for (int i = 0; i < sizePopulation; ++i)
            {
                chromosome = new float[sizeChromosome];
                for (int j = 0; j < sizeChromosome; ++j)
                {
                    chromosome[j] = (float)(min + rnd.NextDouble() * (max - min));
                }
                pop[i] = chromosome;
            }
            return pop;
        }

        /// <summary>
        /// Genr8 a Population of random int.
        /// </summary>
        /// <param name="sizePopulation">The size of the population</param>
        /// <param name="sizeChromosome">The size of the chromosome</param>
        /// <param name="min">The minimum value in the chromosome, inclusive</param>
        /// <param name="max">The maximum value in the chromosome, inclusive</param>
        /// <returns>Population int[][]</returns>
        public int[][] NumPopulation(int sizeChromosome, int min, int max)
        {
            int[][] pop = new int[sizePopulation][];
            int[] chromosome;

            for (int i = 0; i < sizePopulation; ++i)
            {
                chromosome = new int[sizeChromosome];
                for (int j = 0; j < sizeChromosome; ++j)
                {
                    chromosome[j] = (int)(min + rnd.NextDouble() * ((max + 1) - min));
                }
                pop[i] = chromosome;
            }
            return pop;
        }

        /// <summary>
        /// Genr8 a Population of random integers, between min and max value.
        /// </summary>
        /// <param name="sizePopulation">The size of the population</param>
        /// <param name="min">The minimum value in the chromosome, inclusive</param>
        /// <param name="max">The maximum value in the chromosome, inclusive</param>
        /// <returns>Population int[][]</returns>
        public int[][] NumPopulationSwap(int min, int max)
        {
            int[][] pop = new int[sizePopulation][];
            if (min >= max)
            {
                return pop;
            }
            else
            {
                int capacity = (max - min) + 1;
                int[] chromosome = new int[capacity];

                int count = 0;
                for (int i = min; i < (min + capacity); ++i)
                {
                    chromosome[count] = i;
                    count++;
                }

                for (int i = 0; i < sizePopulation; ++i)
                {
                    pop[i] = lgTools.Fisher_Yates(chromosome);
                }
                return pop;
            }
        }

        /// <summary>
        /// Genr8 a binary Population 101011...
        /// </summary>
        /// <param name="sizePopulation">The size of the population</param>
        /// <param name="sizeChromosome">The size of the chromosome</param>
        /// <returns>Population int[][]</returns>
        public int[][] BinaryPopulationInt(int sizeChromosome)
        {
            int[][] pop = new int[sizePopulation][];
            int[] chromosome;


            for (int i = 0; i < sizePopulation; ++i)
            {
                chromosome = new int[sizeChromosome];
                for (int j = 0; j < sizeChromosome; ++j)
                {
                    if (rnd.NextDouble() >= 0.5)
                    {
                        chromosome[j] = 1;
                    }
                    else
                    {
                        chromosome[j] = 0;
                    }
                }
                pop[i] = chromosome;
            }
            return pop;
        }

        /// <summary>
        /// Genr8 a binary Population '1','0','1','0','1','1'...
        /// </summary>
        /// <param name="sizePopulation">The size of the population</param>
        /// <param name="sizeChromosome">The size of the chromosome</param>
        /// <returns>Population char[][]</returns>
        public char[][] BinaryPopulationChr(int sizeChromosome)
        {
            char[][] pop = new char[sizePopulation][];
            char[] arrChr;

            for (int i = 0; i < sizePopulation; ++i)
            {
                arrChr = new char[sizeChromosome];
                for (int j = 0; j < sizeChromosome; ++j)
                {
                    arrChr[j] = rnd.NextDouble() >= 0.5 ? '1' : '0';
                }

                pop[i] = arrChr;
            }
            return pop;
        }

        /// <summary>
        /// Genr8 a Population composed by random chars.
        /// based on this link: http://www.asciitable.com/
        /// </summary>
        /// <param name="sizeChromosome"></param>
        /// <param name="start">the start number for the table, inclusive: Eg: 97</param>
        /// <param name="end">the end number for the table, inclusive: Eg: 122</param>
        /// <returns></returns>
        public char[][] CharPopulation(int sizeChromosome, int start, int end)
        {
            char[] chromosome;
            char[][] charPopulation = new char[sizePopulation][];

            Random rnd = new Random();
            for (int i = 0; i < sizePopulation; ++i)
            {
                chromosome = new char[sizeChromosome];
                for (int j = 0; j < sizeChromosome; ++j)
                {
                    chromosome[j] = (char)rnd.Next(start, end + 1);
                }
                charPopulation[i] = chromosome;
            }

            return charPopulation;
        }
    }
}
