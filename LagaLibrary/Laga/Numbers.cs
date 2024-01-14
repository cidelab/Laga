using Laga.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Laga.Numbers
{
    /// <summary>
    /// Range for numbers
    /// </summary>
    readonly public struct Range
    {
       readonly private double min, max;

        /// <summary>
        /// Get the max value
        /// </summary>
        public double Max
        { get { return max; } }

        /// <summary>
        /// Get the min value
        /// </summary>
        public double Min
        { get { return min; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="End"></param>
       public Range(double Start, double End)
        {
            min = Start;
            max = End;
        }
    }
    /// <summary>
    /// famouse Maths functions
    /// </summary>
    public class Function
    {
        /// <summary>
        /// 3X + 1 function
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
                    Sequence /= 2;
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
        /// Sigmoid activation function
        /// </summary>
        /// <param name="t">param to evaluate</param>
        /// <returns>the param map</returns>
        public static float Sigmoid(float t)
        {
            float k = (float)Math.Exp(t);
            return k / (1.0f + k);
        }

        /// <summary>
        /// Sigmoid simulation function
        /// </summary>
        /// <param name="t">param to evaluate</param>
        /// <param name="A1">The initial value</param>
        /// <param name="A2">The final value</param>
        /// <param name="B1">The initial scope value</param>
        /// <param name="B2">The final scope value</param>
        /// <param name="decay">factor decay</param>
        /// <returns>the param map</returns>
        public static double Sigmoid(double t, double A1, double A2, double B1, double B2, double decay)
        {
            return A1 + (A2 - A1) / (1 + Math.Exp(Math.Log(1 / decay - 1) * (B1 + B2 - 2 * t) / (B2 - B1)));
        }

        /// <summary>
        /// Sigmoid sumulation function
        /// </summary>
        /// <param name="t">param to evaluate</param>
        /// <param name="A1">The initial value</param>
        /// <param name="A2">The final value</param>
        /// <param name="B1">The initial scope value</param>
        /// <param name="B2">The final scope value</param>
        /// <param name="decay">factor decay</param>
        /// <returns>the param map</returns>
        public static float Sigmoid(float t, float A1, float A2, float B1, float B2, float decay)
        {
            return A1 + (A2 - A1) / (1 + (float)Math.Exp(Math.Log(1 / decay - 1) * (B1 + B2 - 2 * t) / (B2 - B1)));
        }

        /// <summary>
        /// Flower Spiral
        /// </summary>
        /// <param name="range"></param>
        /// <param name="span"></param>
        /// <param name="radOne"></param>
        /// <param name="radTwo"></param>
        /// <param name="radThree"></param>
        /// <returns></returns>
        public static Vector[] Flower(int range = 100, float span = 0.1f, float radOne = 8f, float radTwo = 6f, float radThree = 3f)
        {
            int size = (int)(range / span);
            Vector[] ret = new Vector[size];
            int count = 0;
            for(float i = 0; i < range; i += span)
            {
                Vector v = new Vector
                {
                    X = radOne * Math.Cos(i) - radTwo * (Math.Cos((radOne * i) / radThree)),
                    Y = radOne * Math.Sin(i) - radTwo * (Math.Sin((radOne * i) / radThree))
                };
                ret[count] = v;
                count++;
            }

            return ret;
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
