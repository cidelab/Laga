﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// 
    /// </summary>
    public class NaturalSelection<T>
    {
        /// <summary>
        /// The class to select and operates on populations
        /// </summary>
        public NaturalSelection()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="population"></param>
        /// <param name="maxItem"></param>
        /// <returns></returns>
        public static Population RouletteWheelNonPolinomicMin(Population population, int maxItem)
        {
            //clone the array.
            Population matingPool = new Population();
            int index;
            Chromosome chrMax = population.Higher();
            double p1 = chrMax.Fitness;
            double p2 = 0;
            double r;

            for (int i = 0; i < population.Count; i++)
            {
                p2 = population.GetChromosome(i).Fitness;
                r = (p2 / p1) * maxItem;
                index = (int)r;
                index = index < 1 ? 1 : index;

                for (int j = 0; j < index; ++j)
                {
                    matingPool.Add(population.GetChromosome(i));
                }
            }

            return matingPool;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="population"></param>
        /// <param name="maxItem"></param>
        /// <returns></returns>
        public static Population2<T> RouletteWheelNonPolinomicMin(Population2<T> population, int maxItem)
        {
            //clone the array.
            Population2<T> matingPool = new Population2<T>();
            int index;
            Chromosome2<T> chrMax = population.Higher();
            double p1 = chrMax.Fitness;
            double p2 = 0;
            double r;

            for (int i = 0; i < population.Count; i++)
            {
                p2 = population.GetChromosome(i).Fitness;
                r = (p2 / p1) * maxItem;
                index = (int)r;
                index = index < 1 ? 1 : index;

                for (int j = 0; j < index; ++j)
                {
                    matingPool.Add(population.GetChromosome(i));
                }
            }

            return matingPool;
        }

        #region testing algorithms
        /// <summary>
        /// The best ranked individuals have more chance to be selected than worst based in a non-polinomic curve (y = 1 / x)
        /// </summary>
        /// <typeparam name="T">Chromosome type</typeparam>
        /// <param name="population">The Population</param>
        /// <param name="arrFitness">the Fitness list</param>
        /// <param name="maxItem">The maximum number of chromosomes selected in the roulette wheel</param>
        /// <returns>IPopulation</returns>
        public static Population RouletteWheelNonPolinomicMin<T>(Population population, float[] arrFitness, int maxItem)
        {
            //clone the array.
            Population matingPool = new Population();
            int index;
            float p1 = LagaTools.MinMaxValue<float>(arrFitness)[1];//results[0];
            float p2 = 0;
            float r;

            for (int i = 0; i < population.Count; i++)
            {

                p2 = arrFitness[i];
                r = (p2 / p1) * maxItem;
                index = (int)r;
                index = index < 1 ? 1 : index;

                for (int j = 0; j < index; ++j)
                {
                    matingPool.Add(population.GetChromosome(i));
                }
            }

            return matingPool;
        }
        #endregion

        #region Elitism
        /// <summary>
        /// select the number of the best individual in the population.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="count">The number of individuals to select</param>
        /// <returns>objec[][]</returns>
        public object[][] Elitism(object[][] srtPopulation, int count)
        {
            //clone the array.
            object[][] elitismPop = srtPopulation.Clone() as object[][];

            int start = (srtPopulation.Length - count);
            object[][] selChromosome = new object[count][];
            int c = 0;

            for (int i = start; i < elitismPop.Length; ++i)
            {
                selChromosome[c] = elitismPop[i];
                c++;
            }

            return selChromosome;
        }
        /// <summary>
        /// select the number of the best individual in the population.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="count">the number of individuals to select</param>
        /// <returns>double[][]</returns>
        public double[][] Elitism(double[][] srtPopulation, int count)
        {
            //clone the array.
            double[][] elitismPop = srtPopulation.Clone() as double[][];

            double[][] RwheelPop = new double[count][];
            for (int i = 0; i < count; ++i)
            {
                RwheelPop[i] = elitismPop[i];
            }
            return RwheelPop;
        }

        /// <summary>
        /// select the number of the best individual in the population.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="count">The number of individuals to select</param>
        /// <returns>float[][]</returns>
        public float[][] Elitism(float[][] srtPopulation, int count)
        {
            //clone the array.
            float[][] elitismPop = srtPopulation.Clone() as float[][];

            float[][] RwheelPop = new float[count][];

            for (int i = 0; i < count; ++i)
            {
                RwheelPop[i] = elitismPop[i];
            }

            return RwheelPop;
        }

        /// <summary>
        /// select the number of the best individual in the population.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="count">The number of individuals to select</param>
        /// <returns>int[][]</returns>
        public int[][] Elitism(int[][] srtPopulation, int count)
        {
            //clone the array.
            int[][] elitismPop = srtPopulation.Clone() as int[][];

            for (int i = 0; i < srtPopulation.Length; i++)
            {
                elitismPop[i] = new int[srtPopulation[i].Length];
                Array.Copy(srtPopulation[i], 0, elitismPop[i], 0, srtPopulation[i].Length);
            }

            int[][] RwheelPop = new int[count][];

            for (int i = 0; i < count; ++i)
            {
                RwheelPop[i] = elitismPop[i];
            }

            return RwheelPop;
        }

        /// <summary>
        /// select the number of the best individual in the population.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="count"></param>
        /// <returns>char[][]</returns>
        /// <example>
        /// <code>
        /// GenrPopulation pop = new GenrPopulation(20);
        /// char[][] charPop = pop.CharPopulation(5, 97, 122);
        /// float[] rndFitness = Rand.RandomNumbers(20, 0f, 1f);
        /// RankingSort rs = new RankingSort();
        /// rs.BidirectionalBubbleSort(charPop, rndFitness, false);
        /// 
        /// NaturalSelection ns = new NaturalSelection();
        /// char[][] nsPop = ns.Elitism(charPop, 5);
        /// </code>
        /// </example>
        public char[][] Elitism(char[][] srtPopulation, int count)
        {
            count = (count > srtPopulation.Length) ? srtPopulation.Length : count;

            //clone the array.
            char[][] elitismPop = srtPopulation.Clone() as char[][];

            char[][] selChromosome = new char[count][];
            for (int i = 0; i < count; ++i)
            {
                selChromosome[i] = elitismPop[i];
            }

            return selChromosome;
        }
        #endregion

        #region RouletteWheelNonPolinomicMin



        /// <summary>
        /// The best ranked individuals have more chance to be selected than worst based in a non-polinomic curve (y = 1 / x)
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="maxItem">Maximum number of selected individuals</param>
        /// <returns>object[][]</returns>
        public object[][] RouletteWheelNonPolinomicMin(object[][] srtPopulation, int[] results, int maxItem)
        {
            //clone the array.
            List<object> arrRwheelPop = new List<object>();
            int index;
            float p1 = (float)LagaTools.MinMaxValue<int>(results)[0];//results[0];
            float p2;
            float r;

            for (int i = 0; i < srtPopulation.Length; i++)
            {
                p2 = results[i];
                r = (p2 / p1) * maxItem;
                index = (int)r;
                index = index < 1 ? 1 : index;
                for (int j = 0; j < index; ++j)
                {
                    arrRwheelPop.Add(srtPopulation[i]);
                }
            }
            object[][] bigArray = new object[arrRwheelPop.Count][];
            //bigArray = arrRwheelPop.toArray(bigArray);
            bigArray[0] = arrRwheelPop.ToArray();

            object[][] RwheelPop = new object[srtPopulation.Length][];
            Random rand = new Random();
            for (int i = 0; i < srtPopulation.Length; i++)
            {
                RwheelPop[i] = new object[srtPopulation[i].Length];
                RwheelPop[i] = bigArray[rand.Next(bigArray.Length)];
            }

            return RwheelPop;
        }



        /// <summary>
        /// The best ranked individuals have more chance to be selected than worst based in a non-polinomic curve (y = 1 / x)
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="maxItem">Maximum number of selected individuals</param>
        /// <returns>double[][]</returns>
        public double[][] RouletteWheelNonPolinomicMin(double[][] srtPopulation, float[] results, int maxItem)
        {
            //clone the array.
            List<double[]> arrRwheelPop = new List<double[]>();
            int index;
            float p1 = results[0];
            float p2;
            float r;

            for (int i = 0; i < srtPopulation.Length; i++)
            {
                p2 = results[i];
                r = (p2 / p1) * maxItem;
                index = (int)r;
                index = index < 1 ? 1 : index;
                for (int j = 0; j < index; ++j)
                {
                    arrRwheelPop.Add(srtPopulation[i]);
                }
            }
            double[][] bigArray = new double[arrRwheelPop.Count][];
            //bigArray = arrRwheelPop.toArray(bigArray);
            bigArray = arrRwheelPop.ToArray();

            double[][] RwheelPop = new double[srtPopulation.Length][];
            Random rand = new Random();
            for (int i = 0; i < srtPopulation.Length; i++)
            {
                RwheelPop[i] = new double[srtPopulation[i].Length];
                RwheelPop[i] = bigArray[rand.Next(bigArray.Length)];
            }

            return RwheelPop;
        }

        /// <summary>
        /// The best ranked individuals have more chance to be selected than worst based in a non-polinomic curve (y = 1 / x)
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="maxItem">Maximum number of selected individuals</param>
        /// <returns>char[][]</returns>
        /// <example>
        /// <code>
        /// GenrPopulation pop = new GenrPopulation(20);
        /// char[][] charPop = pop.CharPopulation(5, 97, 122);
        /// float[] rndFitness = Rand.RandomNumbers(20, 0f, 1f);
        /// RankingSort rs = new RankingSort();
        /// rs.BidirectionalBubbleSort(charPop, rndFitness, false);
        /// 
        /// NaturalSelection ns = new NaturalSelection();
        /// char[][] nsPop = ns.RouletteWheelNonPolinomicMin(charPop, rndFitness, 10);
        /// </code>
        /// </example>
        public char[][] RouletteWheelNonPolinomicMin(char[][] srtPopulation, float[] results, int maxItem)
        {
            //clone the array.
            List<char[]> arrRwheelPop = new List<char[]>();
            int index;
            float p1 = results[0];
            float p2;
            float r;

            for (int i = 0; i < srtPopulation.Length; i++)
            {
                p2 = results[i];
                r = (p2 / p1) * maxItem;
                index = (int)r;
                index = index < 1 ? 1 : index;
                for (int j = 0; j < index; ++j)
                {
                    arrRwheelPop.Add(srtPopulation[i]);
                }
            }
            char[][] bigArray = new char[arrRwheelPop.Count][];
            //bigArray = arrRwheelPop.toArray(bigArray);
            bigArray = arrRwheelPop.ToArray();

            char[][] RwheelPop = new char[srtPopulation.Length][];
            Random rand = new Random();
            for (int i = 0; i < srtPopulation.Length; i++)
            {
                RwheelPop[i] = new char[srtPopulation[i].Length];
                RwheelPop[i] = bigArray[rand.Next(bigArray.Length)];
            }

            return RwheelPop;
        }
        #endregion

        #region RouletteWheel
        /// <summary>
        /// The individual fitness is proportional to the possibilities of being selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="maxItem">Maximum number of selected individuals</param>
        /// <returns>object[][]</returns>
        public object[][] RouletteWheel(object[][] srtPopulation, float[] results, int maxItem)
        {
            //clone the array.
            List<object> arrRwheelPop = new List<object>();
            int index;
            float p1 = results[0];
            float p2;
            float r;

            for (int i = 0; i < srtPopulation.Length; i++)
            {
                p2 = results[i];
                r = (p1 / p2) * maxItem;
                index = (int)r;
                index = index < 1 ? 1 : index;
                for (int j = 0; j < index; ++j)
                {
                    arrRwheelPop.Add(srtPopulation[i]);
                }
            }
            object[][] bigArray = new object[arrRwheelPop.Count][];
            //bigArray = arrRwheelPop.toArray(bigArray);
            bigArray[0] = arrRwheelPop.ToArray();

            object[][] RwheelPop = new object[srtPopulation.Length][];
            Random rand = new Random();
            for (int i = 0; i < srtPopulation.Length; i++)
            {
                RwheelPop[i] = new object[srtPopulation[i].Length];
                RwheelPop[i] = bigArray[rand.Next(bigArray.Length)];
            }

            return RwheelPop;
        }

        /// <summary>
        /// The individual fitness is proportional to the possibilities of being selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="maxItem">Maximum number of selected individuals</param>
        /// <returns>double[][]</returns>
        public double[][] RouletteWheel(double[][] srtPopulation, int[] results, int maxItem)
        {
            //clone the array.
            List<double[]> arrRwheelPop = new List<double[]>();
            int index;
            float p1 = results[0];
            float p2;
            float r;

            for (int i = 0; i < srtPopulation.Length; i++)
            {
                p2 = results[i];
                r = (p1 / p2) * maxItem;
                index = (int)r;
                index = index < 1 ? 1 : index;
                for (int j = 0; j < index; ++j)
                {
                    arrRwheelPop.Add(srtPopulation[i]);
                }
            }
            double[][] bigArray = new double[arrRwheelPop.Count][];
            //bigArray = arrRwheelPop.toArray(bigArray);
            bigArray = arrRwheelPop.ToArray();

            double[][] RwheelPop = new double[srtPopulation.Length][];
            Random rand = new Random();
            for (int i = 0; i < srtPopulation.Length; i++)
            {
                RwheelPop[i] = new double[srtPopulation[i].Length];
                RwheelPop[i] = bigArray[rand.Next(bigArray.Length)];
            }

            return RwheelPop;
        }

        /// <summary>
        /// The individual fitness is proportional to the possibilities of being selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="maxItem">Maximum number of selected individuals</param>
        /// <returns>float[][]</returns>
        public float[][] RouletteWheel(float[][] srtPopulation, float[] results, int maxItem)
        {
            //clone the array.
            List<float[]> arrRwheelPop = new List<float[]>();
            int index;
            float p1 = results[0];
            float p2;
            float r;

            for (int i = 0; i < srtPopulation.Length; i++)
            {
                p2 = results[i];
                r = (p1 / p2) * maxItem;
                index = (int)r;
                index = index < 1 ? 1 : index;
                for (int j = 0; j < index; ++j)
                {
                    arrRwheelPop.Add(srtPopulation[i]);
                }
            }
            float[][] bigArray = new float[arrRwheelPop.Count][];
            //bigArray = arrRwheelPop.toArray(bigArray);
            bigArray = arrRwheelPop.ToArray();

            float[][] RwheelPop = new float[srtPopulation.Length][];
            Random rand = new Random();
            for (int i = 0; i < srtPopulation.Length; i++)
            {
                RwheelPop[i] = new float[srtPopulation[i].Length];
                RwheelPop[i] = bigArray[rand.Next(bigArray.Length)];
            }

            return RwheelPop;
        }

        /// <summary>
        /// The individual fitness is proportional to the possibilities of being selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="maxItem">Maximum number of selected individuals</param>
        /// <returns>float[][]</returns>
        public float[][] RouletteWheel(float[][] srtPopulation, int[] results, int maxItem)
        {
            //clone the array.
            List<float[]> arrRwheelPop = new List<float[]>();
            int index;
            float p1 = results[0];
            float p2;
            float r;

            for (int i = 0; i < srtPopulation.Length; i++)
            {
                p2 = results[i];
                r = (p1 / p2) * maxItem;
                index = (int)r;
                index = index < 1 ? 1 : index;
                for (int j = 0; j < index; ++j)
                {
                    arrRwheelPop.Add(srtPopulation[i]);
                }
            }
            float[][] bigArray = new float[arrRwheelPop.Count][];
            //bigArray = arrRwheelPop.toArray(bigArray);
            bigArray = arrRwheelPop.ToArray();

            float[][] RwheelPop = new float[srtPopulation.Length][];
            Random rand = new Random();
            for (int i = 0; i < srtPopulation.Length; i++)
            {
                RwheelPop[i] = new float[srtPopulation[i].Length];
                RwheelPop[i] = bigArray[rand.Next(bigArray.Length)];
            }

            return RwheelPop;
        }

        /// <summary>
        /// The individual fitness is proportional to the possibilities of being selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="maxItem">Maximum number of selected individuals</param>
        /// <returns>int[][]</returns>
        public int[][] RouletteWheel(int[][] srtPopulation, float[] results, int maxItem)
        {
            //clone the array.
            List<int[]> arrRwheelPop = new List<int[]>();
            int index;
            float p1 = results[0];
            float p2;
            float r;

            for (int i = 0; i < srtPopulation.Length; i++)
            {
                p2 = results[i];
                r = (p1 / p2) * maxItem;
                index = (int)r;
                index = index < 1 ? 1 : index;
                for (int j = 0; j < index; ++j)
                {
                    arrRwheelPop.Add(srtPopulation[i]);
                }
            }
            int[][] bigArray = new int[arrRwheelPop.Count][];
            //bigArray = arrRwheelPop.toArray(bigArray);
            bigArray = arrRwheelPop.ToArray();

            int[][] RwheelPop = new int[srtPopulation.Length][];
            Random rand = new Random();
            for (int i = 0; i < srtPopulation.Length; i++)
            {
                RwheelPop[i] = new int[srtPopulation[i].Length];
                RwheelPop[i] = bigArray[rand.Next(bigArray.Length)];
            }

            return RwheelPop;
        }

        /// <summary>
        /// The individual fitness is proportional to the possibilities of being selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="maxItem">Maximum number of selected individuals</param>
        /// <returns>char[][]</returns>
        public char[][] RouletteWheel(char[][] srtPopulation, float[] results, int maxItem)
        {
            //clone the array.
            List<char[]> arrRwheelPop = new List<char[]>();
            int index;
            float p1 = results[0];
            float p2;
            float r;

            for (int i = 0; i < srtPopulation.Length; i++)
            {
                p2 = results[i];
                r = (p1 / p2) * maxItem;
                index = (int)r;
                index = index < 1 ? 1 : index;
                for (int j = 0; j < index; ++j)
                {
                    arrRwheelPop.Add(srtPopulation[i]);
                }
            }
            char[][] bigArray = new char[arrRwheelPop.Count][];
            //bigArray = arrRwheelPop.toArray(bigArray);
            bigArray = arrRwheelPop.ToArray();

            char[][] RwheelPop = new char[srtPopulation.Length][];
            Random rand = new Random();
            for (int i = 0; i < srtPopulation.Length; i++)
            {
                RwheelPop[i] = new char[srtPopulation[i].Length];
                RwheelPop[i] = bigArray[rand.Next(bigArray.Length)];
            }

            return RwheelPop;
        }

        /// <summary>
        /// The individual fitness is proportional to the possibilities of being selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="maxItem">Maximum number of selected individuals</param>
        /// <returns>char[][]</returns>
        /// <example>
        /// <code>
        /// GenrPopulation pop = new GenrPopulation(20);
        /// char[][] charPop = pop.CharPopulation(5, 97, 122);
        /// float[] rndFitness = Rand.RandomNumbers(20, 0f, 1f);
        /// RankingSort rs = new RankingSort();
        /// rs.BidirectionalBubbleSort(charPop, rndFitness, false);
        /// 
        /// NaturalSelection ns = new NaturalSelection();
        /// char[][] nsPop = ns.RouletteWheel(charPop, rndFitness, 5);
        /// </code>
        /// </example>
        public char[][] RouletteWheel(char[][] srtPopulation, int[] results, int maxItem)
        {
            //clone the array.
            List<char[]> arrRwheelPop = new List<char[]>();
            int index;
            float p1 = results[0];
            float p2;
            float r;

            for (int i = 0; i < srtPopulation.Length; i++)
            {
                p2 = results[i];
                r = (p1 / p2) * maxItem;
                index = (int)r;
                index = index < 1 ? 1 : index;

                for (int j = 0; j < index; ++j)
                {
                    arrRwheelPop.Add(srtPopulation[i]);
                }
            }
            char[][] bigArray = new char[arrRwheelPop.Count][];
            //bigArray = arrRwheelPop.toArray(bigArray);
            bigArray = arrRwheelPop.ToArray();

            char[][] RwheelPop = new char[srtPopulation.Length][];
            Random rand = new Random();
            for (int i = 0; i < srtPopulation.Length; i++)
            {
                RwheelPop[i] = new char[srtPopulation[i].Length];
                RwheelPop[i] = bigArray[rand.Next(bigArray.Length)];
            }

            return RwheelPop;
        }

        #endregion

        #region RouletteWheelSigmoidal

        /// <summary>
        /// A roulette wheel selection distributed on a sigmoid curve 
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="sizeRoulette">Number of individuals selected</param>
        /// <param name="A1">The maximum number of selected individuals in the roulette wheel</param>
        /// <param name="A2">The minimum number of selected individuals in the roulette wheel</param>
        /// <param name="B1">The start index in the population. 1 is the second individual</param>
        /// <param name="B2">The last index in the population. 5 is the sixth individual</param>
        /// <param name="s">the factor decay, values between 0.00 and 1.00</param>
        /// <returns>object[][]</returns>
        public object[][] RouletteWheelSigmoidal(object[][] srtPopulation, int sizeRoulette, int A1, int A2, int B1, int B2, float s)
        {
            //clone the array.
            List<object> arrRwheelPop = new List<object>();
            int index;

            for (int i = B1; i < B2; i++)
            {
                index = (int)(A1 + (A2 - A1) / (1 + Math.Exp(Math.Log(1 / s - 1) * (B1 + B2 - 2 * i) / (B2 - B1))));
                for (int j = 0; j < index; ++j)
                {
                    arrRwheelPop.Add(srtPopulation[i]);
                }
            }
            object[][] bigArray = new object[arrRwheelPop.Count][];
            //bigArray = arrRwheelPop.toArray(bigArray);
            bigArray[0] = arrRwheelPop.ToArray();

            object[][] RwheelPop = new object[sizeRoulette][];
            Random rand = new Random();
            for (int i = 0; i < sizeRoulette; i++)
            {
                RwheelPop[i] = new object[srtPopulation[i].Length];
                RwheelPop[i] = bigArray[rand.Next(bigArray.Length)];
            }

            return RwheelPop;
        }

        /// <summary>
        /// A roulette wheel selection distributed on a sigmoid curve 
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="sizeRoulette">Number of individuals selected</param>
        /// <param name="A1">The maximum number of selected individuals in the roulette wheel</param>
        /// <param name="A2">The minimum number of selected individuals in the roulette wheel</param>
        /// <param name="B1">The start index in the population. 1 is the second individual</param>
        /// <param name="B2">The last index in the population. 5 is the sixth individual</param>
        /// <param name="s">the factor decay, values between 0.00 and 1.00</param>
        /// <returns>double[][]</returns>
        public double[][] RouletteWheelSigmoidal(double[][] srtPopulation, int sizeRoulette, int A1, int A2, int B1, int B2, float s)
        {
            //clone the array.
            List<double[]> arrRwheelPop = new List<double[]>();
            int index;

            for (int i = B1; i < B2; i++)
            {
                index = (int)(A1 + (A2 - A1) / (1 + Math.Exp(Math.Log(1 / s - 1) * (B1 + B2 - 2 * i) / (B2 - B1))));
                for (int j = 0; j < index; ++j)
                {
                    arrRwheelPop.Add(srtPopulation[i]);
                }
            }
            double[][] bigArray = new double[arrRwheelPop.Count][];
            //bigArray = arrRwheelPop.toArray(bigArray);
            bigArray = arrRwheelPop.ToArray();

            double[][] RwheelPop = new double[sizeRoulette][];
            Random rand = new Random();
            for (int i = 0; i < sizeRoulette; i++)
            {
                RwheelPop[i] = new double[srtPopulation[i].Length];
                RwheelPop[i] = bigArray[rand.Next(bigArray.Length)];
            }

            return RwheelPop;
        }

        /// <summary>
        /// A roulette wheel selection distributed on a sigmoid curve 
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="sizeRoulette">Number of individuals selected</param>
        /// <param name="A1">The maximum number of selected individuals in the roulette wheel</param>
        /// <param name="A2">The minimum number of selected individuals in the roulette wheel</param>
        /// <param name="B1">The start index in the population. 1 is the second individual</param>
        /// <param name="B2">The last index in the population. 5 is the sixth individual</param>
        /// <param name="s">the factor decay, values between 0.00 and 1.00</param>
        /// <returns>float[][]</returns>
        public float[][] RouletteWheelSigmoidal(float[][] srtPopulation, int sizeRoulette, int A1, int A2, int B1, int B2, float s)
        {
            //clone the array.
            List<float[]> arrRwheelPop = new List<float[]>();
            int index;

            for (int i = B1; i < B2; i++)
            {
                index = (int)(A1 + (A2 - A1) / (1 + Math.Exp(Math.Log(1 / s - 1) * (B1 + B2 - 2 * i) / (B2 - B1))));
                for (int j = 0; j < index; ++j)
                {
                    arrRwheelPop.Add(srtPopulation[i]);
                }
            }
            float[][] bigArray = new float[arrRwheelPop.Count][];
            //bigArray = arrRwheelPop.toArray(bigArray);
            bigArray = arrRwheelPop.ToArray();

            float[][] RwheelPop = new float[sizeRoulette][];
            Random rand = new Random();
            for (int i = 0; i < sizeRoulette; i++)
            {
                RwheelPop[i] = new float[srtPopulation[i].Length];
                RwheelPop[i] = bigArray[rand.Next(bigArray.Length)];
            }

            return RwheelPop;
        }

        /// <summary>
        /// A roulette wheel selection distributed on a sigmoid curve 
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="sizeRoulette">Number of individuals selected</param>
        /// <param name="A1">The maximum number of selected individuals in the roulette wheel</param>
        /// <param name="A2">The minimum number of selected individuals in the roulette wheel</param>
        /// <param name="B1">The start index in the population. 1 is the second individual</param>
        /// <param name="B2">The last index in the population. 5 is the sixth individual</param>
        /// <param name="s">the factor decay, values between 0.00 and 1.00</param>
        /// <returns>char[][]</returns>
        public char[][] RouletteWheelSigmoidal(char[][] srtPopulation, int sizeRoulette, int A1, int A2, int B1, int B2, float s)
        {
            //clone the array.
            List<char[]> arrRwheelPop = new List<char[]>();
            int index;

            for (int i = B1; i < B2; i++)
            {
                index = (int)(A1 + (A2 - A1) / (1 + Math.Exp(Math.Log(1 / s - 1) * (B1 + B2 - 2 * i) / (B2 - B1))));
                for (int j = 0; j < index; ++j)
                {
                    arrRwheelPop.Add(srtPopulation[i]);
                }
            }
            char[][] bigArray = new char[arrRwheelPop.Count][];
            //bigArray = arrRwheelPop.toArray(bigArray);
            bigArray = arrRwheelPop.ToArray();

            char[][] RwheelPop = new char[sizeRoulette][];
            Random rand = new Random();
            for (int i = 0; i < sizeRoulette; i++)
            {
                RwheelPop[i] = new char[srtPopulation[i].Length];
                RwheelPop[i] = bigArray[rand.Next(bigArray.Length)];
            }

            return RwheelPop;
        }

        /// <summary>
        /// A roulette wheel selection distributed on a sigmoid curve 
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="sizeRoulette">Number of individuals selected</param>
        /// <param name="A1">The maximum number of selected individuals in the roulette wheel</param>
        /// <param name="A2">The minimum number of selected individuals in the roulette wheel</param>
        /// <param name="B1">The start index in the population. 1 is the second individual</param>
        /// <param name="B2">The last index in the population. 5 is the sixth individual</param>
        /// <param name="s">the factor decay, values between 0.00 and 1.00</param>
        /// <returns>int[][]</returns>
        public int[][] RouletteWheelSigmoidal(int[][] srtPopulation, int sizeRoulette, int A1, int A2, int B1, int B2, float s)
        {
            //clone the array.
            List<int[]> arrRwheelPop = new List<int[]>();
            int index;

            for (int i = B1; i < B2; i++)
            {
                index = (int)(A1 + (A2 - A1) / (1 + Math.Exp(Math.Log(1 / s - 1) * (B1 + B2 - 2 * i) / (B2 - B1))));
                for (int j = 0; j < index; ++j)
                {
                    arrRwheelPop.Add(srtPopulation[i]);
                }
            }
            int[][] bigArray = new int[arrRwheelPop.Count][];
            //bigArray = arrRwheelPop.toArray(bigArray);
            bigArray = arrRwheelPop.ToArray();

            int[][] RwheelPop = new int[sizeRoulette][];
            Random rand = new Random();
            for (int i = 0; i < sizeRoulette; i++)
            {
                RwheelPop[i] = new int[srtPopulation[i].Length];
                RwheelPop[i] = bigArray[rand.Next(bigArray.Length)];
            }

            return RwheelPop;
        }

        #endregion

        #region TournamentSelection
        /// <summary>
        /// As medieval tournament, the individuals have to compete in a tournament, 
        /// the tournament winner is selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="numbTour">Number of tournaments</param>
        /// <param name="preasure">Number of individuals in the tournament</param>
        /// <param name="type">if is "min" the smallest fitness is selected, otherwise the highest</param>
        /// <returns>object[][]</returns>
        public object[][] TournamentSelection(object[][] srtPopulation, int[] results, int numbTour, int preasure, String type)
        {
            object[][] TourPop = new object[numbTour][];
            object[][] arrTour;
            int[] arrResults = new int[preasure];

            Random rnd = new Random();
            int index;
            for (int i = 0; i < numbTour; ++i)
            {
                arrTour = new object[preasure][];
                for (int j = 0; j < preasure; ++j)
                {
                    index = rnd.Next(srtPopulation.Length);
                    arrTour[j] = srtPopulation[index];
                    arrResults[j] = results[index];

                }
                TourPop[i] = Tournament(arrTour, arrResults, type);
            }

            return TourPop;
        }

        /// <summary>
        /// As medieval tournament, the individuals have to compete in a tournament, 
        /// the tournament winner is selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="numbTour">Number of tournaments</param>
        /// <param name="preasure">Number of individuals in the tournament</param>
        /// <param name="type">if is "min" the smallest fitness is selected, otherwise the highest</param>
        /// <returns>object[][]</returns>
        public object[][] TournamentSelection(object[][] srtPopulation, float[] results, int numbTour, int preasure, String type)
        {
            object[][] TourPop = new object[numbTour][];
            object[][] arrTour;
            float[] arrResults = new float[preasure];

            Random rnd = new Random();
            int index;

            for (int i = 0; i < numbTour; ++i)
            {
                arrTour = new object[preasure][];
                for (int j = 0; j < preasure; ++j)
                {
                    index = rnd.Next(srtPopulation.Length);
                    arrTour[j] = srtPopulation[index];
                    arrResults[j] = results[index];

                }
                TourPop[i] = Tournament(arrTour, arrResults, type);
            }

            return TourPop;
        }

        /// <summary>
        /// As medieval tournament, the individuals have to compete in a tournament, 
        /// the tournament winner is selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="numbTour">Number of tournaments</param>
        /// <param name="preasure">Number of individuals in the tournament</param>
        /// <param name="type">if is "min" the smallest fitness is selected, otherwise the highest</param>
        /// <returns>object[][]</returns>
        public double[][] TournamentSelection(double[][] srtPopulation, float[] results, int numbTour, int preasure, String type)
        {
            double[][] TourPop = new double[numbTour][];
            double[][] arrTour;
            float[] arrResults = new float[preasure];

            Random rnd = new Random();
            int index;
            for (int i = 0; i < numbTour; ++i)
            {
                arrTour = new double[preasure][];
                for (int j = 0; j < preasure; ++j)
                {
                    index = rnd.Next(srtPopulation.Length);
                    arrTour[j] = srtPopulation[index];
                    arrResults[j] = results[index];

                }
                TourPop[i] = Tournament(arrTour, arrResults, type);
            }

            return TourPop;
        }

        /// <summary>
        /// As medieval tournament, the individuals have to compete in a tournament, 
        /// the tournament winner is selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="numbTour">Number of tournaments</param>
        /// <param name="preasure">Number of individuals in the tournament</param>
        /// <param name="type">if is "min" the smallest fitness is selected, otherwise the highest</param>
        /// <returns>object[][]</returns>
        public double[][] TournamentSelection(double[][] srtPopulation, int[] results, int numbTour, int preasure, String type)
        {
            double[][] TourPop = new double[numbTour][];
            double[][] arrTour;
            int[] arrResults = new int[preasure];

            Random rnd = new Random();
            int index;
            for (int i = 0; i < numbTour; ++i)
            {
                arrTour = new double[preasure][];
                for (int j = 0; j < preasure; ++j)
                {
                    index = rnd.Next(srtPopulation.Length);
                    arrTour[j] = srtPopulation[index];
                    arrResults[j] = results[index];

                }
                TourPop[i] = Tournament(arrTour, arrResults, type);
            }

            return TourPop;
        }

        /// <summary>
        /// As medieval tournament, the individuals have to compete in a tournament, 
        /// the tournament winner is selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="numbTour">Number of tournaments</param>
        /// <param name="preasure">Number of individuals in the tournament</param>
        /// <param name="type">if is "min" the smallest fitness is selected, otherwise the highest</param>
        /// <returns>object[][]</returns>
        public float[][] TournamentSelection(float[][] srtPopulation, float[] results, int numbTour, int preasure, String type)
        {
            float[][] TourPop = new float[numbTour][];
            float[][] arrTour;
            float[] arrResults = new float[preasure];

            Random rnd = new Random();
            int index;
            for (int i = 0; i < numbTour; ++i)
            {
                arrTour = new float[preasure][];
                for (int j = 0; j < preasure; ++j)
                {
                    index = rnd.Next(srtPopulation.Length);
                    arrTour[j] = srtPopulation[index];
                    arrResults[j] = results[index];

                }
                TourPop[i] = Tournament(arrTour, arrResults, type);
            }

            return TourPop;
        }

        /// <summary>
        /// As medieval tournament, the individuals have to compete in a tournament, 
        /// the tournament winner is selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="numbTour">Number of tournaments</param>
        /// <param name="preasure">Number of individuals in the tournament</param>
        /// <param name="type">if is "min" the smallest fitness is selected, otherwise the highest</param>
        /// <returns>object[][]</returns>
        public float[][] TournamentSelection(float[][] srtPopulation, int[] results, int numbTour, int preasure, String type)
        {
            float[][] TourPop = new float[numbTour][];
            float[][] arrTour;
            int[] arrResults = new int[preasure];

            Random rnd = new Random();
            int index;
            for (int i = 0; i < numbTour; ++i)
            {
                arrTour = new float[preasure][];
                for (int j = 0; j < preasure; ++j)
                {
                    index = rnd.Next(srtPopulation.Length);
                    arrTour[j] = srtPopulation[index];
                    arrResults[j] = results[index];

                }
                TourPop[i] = Tournament(arrTour, arrResults, type);
            }

            return TourPop;
        }

        /// <summary>
        /// As medieval tournament, the individuals have to compete in a tournament, 
        /// the tournament winner is selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="numbTour">Number of tournaments</param>
        /// <param name="preasure">Number of individuals in the tournament</param>
        /// <param name="type">if is "min" the smallest fitness is selected, otherwise the highest</param>
        /// <returns>object[][]</returns>
        public int[][] TournamentSelection(int[][] srtPopulation, float[] results, int numbTour, int preasure, String type)
        {
            int[][] TourPop = new int[numbTour][];
            int[][] arrTour;
            float[] arrResults = new float[preasure];

            Random rnd = new Random();
            int index;
            for (int i = 0; i < numbTour; ++i)
            {
                arrTour = new int[preasure][];
                for (int j = 0; j < preasure; ++j)
                {
                    index = rnd.Next(srtPopulation.Length);
                    arrTour[j] = srtPopulation[index];
                    arrResults[j] = results[index];

                }
                TourPop[i] = Tournament(arrTour, arrResults, type);
            }

            return TourPop;
        }

        /// <summary>
        /// As medieval tournament, the individuals have to compete in a tournament, 
        /// the tournament winner is selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="numbTour">Number of tournaments</param>
        /// <param name="preasure">Number of individuals in the tournament</param>
        /// <param name="type">if is "min" the smallest fitness is selected, otherwise the highest</param>
        /// <returns>object[][]</returns>
        public int[][] TournamentSelection(int[][] srtPopulation, int[] results, int numbTour, int preasure, String type)
        {
            int[][] TourPop = new int[numbTour][];
            int[][] arrTour;
            int[] arrResults = new int[preasure];

            Random rnd = new Random();
            int index;
            for (int i = 0; i < numbTour; ++i)
            {
                arrTour = new int[preasure][];
                for (int j = 0; j < preasure; ++j)
                {
                    index = rnd.Next(srtPopulation.Length);
                    arrTour[j] = srtPopulation[index];
                    arrResults[j] = results[index];

                }
                TourPop[i] = Tournament(arrTour, arrResults, type);
            }

            return TourPop;
        }

        /// <summary>
        /// As medieval tournament, the individuals have to compete in a tournament, 
        /// the tournament winner is selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="numbTour">Number of tournaments</param>
        /// <param name="preasure">Number of individuals in the tournament</param>
        /// <param name="type">if is "min" the smallest fitness is selected, otherwise the highest</param>
        /// <returns>object[][]</returns>
        public char[][] TournamentSelection(char[][] srtPopulation, float[] results, int numbTour, int preasure, String type)
        {
            char[][] TourPop = new char[numbTour][];
            char[][] arrTour;
            float[] arrResults = new float[preasure];

            Random rnd = new Random();
            int index;
            for (int i = 0; i < numbTour; ++i)
            {
                arrTour = new char[preasure][];
                for (int j = 0; j < preasure; ++j)
                {
                    index = rnd.Next(srtPopulation.Length);
                    arrTour[j] = srtPopulation[index];
                    arrResults[j] = results[index];

                }
                TourPop[i] = Tournament(arrTour, arrResults, type);
            }

            return TourPop;
        }

        /// <summary>
        /// As medieval tournament, the individuals have to compete in a tournament, 
        /// the tournament winner is selected.
        /// </summary>
        /// <param name="srtPopulation">The sorted population</param>
        /// <param name="results">The result array from the evaluation</param>
        /// <param name="numbTour">Number of tournaments</param>
        /// <param name="preasure">Number of individuals in the tournament</param>
        /// <param name="type">if is "min" the smallest fitness is selected, otherwise the highest</param>
        /// <returns>object[][]</returns>
        public char[][] TournamentSelection(char[][] srtPopulation, int[] results, int numbTour, int preasure, String type)
        {
            char[][] TourPop = new char[numbTour][];
            char[][] arrTour;
            int[] arrResults = new int[preasure];

            Random rnd = new Random();
            int index;
            for (int i = 0; i < numbTour; ++i)
            {
                arrTour = new char[preasure][];
                for (int j = 0; j < preasure; ++j)
                {
                    index = rnd.Next(srtPopulation.Length);
                    arrTour[j] = srtPopulation[index];
                    arrResults[j] = results[index];

                }
                TourPop[i] = Tournament(arrTour, arrResults, type);
            }

            return TourPop;
        }


        private object[] Tournament(object[][] torneo, float[] results, String type)
        {
            float test = results[0];
            int c = 0;

            if (type == "min")
            {
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test > results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }
            }
            else
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test < results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }


            object[] winner = new object[torneo[0].Length];
            winner = torneo[c];
            return winner;
        }
        private object[] Tournament(object[][] torneo, int[] results, String type)
        {
            int test = results[0];
            int c = 0;
            if (type == "min")
            {
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test > results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }
            }
            else
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test < results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }

            object[] winner = new object[torneo[0].Length];
            winner = torneo[c];
            return winner;
        }
        private double[] Tournament(double[][] torneo, float[] results, String type)
        {
            float test = results[0];
            int c = 0;
            if (type == "min")
            {
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test > results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }
            }
            else
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test < results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }

            double[] winner = new double[torneo[0].Length];
            winner = torneo[c];
            return winner;
        }
        private double[] Tournament(double[][] torneo, int[] results, String type)
        {
            int test = results[0];
            int c = 0;
            if (type == "min")
            {
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test > results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }
            }
            else
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test < results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }

            double[] winner = new double[torneo[0].Length];
            winner = torneo[c];
            return winner;
        }
        private float[] Tournament(float[][] torneo, float[] results, String type)
        {
            float test = results[0];
            int c = 0;
            if (type == "min")
            {
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test > results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }
            }
            else
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test < results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }

            float[] winner = new float[torneo[0].Length];
            winner = torneo[c];
            return winner;
        }
        private float[] Tournament(float[][] torneo, int[] results, String type)
        {
            int test = results[0];
            int c = 0;
            if (type == "min")
            {
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test > results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }
            }
            else
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test < results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }

            float[] winner = new float[torneo[0].Length];
            winner = torneo[c];
            return winner;
        }
        private int[] Tournament(int[][] torneo, float[] results, String type)
        {
            float test = results[0];
            int c = 0;
            if (type == "min")
            {
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test > results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }
            }
            else
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test < results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }

            int[] winner = new int[torneo[0].Length];
            winner = torneo[c];
            return winner;
        }
        private int[] Tournament(int[][] torneo, int[] results, String type)
        {
            int test = results[0];
            int c = 0;
            if (type == "min")
            {
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test > results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }
            }
            else
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test < results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }

            int[] winner = new int[torneo[0].Length];
            winner = torneo[c];
            return winner;
        }
        char[] Tournament(char[][] torneo, float[] results, String type)
        {
            float test = results[0];
            int c = 0;
            if (type == "min")
            {
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test > results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }
            }
            else
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test < results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }

            char[] winner = new char[torneo[0].Length];
            winner = torneo[c];
            return winner;
        }
        char[] Tournament(char[][] torneo, int[] results, String type)
        {
            int test = results[0];
            int c = 0;
            if (type == "min")
            {
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test > results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }
            }
            else
                for (int i = 0; i < torneo.Length; ++i)
                {
                    if (test < results[i])
                    {
                        test = results[i];
                        c = i;
                    }
                }
            char[] winner = new char[torneo[0].Length];
            winner = torneo[c];
            return winner;
        }

        #endregion

    }
}