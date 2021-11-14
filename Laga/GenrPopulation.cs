using System;
using System.Collections.Generic;
using System.Text;
using LagaUnity;
using Laga.Geometry;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// Generate basic populations
    /// </summary>
    public class GenrPopulation
    {
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
            rnd = new Random(DateTime.Now.Millisecond);
        }

        /// <summary>
        /// Genr8 a random population based on a chromosome of objects[]
        /// </summary>
        /// <param name="SeedChromosome">The seed chromosome to genr8 the population</param>
        /// <param name="percent">the mutation percent in the population</param>
        /// <param name="InOut">true to include the seed chromosome in the population</param>
        /// <returns>Population object[][]</returns>
        /// <example>
        /// <code>
        /// //This is the Agent class
        /// public class Agent
        /// {
        ///    private double[] awards;
        ///    public double[] Awards
        ///    {
        ///        get { return awards; }
        ///        set { awards = value; }
        ///    }
        ///
        ///    private readonly string[] labels = new string[] { "forward", "back", "left", "right" };
        ///    public string[] Labels
        ///    {
        ///        get { return labels; }
        ///    }
        ///
        ///    private int[] pos;
        ///    public int[] Pos
        ///    {
        ///        get { return pos; }
        ///        set { pos = value; }
        ///    }
        /// }
        /// 
        /// Here we will creates the Chromosome...
        /// GenrPopulation pop = new GenrPopulation(5); //population size...
        ///
        /// our agent object...
        /// object[] agentTrace = new object[pop.SizePop];
        /// Agent agent;
        ///
        /// genrChromosome to helps create the data.
        /// GenrChromosome dtaChrome = new GenrChromosome(agentTrace.Length); 
        ///
        /// in this loop we creates the chromosome.
        /// for(int i = 0; i &lt; agentTrace.Length ; i++)
        /// {
        ///     agent = new Agent();
        ///     dtaChrome.SizeChrom = 4;
        ///     agent.Awards = dtaChrome.NumberChromosome(0.00, 1.00);
        ///     dtaChrome.SizeChrom = 2;
        ///     agent.Pos = dtaChrome.NumberChromosome(0, 8);
        ///     agentTrace[i] = agent;
        /// }
        ///
        /// And we creates the population for the agents trajectories. 
        /// that's all.
        /// Object[][] popAgents = pop.ObjectPopulationSwap(agentTrace, 1.0f, true);
        ///
        /// result:
        /// Chromosome(agents trace) : 0
        /// Position:(3, 2) - Awards: forward:0.87, back:0.74, left:0.87, right:0.54
        /// Position:(2, 7) - Awards: forward:0.53, back:0.32, left:0.53, right:0.27
        /// Position:(1, 1) - Awards: forward:0.34, back:0.48, left:0.1, right:0.89
        /// Position:(5, 1) - Awards: forward:0.66, back:0.91, left:0.86, right:0.53
        /// Position:(1, 6) - Awards: forward:0.68, back:0.93, left:0.98, right:0.04
        /// Position:(5, 2) - Awards: forward:0.39, back:0.93, left:1, right:0.97
        /// Position:(0, 5) - Awards: forward:0.83, back:0.71, left:0.57, right:0.32
        /// 
        /// Chromosome(agents trace) : 1
        /// Position:(3, 2) - Awards: forward:0.87, back:0.74, left:0.87, right:0.54
        /// Position:(5, 2) - Awards: forward:0.39, back:0.93, left:1, right:0.97
        /// Position:(5, 1) - Awards: forward:0.66, back:0.91, left:0.86, right:0.53
        /// Position:(1, 1) - Awards: forward:0.34, back:0.48, left:0.1, right:0.89
        /// Position:(0, 5) - Awards: forward:0.83, back:0.71, left:0.57, right:0.32
        /// Position:(2, 7) - Awards: forward:0.53, back:0.32, left:0.53, right:0.27
        /// Position:(1, 6) - Awards: forward:0.68, back:0.93, left:0.98, right:0.04
        /// 
        /// Chromosome(agents trace) : 2
        /// Position:(3, 2) - Awards: forward:0.87, back:0.74, left:0.87, right:0.54
        /// Position:(5, 2) - Awards: forward:0.39, back:0.93, left:1, right:0.97
        /// Position:(1, 1) - Awards: forward:0.34, back:0.48, left:0.1, right:0.89
        /// Position:(2, 7) - Awards: forward:0.53, back:0.32, left:0.53, right:0.27
        /// Position:(0, 5) - Awards: forward:0.83, back:0.71, left:0.57, right:0.32
        /// Position:(5, 1) - Awards: forward:0.66, back:0.91, left:0.86, right:0.53
        /// Position:(1, 6) - Awards: forward:0.68, back:0.93, left:0.98, right:0.04
        ///
        /// Chromosome(agents trace) : 3
        /// Position:(0, 5) - Awards: forward:0.83, back:0.71, left:0.57, right:0.32
        /// Position:(5, 1) - Awards: forward:0.66, back:0.91, left:0.86, right:0.53
        /// Position:(1, 1) - Awards: forward:0.34, back:0.48, left:0.1, right:0.89
        /// Position:(1, 6) - Awards: forward:0.68, back:0.93, left:0.98, right:0.04
        /// Position:(5, 2) - Awards: forward:0.39, back:0.93, left:1, right:0.97
        /// Position:(3, 2) - Awards: forward:0.87, back:0.74, left:0.87, right:0.54
        /// Position:(2, 7) - Awards: forward:0.53, back:0.32, left:0.53, right:0.27
        ///
        /// Chromosome(agents trace) : 4
        /// Position:(5, 1) - Awards: forward:0.66, back:0.91, left:0.86, right:0.53
        /// Position:(5, 2) - Awards: forward:0.39, back:0.93, left:1, right:0.97
        /// Position:(3, 2) - Awards: forward:0.87, back:0.74, left:0.87, right:0.54
        /// Position:(2, 7) - Awards: forward:0.53, back:0.32, left:0.53, right:0.27
        /// Position:(1, 1) - Awards: forward:0.34, back:0.48, left:0.1, right:0.89
        /// Position:(1, 6) - Awards: forward:0.68, back:0.93, left:0.98, right:0.04
        /// Position:(0, 5) - Awards: forward:0.83, back:0.71, left:0.57, right:0.32
        /// 
        /// </code>
        /// </example>
        public object[][] ObjectPopulationSwap(object[] SeedChromosome, float percent, bool InOut)
        {
            object[][] pop = new object[sizePopulation][];
                  
                for (int i = 0; i < sizePopulation; ++i)
                {
                    object[] copyChromosome = (object[])SeedChromosome.Clone();

                if ((i == 0) && (InOut))
                    {
                        pop[i] = SeedChromosome;
                    }
                    else
                    {
                        pop[i] = Tools.Fisher_YatesPercent(SeedChromosome, percent);
                    }
                }

            return pop;
        }

        /// <summary>
        /// Genr8 a Population of random double.
        /// </summary>
        /// <param name="sizeChromosome">The size of the chromosome</param>
        /// <param name="min">The minimum value in the chromosome, inclusive</param>
        /// <param name="max">The maximum value in the chromosome, inclusive</param>
        /// <returns>Population double[][]</returns>
        /// <example>
        /// <code>
        /// GenrPopulation pop = new GenrPopulation(5);
        /// double[][] dblPop = pop.NumPopulation(12, 0.00, 1.00);
        ///
        /// result for double population
        /// Chromosome: 0
        /// - 0.134, 0.623, 0.931, 0.896, 0.945, 0.599, 0.824, 0.837, 0.671, 0.081, 0.496, 0.027,
        /// Chromosome: 1
        /// - 0.669, 0.725, 0.667, 0.651, 0.073, 0.215, 0.052, 0.92, 0.371, 0.122, 0.734, 0.535,
        /// Chromosome: 2
        /// - 0.741, 0.056, 0.469, 0.699, 0.216, 0.727, 0.221, 0.322, 0.825, 0.301, 0.057, 0.775,
        /// Chromosome: 3
        /// - 0.884, 0.257, 0.278, 0.461, 0.152, 0.24, 0.929, 0.364, 0.869, 0.415, 0.995, 0.776,
        /// Chromosome: 4
        /// - 0.022, 0.403, 0.101, 0.041, 0.528, 0.667, 0.517, 0.012, 0.889, 0.395, 0.155, 0.888,
        /// </code>
        /// </example>
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
        /// <param name="min">The minimum value in the chromosome, inclusive</param>
        /// <param name="max">The maximum value in the chromosome, inclusive</param>
        /// <returns>Population int[][]</returns>
        /// <example>
        /// <code>
        /// GenrPopulation pop = new GenrPopulation(5);
        /// int[][] intPop = pop.NumPopulationSwap(0, 10);
        ///
        /// results
        /// Chromosome: 0
        /// - 1, 4, 8, 6, 2, 10, 9, 5, 0, 7, 3,
        /// Chromosome: 1
        /// - 5, 4, 0, 1, 7, 6, 8, 10, 2, 3, 9,
        ///  Chromosome: 2
        /// - 1, 6, 10, 7, 3, 5, 9, 2, 0, 8, 4,
        /// Chromosome: 3
        /// - 9, 1, 4, 6, 10, 2, 7, 5, 8, 0, 3,
        /// Chromosome: 4
        /// - 2, 5, 0, 7, 6, 1, 4, 3, 8, 9, 10,
        /// </code>
        /// </example>
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
                    pop[i] = Tools.Fisher_Yates(chromosome);
                }
                return pop;
            }
        }

        /// <summary>
        /// Genr8 a binary Population 101011...
        /// </summary>
        /// <param name="sizeChromosome">The size of the chromosome</param>
        /// <returns>Population int[][]</returns>
        /// <example>
        /// <code>
        /// GenrPopulation pop = new GenrPopulation(5);
        /// int[][] intPop = pop.BinaryPopulationInt(20);
        ///
        /// result:
        /// Chromosome: 0
        /// - 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1,
        /// Chromosome: 1
        /// - 1, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0,
        /// Chromosome: 2
        /// - 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0,
        /// Chromosome: 3
        /// - 1, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1,
        /// Chromosome: 4
        /// - 1, 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0,
        /// </code>
        /// </example>
        public int[][] BinaryPopulationInt(int sizeChromosome)
        {
            int[][] pop = new int[sizePopulation][];
            int[] chromosome;


            for (int i = 0; i < sizePopulation; ++i)
            {
                chromosome = new int[sizeChromosome];
                for (int j = 0; j < sizeChromosome; ++j)
                {
                    if (Tools.GetRandomNumber() >= 0.5)
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
        /// <param name="sizeChromosome">The size of the chromosome</param>
        /// <returns>Population char[][]</returns>
        /// <example>
        ///  GenrPopulation pop = new GenrPopulation(5);
        /// [][] charPop = pop.BinaryPopulationChr(10);
        ///
        /// result:
        /// 
        /// Chromosome: 0
        /// - 0, 1, 1, 1, 0, 0, 1, 0, 1, 0,
        /// Chromosome: 1
        /// - 1, 1, 1, 1, 0, 1, 0, 0, 0, 1,
        /// Chromosome: 2
        /// - 1, 1, 0, 0, 0, 1, 0, 1, 0, 1,
        /// Chromosome: 3
        /// - 0, 1, 0, 0, 1, 1, 1, 0, 1, 0,
        /// Chromosome: 4
        /// - 1, 0, 0, 0, 1, 0, 1, 1, 1, 1,
        /// </example>
        public char[][] BinaryPopulationChr(int sizeChromosome)
        {
            char[][] pop = new char[sizePopulation][];
            char[] arrChr;

            for (int i = 0; i < sizePopulation; ++i)
            {
                arrChr = new char[sizeChromosome];
                for (int j = 0; j < sizeChromosome; ++j)
                {
                    arrChr[j] = Tools.GetRandomNumber() >= 0.5 ? '1' : '0';
                }

                pop[i] = arrChr;
            }
            return pop;
        }

        /// <summary>
        /// Genr8 a Population composed by random chars.
        /// based on this link: http://www.asciitable.com/
        /// </summary>
        /// <param name="sizeChromosome">The size of the chromosome</param>
        /// <param name="start">the start number for the table, inclusive: Eg: 97</param>
        /// <param name="end">the end number for the table, inclusive: Eg: 122</param>
        /// <returns>Population char[][]</returns>
        /// <example>
        /// <code> 
        /// GenrPopulation pop = new GenrPopulation(5);
        /// char[][] charPop = pop.CharPopulation(30, 50, 100);
        /// 
        /// /// result:
        /// Chromosome: 0
        /// - Q, 5, A, P, ^, \, T, ^, F, ;, U, ?, Z, :, 5, E, B, ], S, H, A, L, I, =, _, ~, E, B, @, H
        /// Chromosome: 1
        /// - C, 7, T, ], W, W, 7, ?, 4, b, 4, C, L, ], I, Z, J, 8, :, A, S, b, L, 9, a, 7, Q, 6, U, T
        /// Chromosome: 2
        /// - H, C, O, b, ], O, M, a, H, C, @, 5, [, U, F, b, 2, P, X, 7, W, ?, :, d, Z, E, P, L, a, R
        /// Chromosome: 3
        /// - 7, 3, N, E, L, U, Y, N, 2, ^, ?, M, U, \, 3, O, 9, [, X, c, 7, 3, C, O, b, ;, ;, P, :, I
        /// Chromosome: 4
        /// - d, 2, 2, Z, =, ?, L, H, ;, V, :, H, P, ^,], ;, O, B, b, [, @, Y, Y, b, L, 5, T, c, G
        /// </code>
        /// </example>
        /// 
        public char[][] CharPopulation(int sizeChromosome, int start, int end)
        {
            char[] chromosome;
            char[][] charPopulation = new char[sizePopulation][];

            for (int i = 0; i < sizePopulation; ++i)
            {
                chromosome = new char[sizeChromosome];
                for (int j = 0; j < sizeChromosome; ++j)
                {
                    chromosome[j] = Tools.RandomChar(start, end);
                }
                charPopulation[i] = chromosome;
            }

            return charPopulation;
        }

        /// <summary>
        /// Genr8 a Random population of points [x,y,z]
        /// </summary>
        /// <param name="SizeChromosome">The length of the chromosome</param>
        /// <param name="minX">The minimum value for X coordinate</param>
        /// <param name="maxX">The maximum value for X coordinate</param>
        /// <param name="minY">The minimum value for Y coordinate</param>
        /// <param name="maxY">The maximum value for Y coordinate</param>
        /// <param name="minZ">The minimum value for Z coordinate</param>
        /// <param name="maxZ">The maximum value for Z coordinate</param>
        /// <returns> a population of points</returns>
        /// <example>
        /// <code>
        /// GenrPopulation pop = new GenrPopulation(5);
        /// point[][] pntPop = pop.PointPopulation(4, 0, 100d, 0d, 100d, 0d, 100d);
        ///
        /// result:
        /// Chromosome: 0
        /// - (67.06, 80, 95.77), (82.34, 41.8, 81.37), (74.42, 12.58, 46.27), (46.76, 59.55, 56.52),
        /// Chromosome: 1
        /// - (56.48, 17.73, 27.91), (10.31, 68.15, 57.53), (62.79, 51.99, 29.98), (58.98, 41.34, 11.13),
        /// Chromosome: 2
        /// - (38.26, 63.32, 64.84), (22.49, 65.4, 86.53), (42.75, 16.47, 12.87), (72.12, 70.32, 48.68),
        /// Chromosome: 3
        /// - (32.05, 66.44, 0.96), (84.8, 18.4, 99.88), (48.29, 60.83, 37.58), (78.45, 42.13, 16.48),
        /// Chromosome: 4
        /// - (79.54, 62.78, 7.36), (84.51, 83.64, 69.42), (1.99, 8.09, 38.65), (84.64, 44.09, 78.47),
        /// </code>
        /// </example>
        public Vector[][] PointPopulation(int SizeChromosome, float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
        {
            Vector[] chromosome;
            Vector[][] popPoints = new Vector[sizePopulation][];

            for (int i = 0; i < sizePopulation; i++)
            {
                chromosome = new Vector[SizeChromosome];
                for (int j = 0; j < SizeChromosome; j++)
                {
                    chromosome[j] = new Vector(minX + (float)rnd.NextDouble() * (maxX - minX), minY + (float)rnd.NextDouble() * (maxY - minY), minZ + (float)rnd.NextDouble() * (maxZ - minZ));
                }

                popPoints[i] = chromosome;
            }
            return popPoints;
        }
    }
}
