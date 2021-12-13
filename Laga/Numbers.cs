using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.Numbers
{
    /// <summary>
    /// Mathematics and statistics operations
    /// </summary>
    public class Numbers
    {
        /// <summary>
        /// 3X + 1 sequence
        /// From the book: The modern C# Challenge
        /// </summary>
        /// <param name="Sequence">the number to begin the sequence</param>
        public static List<int> ThreeXplusOne(int Sequence)
        {
            List<int> lstH = new List<int>();
            while( Sequence != 1)
            {
                lstH.Add(Sequence);
                if (Sequence % 2 == 0)
                    Sequence = Sequence / 2;
                else
                    Sequence = 3 * Sequence + 1;
            }
            lstH.Add(1);
            return lstH;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lstData"></param>
        /// <returns></returns>
        public static List<T> NumberDistinct<T>(List<T> lstData)
        {
            return lstData.Distinct().ToList();
        }

        /// <summary>
        /// Degrees to Radians
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns>double</returns>
        public static double Deg2Rad(double degrees)
        {
            double radians = (Math.PI / 180.0) * degrees;
            return (radians);
        }

        /// <summary>
        /// Radians to Degree
        /// </summary>
        /// <param name="radians"></param>
        /// <returns>double</returns>
        public static double Rad2Deg(double radians)
        {
            double degrees = (180.0 / Math.PI) * radians;
            return (degrees);
        }
    }
}
