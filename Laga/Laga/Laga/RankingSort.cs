using System;
using System.Collections.Generic;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    public class RankingSort
    {
        //LagaCasting lc = new LagaCasting();

        private object[][] objPopulation;
        private double[][] dblPopulation;
        private float[][] fltPopulation;
        private int[][] intPopulation;
        private char[][] srtPopulation;
        private float[] fltArrResults;
        private int[] intArrResults;

        public RankingSort()
        {

        }
        /**
	 *An optimised BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
        public void BidirectionalBubbleSort(object[][] population, float[] arrResults, bool minmax)
        {
            int j;
            int st = -1;
            int n = arrResults.Length;

            while (st < n)
            {
                st++;
                n--;

                for (j = st; j < n; j++)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        float T = arrResults[j];
                        object[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
                for (j = n; --j >= st;)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        float T = arrResults[j];
                        object[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
            }

            if (minmax)
            {
                LagaTools.Reverse(arrResults);
                LagaTools.ReversePopulation(population);
            }

            objPopulation = population;
            fltArrResults = arrResults;
        }
        /**
         *An optimised BidirectionalBubbleSort method.
         * Sort the individuals in the population by fitness value.
         * 
         * @param population -> population to sort;
         * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
         * @param minmax 	 -> if is true the sort is by min to max, else max to min.
         * @return automatically the population is sorted updated. the original population will be modified.
         * 
         * 
         */
        public void BidirectionalBubbleSort(object[][] population, int[] arrResults, bool minmax)
        {
            int j;
            int st = -1;
            int n = arrResults.Length;

            while (st < n)
            {
                st++;
                n--;

                for (j = st; j < n; j++)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        int T = arrResults[j];
                        object[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
                for (j = n; --j >= st;)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        int T = arrResults[j];
                        object[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
            }

            if (minmax)
            {
                LagaTools.Reverse(arrResults);
                LagaTools.ReversePopulation(population);
            }

            objPopulation = population;
            intArrResults = arrResults;
        }
        /**
         *An optimised BidirectionalBubbleSort method.
         * Sort the individuals in the population by fitness value.
         * 
         * @param population -> population to sort;
         * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
         * @param minmax 	 -> if is true the sort is by min to max, else max to min.
         * @return automatically the population is sorted updated. the original population will be modified.
         * 
         * 
         */
        public void BidirectionalBubbleSort(double[][] population, float[] arrResults, bool minmax)
        {
            int j;
            int st = -1;
            int n = arrResults.Length;

            while (st < n)
            {
                st++;
                n--;

                for (j = st; j < n; j++)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        float T = arrResults[j];
                        double[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
                for (j = n; --j >= st;)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        float T = arrResults[j];
                        double[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
            }

            if (minmax)
            {
                LagaTools.Reverse(arrResults);
                LagaTools.ReversePopulation(population);
            }

            dblPopulation = population;
            fltArrResults = arrResults;
        }
        /**
         *An optimised BidirectionalBubbleSort method.
         * Sort the individuals in the population by fitness value.
         * 
         * @param population -> population to sort;
         * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
         * @param minmax 	 -> if is true the sort is by min to max, else max to min.
         * @return automatically the population is sorted updated. the original population will be modified.
         * 
         * 
         */
        public void BidirectionalBubbleSort(double[][] population, int[] arrResults, bool minmax)
        {
            int j;
            int st = -1;
            int n = arrResults.Length;


            while (st < n)
            {
                st++;
                n--;

                for (j = st; j < n; j++)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        int T = arrResults[j];
                        double[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
                for (j = n; --j >= st;)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        int T = arrResults[j];
                        double[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
            }

            if (minmax)
            {
                LagaTools.Reverse(arrResults);
                LagaTools.ReversePopulation(population);
            }

            dblPopulation = population;
            intArrResults = arrResults;

        }
        /**
         *An optimised BidirectionalBubbleSort method.
         * Sort the individuals in the population by fitness value.
         * 
         * @param population -> population to sort;
         * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
         * @param minmax 	 -> if is true the sort is by min to max, else max to min.
         * @return automatically the population is sorted updated. the original population will be modified.
         * 
         * 
         */
        public void BidirectionalBubbleSort(float[][] population, float[] arrResults, bool minmax)
        {
            int j;
            int st = -1;
            int n = arrResults.Length;

            while (st < n)
            {
                st++;
                n--;

                for (j = st; j < n; j++)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        float T = arrResults[j];
                        float[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
                for (j = n; --j >= st;)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        float T = arrResults[j];
                        float[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
            }

            if (minmax)
            {
                LagaTools.Reverse(arrResults);
                LagaTools.ReversePopulation(population);
            }

            fltPopulation = population;
            fltArrResults = arrResults;
        }
        /**
         *An optimised BidirectionalBubbleSort method.
         * Sort the individuals in the population by fitness value.
         * 
         * @param population -> population to sort;
         * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
         * @param minmax 	 -> if is true the sort is by min to max, else max to min.
         * @return automatically the population is sorted updated. the original population will be modified.
         * 
         * 
         */
        public void BidirectionalBubbleSort(float[][] population, int[] arrResults, bool minmax)
        {
            int j;
            int st = -1;
            int n = arrResults.Length;

            while (st < n)
            {
                st++;
                n--;

                for (j = st; j < n; j++)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        int T = arrResults[j];
                        float[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
                for (j = n; --j >= st;)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        int T = arrResults[j];
                        float[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
            }

            if (minmax)
            {
                LagaTools.Reverse(arrResults);
                LagaTools.ReversePopulation(population);
            }

            fltPopulation = population;
            intArrResults = arrResults;
        }
        /**
         *An optimised BidirectionalBubbleSort method.
         * Sort the individuals in the population by fitness value.
         * 
         * @param population -> population to sort;
         * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
         * @param minmax 	 -> if is true the sort is by min to max, else max to min.
         * @return automatically the population is sorted updated. the original population will be modified.
         * 
         * 
         */
        public void BidirectionalBubbleSort(int[][] population, float[] arrResults, bool minmax)
        {
            int j;
            int st = -1;
            int n = arrResults.Length;

            while (st < n)
            {
                st++;
                n--;

                for (j = st; j < n; j++)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        float T = arrResults[j];
                        int[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
                for (j = n; --j >= st;)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        float T = arrResults[j];
                        int[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
            }

            if (minmax)
            {
                LagaTools.Reverse(arrResults);
                LagaTools.ReversePopulation(population);
            }

            intPopulation = population;
            fltArrResults = arrResults;
        }
        /**
         *An optimised BidirectionalBubbleSort method.
         * Sort the individuals in the population by fitness value.
         * 
         * @param population -> population to sort;
         * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
         * @param minmax 	 -> if is true the sort is by min to max, else max to min.
         * @return automatically the population is sorted updated. the original population will be modified.
         * 
         * 
         */
        public void BidirectionalBubbleSort(int[][] population, int[] arrResults, bool minmax)
        {
            int j;
            int st = -1;
            int n = arrResults.Length;

            while (st < n)
            {
                st++;
                n--;

                for (j = st; j < n; j++)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        int T = arrResults[j];
                        int[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
                for (j = n; --j >= st;)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        int T = arrResults[j];
                        int[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
            }

            if (minmax)
            {
                LagaTools.Reverse(arrResults);
                LagaTools.ReversePopulation(population);
            }

            intPopulation = population;
            intArrResults = arrResults;
        }
        /**
         *An optimised BidirectionalBubbleSort method.
         * Sort the individuals in the population by fitness value.
         * 
         * @param population -> population to sort;
         * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
         * @param minmax 	 -> if is false the sort is by min to max, true max to min.
         * @return automatically the population sorted is updated. the original population will be modified.
         * 
         * 
         */
        public void BidirectionalBubbleSort(char[][] population, float[] arrResults, bool minmax)
        {
            int j;
            int st = -1;
            int n = arrResults.Length;

            while (st < n)
            {
                st++;
                n--;

                for (j = st; j < n; j++)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        float T = arrResults[j];
                        char[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
                for (j = n; --j >= st;)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        float T = arrResults[j];
                        char[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
            }

            if (minmax)
            {
                LagaTools.Reverse(arrResults);
                LagaTools.ReversePopulation(population);
            }
            srtPopulation = population;
            fltArrResults = arrResults;
        }

        /**
         *An optimised BidirectionalBubbleSort method.
         * Sort the individuals in the population by fitness value.
         * 
         * @param population -> population to sort;
         * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
         * @param minmax 	 -> if is true the sort is by min to max, else max to min.
         * @return automatically the population is sorted updated. the original population will be modified.
         * 
         * 
         */
        public void BidirectionalBubbleSort(char[][] population, int[] arrResults, bool minmax)
        {
            int j;
            int st = -1;
            int n = arrResults.Length;

            while (st < n)
            {
                st++;
                n--;

                for (j = st; j < n; j++)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        int T = arrResults[j];
                        char[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
                for (j = n; --j >= st;)
                {
                    if (arrResults[j] > arrResults[j + 1])
                    {
                        int T = arrResults[j];
                        char[] temp = population[j];
                        arrResults[j] = arrResults[j + 1];
                        population[j] = population[j + 1];
                        arrResults[j + 1] = T;
                        population[j + 1] = temp;
                    }
                }
            }

            if (minmax)
            {
                LagaTools.Reverse(arrResults);
                LagaTools.ReversePopulation(population);
            }

            srtPopulation = population;
            intArrResults = arrResults;
        }

    }
}
