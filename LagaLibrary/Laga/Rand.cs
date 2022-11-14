using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Laga.GeneticAlgorithm;

namespace Laga.Numbers
{
    /// <summary>
    /// Random number class
    /// </summary>
    public class Rand
    {
        private static readonly Random rnd = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Generate random numbers
        /// </summary>
        /// <param name="size">The amount of random values in the list</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>float[]</returns>
        public static float[] Numbers(int size, float min, float max)
        {
            Random rnd = new Random();

            float[] arrN = new float[size];
            for (int i = 0; i < size; i++)
                arrN[i] = min + (float)rnd.NextDouble() * (max - min);

            return arrN;
        }

        /// <summary>
        /// Generate random numbers
        /// </summary>
        /// <param name="size">The amount of random values in the list</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>double[]</returns>
        public static double[] Numbers(int size, double min, double max)
        {
            double[] arrN = new double[size];
            for (int i = 0; i < size; i++)
                arrN[i] = (min + (float)rnd.NextDouble() * (max - min));

            return arrN;
        }

        /// <summary>
        /// Random Integer between a range
        /// </summary>
        /// <param name="min">The minimum value in the range</param>
        /// <param name="max">The maximum value in the range</param>
        /// <returns>integer</returns>
        public static int IntNumber(int min, int max)
        {
            return min + (int)(rnd.NextDouble() * (max - min));
        }
        /// <summary>
        /// Random value between 0 and 1
        /// </summary>
        /// <returns>double</returns>
        public static double DblNumber()
        {
            return rnd.NextDouble();
        }

        /// <summary>
        /// Float Number between a range
        /// </summary>
        /// <param name="min">The minimum value in the range</param>
        /// <param name="max">The maximum value in the range</param>
        /// <returns>float</returns>
        public static float FltNumber(float min, float max)
        {
            return min + (float)DblNumber() * (max - min);
        }
    }
}
