using System;
using System.Collections.Generic;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// 
    /// </summary>
    public class NaturalSelection
    {
        /// <summary>
        /// 
        /// </summary>
        public NaturalSelection()
        {

        }

        //////////////////////////OBJECT/////////////////////////////////////
        /**
         * ElitismSelection method.
         * select the number of the best individual in the population.
         *
         * @param srtPopulation -> a sorted population by any sort algorithm.
         * @param count         -> quantity of individuals selected for the next generation.
         * @return object[][] population.
         * 
         * 
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="count"></param>
        /// <returns></returns>
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
        /**
 * RouletteWheel method.
 * select a number of individuals depending of their ranking in the population.
 * the best ranked individuals have more chance to be selected than worst. 
 * All individuals in the population have the chance to be selected. This algorithm is based in a non-polinomic curve (y = 1/x).
 * 
 * @param srtPopulation -> a sorted population by any sort algorithm.
 * @param results 		-> the array of results from the evaluation in int[] flavour
 * @param maxItem 		-> the maxItem is the maximum number of selected individuals in the roulette wheel.
 * @return object[][] population.
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="maxItem"></param>
        /// <returns></returns>
        public object[][] RouletteWheelNonPolinomicMin(object[][] srtPopulation, int[] results, int maxItem)
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

        /**
 * RouletteWheel method.
 * select a number of individuals depending of their ranking in the population.
 * the best ranked individuals have more chance to be selected than worst. 
 * All individuals in the population have the chance to be selected. This algorithm is based in a non-polinomic curve (y = 1/x).
 * 
 * @param srtPopulation -> a sorted population by any sort algorithm.
 * @param results 		-> the array of results from the evaluation in int[] flavour
 * @param maxItem 		-> the maxItem is the maximum number of selected individuals in the roulette wheel.
 * @return object[][] population.
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="maxItem"></param>
        /// <returns></returns>
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

        /**
 * RouletteWheelSigmoidal method.
 * select a number of indiviudals depending of their ranking in the population.
 * the best ranked individuals have more chance to be selected thant worst. 
 * Although all the individuals has a chance to be selected. the roulette wheel is based in sigmoidal curve, (See RouletteWheelSigmoidalEngine.pde).
 * 
 * @param srtPopulation -> a sorted population by any sort algorithm.
 * @param sizeRoulette  -> number of the individuals selected.
 * @param A1			-> the maximum number of individuals in the roulette wheel (aprox).
 * @param A2 			-> the minimum number of individuals in the roulette wheel (aprox).
 * @param B1 	 		-> the start scope in the population, i.e. 1 the selection will start in the second individual
 * @param B2	 		-> the end scope in the population, i.e. the size of the population: the las individuals (worst) will be included.
 * @param s				-> the decay of the curve. 0 < s < 1  (See RouletteWheelSigmoidalEngine.pde).
 * @return object[][] population.
 * 
 * 
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="sizeRoulette"></param>
        /// <param name="A1"></param>
        /// <param name="A2"></param>
        /// <param name="B1"></param>
        /// <param name="B2"></param>
        /// <param name="s"></param>
        /// <returns></returns>
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

        /**
 * TournamentSelection method.
 * select a number of indiviudals trough a tournament selection.
 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
 * This method return a new population and can be bigger than the original size.
 * in the TorunamentSelection method is not necessary a sorted population.
 * 
 * @param srtPopulation -> a population.
 * @param resutls		-> the array of results from the evaluation in int[] flavor.
 * @param numbTour 		-> the quantity of tournaments, any integer.
 * @param preasure 	 	-> number of individuals in the competition.
 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
 * @return object[][] population.
 * 
 * 
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="numbTour"></param>
        /// <param name="preasure"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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

        /**
 * TournamentSelection method.
 * select a number of indiviudals trough a tournament selection.
 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
 * This method return a new population and can be bigger than the original size.
 * in the TorunamentSelection method is not necessary a sorted population.
 * 
 * @param srtPopulation -> a population.
 * @param resutls		-> the array of results from the evaluation in float[] flavor.
 * @param numbTour 		-> the quantity of tournaments, any integer.
 * @param preasure 	 	-> number of individuals in the competition.
 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
 * @return object[][] population.
 * 
 * 
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="numbTour"></param>
        /// <param name="preasure"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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
        object[] Tournament(object[][] torneo, float[] results, String type)
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
        object[] Tournament(object[][] torneo, int[] results, String type)
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


        //////////////////////////DOUBLE/////////////////////////////////////
        /**
         * ElitismSelection method.
         * select the number of the best indiviudals in the population.
         *
         * @param srtPopulation -> a sorted population by any sort algorithm.
         * @param count         -> quantity of individuals selected for the next generation.
         * @return double[][] population.
         * 
         * 
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="count"></param>
        /// <returns></returns>
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

        /**
 * RouletteWheel method.
 * select a number of individuals depending of their ranking in the population.
 * the best ranked individuals have more chance to be selected than worst. 
 * All individuals in the population have the chance to be selected. This algorithm is based in a non-polinomic curve (y = 1/x).
 * 
 * @param srtPopulation -> a sorted population by any sort algorithm.
 * @param results 		-> the array of results from the evaluation in int[] flavour
 * @param maxItem 		-> the maxItem is the maximum number of selected individuals in the roulette wheel.
 * @return double[][] population.
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="maxItem"></param>
        /// <returns></returns>
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

        /**
 * RouletteWheel method.
 * select a number of individuals depending of their ranking in the population.
 * the best ranked individuals have more chance to be selected than worst. 
 * All individuals in the population have the chance to be selected. This algorithm is based in a non-polinomic curve (y = 1/x).
 * 
 * @param srtPopulation -> a sorted population by any sort algorithm.
 * @param results 		-> the array of results from the evaluation in int[] flavour
 * @param maxItem 		-> the maxItem is the maximum number of selected individuals in the roulette wheel.
 * @return double[][] population.
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="maxItem"></param>
        /// <returns></returns>
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

        /**
 * RouletteWheelSigmoidal method.
 * select a number of indiviudals depending of their ranking in the population.
 * the best ranked individuals have more chance to be selected thant worst. 
 * Although all the individuals has a chance to be selected. the roulette wheel is based in sigmoidal curve, (See RouletteWheelSigmoidalEngine.pde).
 * 
 * @param srtPopulation -> a sorted population by any sort algorithm.
 * @param sizeRoulette  -> number of the individuals selected.
 * @param A1			-> the maximum number of individuals in the roulette wheel (aprox).
 * @param A2 			-> the minimum number of individuals in the roulette wheel (aprox).
 * @param B1 	 		-> the start scope in the population, i.e. 1 the selection will start in the second individual
 * @param B2	 		-> the end scope in the population, i.e. the size of the population: the las individuals (worst) will be included.
 * @param s				-> the decay of the curve. 0 < s < 1 (See RouletteWheelSigmoidalEngine.pde).
 * @return float[][] population.
 * 
 * 
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="sizeRoulette"></param>
        /// <param name="A1"></param>
        /// <param name="A2"></param>
        /// <param name="B1"></param>
        /// <param name="B2"></param>
        /// <param name="s"></param>
        /// <returns></returns>
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

        /**
  * TournamentSelection method.
  * select a number of indiviudals trough a tournament selection.
  * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
  * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
  * This method return a new population and can be bigger than the original size.
  * in the TorunamentSelection method is not necessary a sorted population.
  * 
  * @param srtPopulation -> a population.
  * @param resutls		-> the array of results from the evaluation in float[] flavor.
  * @param numbTour 		-> the quantity of tournaments, any integer.
  * @param preasure 	 	-> number of individuals in the competition.
  * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
  * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
  * @return double[][] population.
  * 
  * 
  */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="numbTour"></param>
        /// <param name="preasure"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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

        /**
 * TournamentSelection method.
 * select a number of indiviudals trough a tournament selection.
 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
 * This method return a new population and can be bigger than the original size.
 * in the TorunamentSelection method is not necessary a sorted population.
 * 
 * @param srtPopulation -> a population.
 * @param resutls		-> the array of results from the evaluation in int[] flavor.
 * @param numbTour 		-> the quantity of tournaments, any integer.
 * @param preasure 	 	-> number of individuals in the competition.
 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
 * @return double[][] population.
 * 
 * 
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="numbTour"></param>
        /// <param name="preasure"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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
        double[] Tournament(double[][] torneo, float[] results, String type)
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
        double[] Tournament(double[][] torneo, int[] results, String type)
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


        //////////////////////////FLOAT/////////////////////////////////////
        /**
         * ElitismSelection method.
         * select the number of the best indiviudals in the population.
         *
         * @param srtPopulation -> a sorted population by any sort algorithm.
         * @param count         -> quantity of individuals selected for the next generation.
         * @return float[][] population.
         * 
         * 
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="count"></param>
        /// <returns></returns>
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

        /**
 * RouletteWheel method.
 * select a number of individuals depending of their ranking in the population.
 * the best ranked individuals have more chance to be selected than worst. 
 * All individuals in the population have the chance to be selected. This algorithm is based in a non-polinomic curve (y = 1/x).
 * 
 * @param srtPopulation -> a sorted population by any sort algorithm.
 * @param results 		-> the array of results from the evaluation in int[] flavour
 * @param maxItem 		-> the maxItem is the maximum number of selected individuals in the roulette wheel.
 * @return float[][] population.
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="maxItem"></param>
        /// <returns></returns>
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

        /**
 * RouletteWheel method.
 * select a number of individuals depending of their ranking in the population.
 * the best ranked individuals have more chance to be selected than worst. 
 * All individuals in the population have the chance to be selected. This algorithm is based in a non-polinomic curve (y = 1/x).
 * 
 * @param srtPopulation -> a sorted population by any sort algorithm.
 * @param results 		-> the array of results from the evaluation in int[] flavour
 * @param maxItem 		-> the maxItem is the maximum number of selected individuals in the roulette wheel.
 * @return float[][] population.
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="maxItem"></param>
        /// <returns></returns>
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

        /**
 * RouletteWheelSigmoidal method.
 * select a number of indiviudals depending of their ranking in the population.
 * the best ranked individuals have more chance to be selected thant worst. 
 * Although all the individuals has a chance to be selected. the roulette wheel is based in sigmoidal curve, (See RouletteWheelSigmoidalEngine.pde).
 * 
 * @param srtPopulation -> a sorted population by any sort algorithm.
 * @param sizeRoulette  -> number of the individuals selected.
 * @param A1			-> the maximum number of individuals in the roulette wheel (aprox).
 * @param A2 			-> the minimum number of individuals in the roulette wheel (aprox).
 * @param B1 	 		-> the start scope in the population, i.e. 1 the selection will start in the second individual
 * @param B2	 		-> the end scope in the population, i.e. the size of the population: the las individuals (worst) will be included.
 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
 * @return float[][] population.
 * 
 * 
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="sizeRoulette"></param>
        /// <param name="A1"></param>
        /// <param name="A2"></param>
        /// <param name="B1"></param>
        /// <param name="B2"></param>
        /// <param name="s"></param>
        /// <returns></returns>
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

        /**
 * TournamentSelection method.
 * select a number of indiviudals trough a tournament selection.
 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
 * This method return a new population and can be bigger than the original size.
 * in the TorunamentSelection method is not necessary a sorted population.
 * 
 * @param srtPopulation -> a population.
 * @param resutls		-> the array of results from the evaluation in float[] flavor.
 * @param numbTour 		-> the quantity of tournaments, any integer.
 * @param preasure 	 	-> number of individuals in the competition.
 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
 * @return float[][] population.
 * 
 * 
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="numbTour"></param>
        /// <param name="preasure"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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

        /**
 * TournamentSelection method.
 * select a number of indiviudals trough a tournament selection.
 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
 * This method return a new population and can be bigger than the original size.
 * in the TorunamentSelection method is not necessary a sorted population.
 * 
 * @param srtPopulation -> a population.
 * @param resutls		-> the array of results from the evaluation in int[] flavor.
 * @param numbTour 		-> the quantity of tournaments, any integer.
 * @param preasure 	 	-> number of individuals in the competition.
 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
 * @return float[][] population.
 * 
 * 
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="numbTour"></param>
        /// <param name="preasure"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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
        float[] Tournament(float[][] torneo, float[] results, String type)
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
        float[] Tournament(float[][] torneo, int[] results, String type)
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

        //////////////////////////INTEGER/////////////////////////////////////
        /**
         * ElitismSelection method.
         * select the number of the best indiviudals in the population.
         *
         * @param srtPopulation -> a sorted population by any sort algorithm.
         * @param count         -> quantity of individuals selected for the next generation.
         * @return int[][] population.
         * 
         * 
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="count"></param>
        /// <returns></returns>
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

        /**
 * RouletteWheel method.
 * select a number of individuals depending of their ranking in the population.
 * the best ranked individuals have more chance to be selected than worst. 
 * All individuals in the population have the chance to be selected. This algorithm is based in a non-polinomic curve (y = 1/x).
 * 
 * @param srtPopulation -> a sorted population by any sort algorithm.
 * @param results 		-> the array of results from the evaluation in int[] flavour
 * @param maxItem 		-> the maxItem is the maximum number of selected individuals in the roulette wheel.
 * @return int[][] population.
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="maxItem"></param>
        /// <returns></returns>
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

                /**
         * RouletteWheel method.
         * select a number of individuals depending of their ranking in the population.
         * the best ranked individuals have more chance to be selected than worst. 
         * All individuals in the population have the chance to be selected. This algorithm is based in a non-polinomic curve (y = 1/x).
         * 
         * @param srtPopulation -> a sorted population by any sort algorithm.
         * @param results 		-> the array of results from the evaluation in int[] flavour
         * @param maxItem 		-> the maxItem is the maximum number of selected individuals in the roulette wheel.
         * @return int[][] population.
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="maxItem"></param>
        /// <returns></returns>
        public int[][] RouletteWheel(int[][] srtPopulation, int[] results, int maxItem)
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

        /**
 * RouletteWheelSigmoidal method.
 * select a number of indiviudals depending of their ranking in the population.
 * the best ranked individuals have more chance to be selected thant worst. 
 * Although all the individuals has a chance to be selected. the roulette wheel is based in sigmoidal curve, (See RouletteWheelSigmoidalEngine.pde).
 * 
 * @param srtPopulation -> a sorted population by any sort algorithm.
 * @param sizeRoulette  -> number of the individuals selected.
 * @param A1			-> the maximum number of individuals in the roulette wheel (aprox).
 * @param A2 			-> the minimum number of individuals in the roulette wheel (aprox).
 * @param B1 	 		-> the start scope in the population, i.e. 1 the selection will start in the second individual
 * @param B2	 		-> the end scope in the population, i.e. the size of the population: the las individuals (worst) will be included.
 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
 * @return int[][] population.
 * 
 * 
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="sizeRoulette"></param>
        /// <param name="A1"></param>
        /// <param name="A2"></param>
        /// <param name="B1"></param>
        /// <param name="B2"></param>
        /// <param name="s"></param>
        /// <returns></returns>
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

        /**
 * TournamentSelection method.
 * select a number of indiviudals trough a tournament selection.
 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
 * This method return a new population and can be bigger than the original size.
 * in the TorunamentSelection method is not necessary a sorted population.
 * 
 * @param srtPopulation -> a population.
 * @param resutls		-> the array of results from the evaluation in float[] flavor.
 * @param numbTour 		-> the quantity of tournaments, any integer.
 * @param preasure 	 	-> number of individuals in the competition.
 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
 * @return int[][] population.
 * 
 * 
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="numbTour"></param>
        /// <param name="preasure"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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

        /**
 * TournamentSelection method.
 * select a number of individuals trough a tournament selection.
 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
 * An interest parameter is the pressure: as bigger value is, best individuals will be selected.
 * This method return a new population and can be bigger than the original size.
 * in the TorunamentSelection method is not necessary a sorted population.
 * 
 * @param srtPopulation -> a population.
 * @param resutls		-> the array of results from the evaluation in int[] flavour.
 * @param numbTour 		-> the quantity of tournaments, any integer.
 * @param preasure 	 	-> number of individuals in the competition.
 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
 * @return int[][] population.
 * 
 * 
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="numbTour"></param>
        /// <param name="preasure"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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
        int[] Tournament(int[][] torneo, float[] results, String type)
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
        int[] Tournament(int[][] torneo, int[] results, String type)
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

        //////////////////////////CHARACTER///////////////////////////////////
        /**
         * ElitismSelection method.
         * select the number of the best indiviudals in the population.
         *
         * @param srtPopulation -> a sorted population by any sort algorithm.
         * @param count         -> quantity of individuals selected for the next generation.
         * @return char[][] population.
         * 
         * 
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="count"></param>
        /// <returns></returns>
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

        /**
 * RouletteWheel method.
 * select a number of individuals depending of their ranking in the population.
 * the best ranked individuals have more chance to be selected than worst. 
 * All individuals in the population have the chance to be selected. This algorithm is based in a non-polinomic curve (y = 1/x).
 * 
 * @param srtPopulation -> a sorted population by any sort algorithm.
 * @param results 		-> the array of results from the evaluation in int[] flavour
 * @param maxItem 		-> the maxItem is the maximum number of selected individuals in the roulette wheel.
 * @return char[][] population.
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="maxItem"></param>
        /// <returns></returns>
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

        /**
 * RouletteWheel method.
 * select a number of individuals depending of their ranking in the population.
 * the best ranked individuals have more chance to be selected than worst. 
 * All individuals in the population have the chance to be selected. This algorithm is based in a non-polinomic curve (y = 1/x).
 * 
 * @param srtPopulation -> a sorted population by any sort algorithm.
 * @param results 		-> the array of results from the evaluation in int[] flavour
 * @param maxItem 		-> the maxItem is the maximum number of selected individuals in the roulette wheel.
 * @return char[][] population.
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="maxItem"></param>
        /// <returns></returns>
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

        /**
 * RouletteWheelSigmoidal method.
 * select a number of indiviudals depending of their ranking in the population.
 * the best ranked individuals have more chance to be selected thant worst. 
 * Although all the individuals has a chance to be selected. the roulette wheel is based in sigmoidal curve, (See RouletteWheelSigmoidalEngine.pde).
 * 
 * @param srtPopulation -> a sorted population by any sort algorithm.
 * @param sizeRoulette  -> number of the individuals selected.
 * @param A1			-> the maximum number of individuals in the roulette wheel (aprox).
 * @param A2 			-> the minimum number of individuals in the roulette wheel (aprox).
 * @param B1 	 		-> the start scope in the population, i.e. 1 the selection will start in the second individual
 * @param B2	 		-> the end scope in the population, i.e. the size of the population: the las individuals (worst) will be included.
 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
 * @return char[][] population.
 * 
 * 
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="sizeRoulette"></param>
        /// <param name="A1"></param>
        /// <param name="A2"></param>
        /// <param name="B1"></param>
        /// <param name="B2"></param>
        /// <param name="s"></param>
        /// <returns></returns>
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

        /**
 * TournamentSelection method.
 * select a number of indiviudals trough a tournament selection.
 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
 * This method return a new population and can be bigger than the original size.
 * in the TorunamentSelection method is not necessary a sorted population.
 * 
 * @param srtPopulation -> a population.
 * @param resutls		-> the array of results from the evaluation in float[] flavor.
 * @param numbTour 		-> the quantity of tournaments, any integer.
 * @param preasure 	 	-> number of individuals in the competition.
 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
 * @return char[][] population.
 * 
 * 
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="numbTour"></param>
        /// <param name="preasure"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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

        /**
 * TournamentSelection method.
 * select a number of indiviudals trough a tournament selection.
 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
 * This method return a new population and can be bigger than the original size.
 * in the TorunamentSelection method is not necessary a sorted population.
 * 
 * @param srtPopulation -> a population.
 * @param resutls		-> the array of results from the evaluation in int[] flavor.
 * @param numbTour 		-> the quantity of tournaments, any integer.
 * @param preasure 	 	-> number of individuals in the competition.
 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
 * @return char[][] population.
 * 
 * 
 */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srtPopulation"></param>
        /// <param name="results"></param>
        /// <param name="numbTour"></param>
        /// <param name="preasure"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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
    }
}