﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.Numbers
{
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
