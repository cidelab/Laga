using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Laga.GeneticAlgorithm;

namespace Laga.Numbers
{
    /// <summary>
    /// Random number class
    /// </summary>
    public class Rand
    {
        private static readonly ThreadLocal<Random> rnd = new ThreadLocal<Random>(() => new Random());

        /// <summary>
        /// Generate a list of Integers between min and max paremeters
        /// </summary>
        /// <param name="size">number of integers in the list</param>
        /// <param name="min">the min value</param>
        /// <param name="max">the max value</param>
        /// <returns>int[]</returns>
        public static int[] Integers(int size, int min, int max)
        {
            int[] arrN = new int[size];
            for (int i = 0; i < size; i++)
                arrN[i] = rnd.Value.Next(min, max);
            return arrN;
        }

        /// <summary>
        /// Generate a list of floats between min and max paremeters
        /// </summary>
        /// <param name="size">number of floats in the list</param>
        /// <param name="min">the min value</param>
        /// <param name="max">the max value</param>
        /// <returns>float[]</returns>
        public static float[] Floats(int size, float min, float max)
        {
            float[] arrN = new float[size];
            for (int i = 0; i < size; i++)
                arrN[i] = min + (float)rnd.Value.NextDouble() * (max - min);
            return arrN;
        }

        /// <summary>
        /// Generate a list of doubles between min and max paremeters
        /// </summary>
        /// <param name="size">number of doubles in the list</param>
        /// <param name="min">the min value</param>
        /// <param name="max">the max value</param>
        /// <returns></returns>
        public static double[] Doubles(int size, double min, double max)
        {
            double[] arrN = new double[size];
            for (int i = 0; i < size; i++)
                arrN[i] = min + rnd.Value.NextDouble() * (max - min);
            return arrN;
        }

        /// <summary>
        ///  Generates a random a random integer between min and max paremeters
        /// </summary>
        /// <param name="min">The minimum value in the range</param>
        /// <param name="max">The maximum value in the range</param>
        /// <returns>integer</returns> 
        public static int NextInt(int min, int max)
        {
            return rnd.Value.Next(min, max);
        }
        
        /// <summary>
        /// Random value between 0 and 1
        /// </summary>
        /// <returns>double</returns>
        public static double NextDouble()
        {
            return rnd.Value.NextDouble();
        }

        /// <summary>
        /// Generates a random double between min and max paremeters
        /// </summary>
        /// <param name="min">The minimum value in the range</param>
        /// <param name="max">The maximum value in the range</param>
        /// <returns>double</returns>
        public static double NextDouble(double min, double max)
        {
            return min + rnd.Value.NextDouble() * (max - min);
        }

        /// <summary>
        ///  Generates a random float Number between min and max paremeters
        /// </summary>
        /// <param name="min">The minimum value in the range</param>
        /// <param name="max">The maximum value in the range</param>
        /// <returns>float</returns>
        public static float NextFloat(float min, float max)
        {
            return min + (float)rnd.Value.NextDouble() * (max - min);
        }

        /// <summary>
        /// Generates a random character between min and max paremeters
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>char</returns>
        public static char NextChar(int start, int end)
        {
            if (start < 0 || end > 255 || start > end)
                throw new ArgumentOutOfRangeException("NextChar range is invalid.");

            return (char)rnd.Value.Next(start, end);
        }
    }
}
