using System;
using System.Collections.Generic;
using System.Text;

namespace Laga
{
    public class Crossover
    {
        Random rnd;
        LagaTools lt;

        public Crossover()
        {
            rnd = new Random();
            lt = new LagaTools();
        }

        /// <summary>
        /// Single Point Crossover method
        /// </summary>
        /// <param name="population">The population to perform the crossover.</param>
        /// <param name="percent">The percent to crossover between 0.00 and 1.00</param>
        /// <param name="pointCutter">The integer to split the chromosome</param>
        /// <returns>Crossover Object[][]</returns>
        public object[][] SinglePointCrossover(object[][] population, float percent, int pointCutter)
        {
            int popLength = population.Length;
            int[] arrIndex = lt.Mom_Dad(popLength, percent); 
            int iLength = arrIndex.Length;

            object[] dad;
            object[] mom;
            object[] son1;
            object[] son2;

            object[][] inherencePop = new object[iLength][];

            //clone the array.
            object[][] crossPop = new object[popLength][];
            int dadLength;

            for (int i = 0; i < popLength; i++)
            {
                dadLength = population[i].Length;
                crossPop[i] = new object[dadLength];
                Array.Copy(population[i], crossPop[i], dadLength);
            }

            for (int i = 0; i < iLength - 1; i += 2)
            {
                dad = crossPop[arrIndex[i]];
                mom = crossPop[arrIndex[i + 1]];
                son1 = new object[dad.Length];
                son2 = new object[mom.Length];

                int t = pointCutter;
                int t2 = pointCutter;

                for (int j = 0; j < pointCutter; ++j)
                {
                    son1[j] = dad[j];
                    son2[j] = mom[j];
                }

                for (int j = 0; j < mom.Length; ++j)
                {
                    for (int k = pointCutter; k < dad.Length; ++k)
                    {
                        if (mom[j] == dad[k])
                        {
                            son1[t] = mom[j];
                            t++;
                        }
                    }
                }

                for (int j = 0; j < dad.Length; ++j)
                {
                    for (int k = pointCutter; k < mom.Length; ++k)
                    {
                        if (dad[j] == mom[k])
                        {
                            son2[t2] = dad[j];
                            t2++;
                        }
                    }
                }
                inherencePop[i] = son1;
                inherencePop[i + 1] = son2;
            }
            return inherencePop;
        }

       
        public double[][] SinglePointCrossover(double[][] population, float percent, int pointCutter)
        {
            int popLength = population.Length;
            int[] arrIndex = lt.Mom_Dad(popLength, percent);
            int iLength = arrIndex.Length;

            double[] dad;
            double[] mom;
            double[] son1;
            double[] son2;

            double[][] inherencePop = new double[iLength][];

            //clone the array.
            double[][] crossPop = new double[popLength][];
            for (int i = 0; i < popLength; i++)
            {
                crossPop[i] = new double[population[i].Length];
                Array.Copy(population[i], 0, crossPop[i], 0, population[i].Length);
            }

            for (int i = 0; i < arrIndex.Length - 1; i += 2)
            {
                dad = crossPop[arrIndex[i]];
                mom = crossPop[arrIndex[i + 1]];
                son1 = new double[dad.Length];
                son2 = new double[mom.Length];

                for (int j = 0; j < pointCutter; ++j)
                {
                    son1[j] = dad[j];
                    son2[j] = mom[j];
                }

                for (int k = pointCutter; k < dad.Length; ++k)
                {
                    son1[k] = mom[k];
                    son2[k] = dad[k];
                }

                inherencePop[i] = son1;
                inherencePop[i + 1] = son2;
            }
            return inherencePop;
        }

        /*
       public float[][] SinglePointCrossover(float[][] population, float percent, int pointCutter)
       {
           SelectDadMom(population, percent); //call the method to determine who with who is going to have sex. 
           float[] dad;
           float[] mom;
           float[] son1;
           float[] son2;

           float[][] inherencePop = new float[arrIndex.length][];

           //clone the array.
           float[][] crossPop = new float[population.length][];
           for (int i = 0; i < population.length; i++)
           {
               crossPop[i] = new float[population[i].length];
               System.arraycopy(population[i], 0, crossPop[i], 0, population[i].length);
           }

           for (int i = 0; i < arrIndex.length - 1; i += 2)
           {
               dad = crossPop[arrIndex[i]];
               mom = crossPop[arrIndex[i + 1]];
               son1 = new float[dad.length];
               son2 = new float[mom.length];

               for (int j = 0; j < pointCutter; ++j)
               {
                   son1[j] = dad[j];
                   son2[j] = mom[j];
               }

               for (int k = pointCutter; k < dad.length; ++k)
               {
                   son1[k] = mom[k];
                   son2[k] = dad[k];
               }

               inherencePop[i] = son1;
               inherencePop[i + 1] = son2;
           }
           return inherencePop;
       }


       public int[][] SinglePointCrossover(int[][] population, float percent, int pointCutter)
       {
           SelectDadMom(population, percent); //call the method to determine who with who is going to have sex. 
           int[] dad;
           int[] mom;
           int[] son1;
           int[] son2;

           int[][] inherencePop = new int[arrIndex.length][];

           //clone the array.
           int[][] crossPop = new int[population.length][];
           for (int i = 0; i < population.length; i++)
           {
               crossPop[i] = new int[population[i].length];
               System.arraycopy(population[i], 0, crossPop[i], 0, population[i].length);
           }

           for (int i = 0; i < arrIndex.length - 1; i += 2)
           {
               dad = crossPop[arrIndex[i]];
               mom = crossPop[arrIndex[i + 1]];
               son1 = new int[dad.length];
               son2 = new int[mom.length];

               for (int j = 0; j < pointCutter; ++j)
               {
                   son1[j] = dad[j];
                   son2[j] = mom[j];
               }

               for (int k = pointCutter; k < dad.length; ++k)
               {
                   son1[k] = mom[k];
                   son2[k] = dad[k];
               }

               inherencePop[i] = son1;
               inherencePop[i + 1] = son2;
           }
           return inherencePop;
       }


       public char[][] SinglePointCrossover(char[][] population, float percent, int pointCutter)
       {
           SelectDadMom(population, percent); //call the method to determine who with who is going to have sex. 

           char[][] inherencePop = new char[arrIndex.length][];
           int count = 0;

           //clone the array.
           char[][] crossPop = new char[population.length][];
           for (int i = 0; i < population.length; i++)
           {
               crossPop[i] = new char[population[i].length];
               System.arraycopy(population[i], 0, crossPop[i], 0, population[i].length);
           }

           for (int i = 0; i < arrIndex.length - 1; i += 2)
           {

               char[] dad = crossPop[arrIndex[i]];
               char[] mom = crossPop[arrIndex[i + 1]];

               char[] son1 = new char[dad.length];
               char[] son2 = new char[mom.length];

               for (int j = 0; j < pointCutter; ++j)
               {
                   son1[j] = dad[j];
                   son2[j] = mom[j];
               }

               for (int k = pointCutter; k < dad.length; ++k)
               {
                   son1[k] = mom[k];
                   son2[k] = dad[k];
               }

               inherencePop[count] = son1;
               inherencePop[count + 1] = son2;

               count += 2;
           }
           return inherencePop;
       }
*/
    }

}
