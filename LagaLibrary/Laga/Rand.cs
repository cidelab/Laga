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
        /// Generate random numbers
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="size">number of random values</param>
        /// <param name="min">The minimum value in the range</param>
        /// <param name="max">The maximum value in the range</param>
        /// <returns>a list of random values</returns>
        public static T[] Numbers<T>(int size, T min, T max) where T : struct, IComparable
        {
            T[] arrN = new T[size];
            for (int i = 0; i < size; i++)
            {
                dynamic minVal = min;
                dynamic maxVal = max;
                arrN[i] = minVal + (T)(rnd.Value.NextDouble() * (maxVal - minVal));
            }
            return arrN;
        }

        /// <summary>
        ///  Generates a random a random integer between a range
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
        public static double DblNumber()
        {
            return rnd.Value.NextDouble();
        }

        /// <summary>
        /// Generates a random double between min and max
        /// </summary>
        /// <param name="min">The minimum value in the range</param>
        /// <param name="max">The maximum value in the range</param>
        /// <returns>double</returns>
        public static double NextDouble(double min, double max)
        {
            return min + rnd.Value.NextDouble() * (max - min);
        }

        /// <summary>
        ///  Generates a random float Number between a range
        /// </summary>
        /// <param name="min">The minimum value in the range</param>
        /// <param name="max">The maximum value in the range</param>
        /// <returns>float</returns>
        public static float NextFloat(float min, float max)
        {
            return min + (float)rnd.Value.NextDouble() * (max - min);
        }

        /// <summary>
        /// Generates a random character
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static char Character(int start, int end)
        {
            if (start < 0 || end > 255 || start > end)
                throw new ArgumentOutOfRangeException("Character range is invalid.");

            return (char)rnd.Value.Next(start, end);
        }
    }
}
