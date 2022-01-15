using System;
using System.Collections.Generic;
using System.Linq;
using Laga.Geometry;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// A collection of methods to operate on Genetic operators and lists.
    /// </summary>
    public static class Tools
    {
       /// <summary>
       /// Creates a report based on a list of data.
       /// </summary>
       /// <param name="listValues">the Values used to create the report</param>
       /// <returns>List<string></string></returns>
        public static List<string> DataReport<T>(List<T> listValues)
        {
            listValues.Sort();
            var result = listValues.GroupBy(d => d).ToList();

            List<string> lstDtaFormat = new List<string>();

            int size;
            T CV;

            for (int i = 0; i < result.Count; i++)
            {
                size = result[i].Count();
                CV = result[i].ElementAt(0);

                lstDtaFormat.Add(CV.ToString() + ", " + size.ToString());
            }

            return lstDtaFormat;
        }
        /// <summary>
        /// Convert a binary chromosome to an integer, base of 2.
        /// </summary>
        /// <typeparam name="T">chromosome type</typeparam>
        /// <param name="chromosome">your chromosome</param>
        /// <returns>int</returns>
        public static int BinaryChromosomeToInteger<T>(this T[] chromosome)
        {
            string s = String.Join<T>("", chromosome);
            if(s == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(s, 2);
            }
        }

        /// <summary>
        /// Extract part of the DNA from a chromosome. 
        /// </summary>
        /// <typeparam name="T">Any chromosome type</typeparam>
        /// <param name="chromosome">the chromosome</param>
        /// <param name="index">start the extraction</param>
        /// <param name="length">length of the extraction</param>
        /// <returns>T[] A DNA segment from the original chromosome</returns>
        public static T[] ExtractDNA<T>(this T[] chromosome, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(chromosome, index, result, 0, length);
            return result;
        }

        /// <summary>
        /// Return the Min and Max values from an Array.
        /// </summary>
        /// <typeparam name="T">Any number type like: int, double, float...</typeparam>
        /// <param name="genArray">The array where to extract the values</param>
        /// <returns>Generic Array</returns>
        public static T[] MinMaxValue<T>(T[] genArray)
        {
            T[] ts = new T[2];
            ts[0] = genArray.Min<T>();
            ts[1] = genArray.Max<T>();

            return ts;
        }

        /// <summary>
        /// Reverse the original Population
        /// </summary>
        /// <param name="charPop">char[][]</param>
        public static void ReversePopulation(char[][] charPop)
        {
            char[] arrTempInd;
            for (int i = 0; i < charPop.Length / 2; i++)
            {
                arrTempInd = new char[charPop[i].Length];
                arrTempInd = charPop[i];
                charPop[i] = charPop[charPop.Length - i - 1];
                charPop[charPop.Length - i - 1] = arrTempInd;
            }
        }

        /// <summary>
        /// Generate prefixs.
        /// </summary>
        /// <param name="prefix">string prefix</param>
        /// <param name="size">the length of prefix to generate</param>
        /// <returns>string[]</returns>
        public static string[] Prefix(string prefix, int size)
        {
            string[] arrS = new string[size];
            for(int i = 0; i < size; i++)
            {
                arrS[i] = prefix + i.ToString();
            }

            return arrS;
        }

        /// <summary>
        /// Round the location of a laga point, based on the round number
        /// </summary>
        /// <param name="points">The points to round coordinates</param>
        /// <param name="round">round number coordinates</param>
        /// <returns>string[]</returns>
        public static string[] Parse(Vectord[] points, int round)
        {
            string[] arrPtsChromosome = new string[points.Length];
            double[] arrdblCoords;
            int i = 0;

            foreach (Vectord p in points)
            {
                arrdblCoords = new double[] {Math.Round(p.X, round), Math.Round(p.Y, round), Math.Round(p.Z, round)};
                string[] arrString = Array.ConvertAll(arrdblCoords, new Converter<double, string>(Convert.ToString));
                arrPtsChromosome[i] = string.Join(", ", arrString);
                i++;
            }
            return arrPtsChromosome;
        }

        /// <summary>
        /// Parse any Chromosome type to string Array
        /// </summary>
        /// <param name="any">double[]</param>
        /// <returns>string[]</returns>
        public static string[] Parse(double[] any)
        {
            string[] arrString = Array.ConvertAll(any, new Converter<double, string>(Convert.ToString));
            return arrString;
        }

        /// <summary>
        /// Parse a list of integers into a list of strings
        /// </summary>
        /// <param name="any">int[]</param>
        /// <returns>string[]</returns>
        public static string[] Parse(int[] any)
        {
            string[] arrString = Array.ConvertAll(any, new Converter<int, string>(Convert.ToString));
            return arrString;
        }

        /// <summary>
        /// Parse a list of floats into a list of strings
        /// </summary>
        /// <param name="any">float[]</param>
        /// <returns>string[]</returns>
        /// 
        public static string[] Parse(float[] any)
        {
            string[] arrString = Array.ConvertAll(any, new Converter<float, string>(Convert.ToString));
            return arrString;
        }

        /// <summary>
        /// Parse a list of char to a list of strings
        /// </summary>
        /// <param name="any">char[]</param>
        /// <returns>string[]</returns>
        public static string[] Parse(char[] any)
        {
            string[] arrString = Array.ConvertAll(any, new Converter<char, string>(Convert.ToString));
            return arrString;
        }

        /// <summary>
        /// Reverse the original array of floats.
        /// </summary>
        /// <param name="arrFloat">float[]</param>
        public static void Reverse(float[] arrFloat)
        {
            float temp;
            for (int i = 0; i < arrFloat.Length / 2; i++)
            {
                temp = arrFloat[i];
                arrFloat[i] = arrFloat[arrFloat.Length - i - 1];
                arrFloat[arrFloat.Length - i - 1] = temp;
            }
        }

        /// <summary>
        /// Reverse the original array of integers
        /// </summary>
        /// <param name="arrInt">int[]</param>
        public static void Reverse(int[] arrInt)
        {
            int temp;
            for (int i = 0; i < arrInt.Length / 2; i++)
            {
                temp = arrInt[i];
                arrInt[i] = arrInt[arrInt.Length - i - 1];
                arrInt[arrInt.Length - i - 1] = temp;
            }
        }

        /// <summary>
        /// Reverse the original array of doubles
        /// </summary>
        /// <param name="arrDbl">double[]</param>
        public static void Reverse(double[] arrDbl)
        {
            double temp;
            for (int i = 0; i < arrDbl.Length / 2; i++)
            {
                temp = arrDbl[i];
                arrDbl[i] = arrDbl[arrDbl.Length - i - 1];
                arrDbl[arrDbl.Length - i - 1] = temp;
            }
        }

        /// <summary>
        /// Reverse Original integer population
        /// </summary>
        /// <param name="intPop">int[][]</param>
        public static void ReversePopulation(int[][] intPop)
        {
            int[] temp;
            for (int i = 0; i < intPop.Length / 2; i++)
            {
                temp = intPop[i];
                intPop[i] = intPop[intPop.Length - i - 1];
                intPop[intPop.Length - i - 1] = temp;
            }
        }

        /// <summary>
        /// Reverse original double population
        /// </summary>
        /// <param name="dblPop">double[][]</param>
        public static void ReversePopulation(double[][] dblPop)
        {
            double[] temp;
            for (int i = 0; i < dblPop.Length / 2; i++)
            {
                temp = dblPop[i];
                dblPop[i] = dblPop[dblPop.Length - i - 1];
                dblPop[dblPop.Length - i - 1] = temp;
            }
        }

        /// <summary>
        /// Reverse original float population
        /// </summary>
        /// <param name="flPop">float[][]</param>
        public static void ReversePopulation(float[][] flPop)
        {
            float[] temp;
            for (int i = 0; i < flPop.Length / 2; i++)
            {
                temp = flPop[i];
                flPop[i] = flPop[flPop.Length - i - 1];
                flPop[flPop.Length - i - 1] = temp;
            }
        }

        /// <summary>
        /// Reverse original object population
        /// </summary>
        /// <param name="objPop">object[][]</param>
        public static void ReversePopulation(object[][] objPop)
        {
            object[] temp;
            for (int i = 0; i < objPop.Length / 2; i++)
            {
                temp = objPop[i];
                objPop[i] = objPop[objPop.Length - i - 1];
                objPop[objPop.Length - i - 1] = temp;
            }
        }

        /// <summary>
        /// Fisher-Yates Shuffle Algorithm for array of integers.
        /// </summary>
        /// <param name="arrInt">The array of integers to shuffle</param>
        /// <returns></returns>
        /// 
        public static int[] Fisher_Yates(int[] arrInt)
        {
            int cant = arrInt.Length;

            int[] arrMut = new int[cant];
            Array.Copy(arrInt, arrMut, cant);
            Random r = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < cant; i++)
            {
                int index = i + (int)(GetRandomNumber() * (cant - i));
                int temp = arrMut[index];
                arrMut[index] = arrMut[i];
                arrMut[i] = temp;
            }
            return arrMut;
        }

        /// <summary>
        /// Experimental Fisher_Yates algorithm to shuffle the original array.
        /// </summary>
        /// <typeparam name="T">the type of data</typeparam>
        /// <param name="arrData">the array of data</param>
        public static void Fisher_Yates<T>(this T[] arrData)
        {
            int n = arrData.Length;
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < n; i++)
            {
                int ri = i + (int)(r.NextDouble() * (n - i));
                T t = arrData[ri];
                arrData[ri] = arrData[i];
                arrData[i] = t;
            }
        }

        /// <summary>
        /// Fisher-Yates Shuffle Algorithm for an array of objects.
        /// </summary>
        /// <param name="arrObj">the array of objects to shuffle</param>
        /// <returns></returns>
        public static object[] Fisher_Yates(object[] arrObj)
        {
            int cant = arrObj.Length;
            object[] arrObjMuts = (object[])arrObj.Clone();

            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < cant; i++)
            {
                int index = i + (int)(r.NextDouble() * (cant - i));
                
                //swap
                object temp = arrObjMuts[index];
                arrObjMuts[index] = arrObjMuts[i];
                arrObjMuts[i] = temp;
            }

            return arrObjMuts;
        }

        /// <summary>
        /// Fisher-Yates Shuffle Algorithm for an array of objects.
        /// </summary>
        /// <param name="arrObj">the array of objects to shuffle</param>
        /// <param name="percent">the percent to shuffle</param>
        /// <returns></returns>
        public static object[] Fisher_YatesPercent(object[] arrObj, float percent)
        {
            int l = arrObj.Length;
            object[] arrObjMuts = (object[])arrObj.Clone();

            int cant = (int)(l * percent);
            cant = (cant <= 0) ? cant = 2 : cant;

            //Random r = new Random(DateTime.Now.Millisecond);
            int index;

            for (int i = 0; i < cant; i++)
            {
                //index = i + (int)(r.NextDouble() * (cant - i));
                index = GetRandomNumber(i, cant);
                //swap
                object temp = arrObjMuts[index];
                arrObjMuts[index] = arrObjMuts[i];
                arrObjMuts[i] = temp;
            }
            return arrObjMuts;
        }

        //Function to get random number
        private static readonly Random getrandom = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Random integer number between range
        /// </summary>
        /// <param name="min">int</param>
        /// <param name="max">int</param>
        /// <returns>int</returns>
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        /// <summary>
        /// Random number
        /// </summary>
        /// <returns></returns>
        public static double GetRandomNumber()
        {
            lock(getrandom)
            {
                return getrandom.NextDouble();
            }
        }

        /// <summary>
        /// Returns a Char in the format 0 or 1
        /// </summary>
        /// <param name="thershold">thershold parameter. 0.5 = 50%</param>
        /// <returns></returns>
        public static char RandomCharBinary(float thershold)
        {
            char t;

            if (GetRandomNumber() < thershold)
            {
                t = '1';
            }
            else
            {
                t = '0';
            }
            return t;
        }

        /// <summary>
        /// Generate a random char.
        /// based on this link: http://www.asciitable.com/
        /// </summary>
        /// <param name="start">the start number for the table, inclusive</param>
        /// <param name="end">the end number for the table, inclusive</param>
        /// <returns>char</returns>
        public static char RandomChar(int start, int end)
        {
            return (char)GetRandomNumber(start, end + 1);
        }

        /// <summary>
        /// Return non repetead integers between a min max and percent.
        /// </summary>
        /// <param name="min">the minimum value</param>
        /// <param name="max">the maximum value</param>
        /// <param name="percent">the percent of return, if 1f will return all the numbers.</param>
        /// <returns>array of integers if wrong array of 0</returns>
        public static int[] RandomInt(int min, int max, float percent)
        {
            if(min > max) { return new int[] { 0 }; }

            int size = (int)(percent * ((max - min) + 1));
            size = (size < 1) ? 1 : size;
            int[] arrIndexSelected = new int[size];

            int[] arrIndex = Enumerable.Range(min, max).ToArray();
            arrIndex = Fisher_Yates(arrIndex);

            for (int i = 0; i < size; i++)
            {
                arrIndexSelected[i] = arrIndex[i];
            }
            return arrIndexSelected;
        }

        /// <summary>
        /// Non repeated indexs.
        /// </summary>
        /// <param name="lengthPop">the length of the population</param>
        /// <param name="percent">the percent of mutation</param>
        /// <returns>array of indexs</returns>
        public static int[] Mom_Dad(int lengthPop, float percent)
        {
            //numbers and utilities..
            int size = (int)(percent * lengthPop);

            if (size % 2 != 0) { size--; } //check if is even...
            size = (size <= 1) ? 2 : size; //check if is too small...
            

            int[] arrIndex = Enumerable.Range(0, lengthPop).ToArray();
            arrIndex = Fisher_Yates(arrIndex);

            int[] arrIndexSelected = new int[size];
            for (int i = 0; i < size; i++)
            {
                arrIndexSelected[i] = arrIndex[i];
            }

            return arrIndexSelected;
        }

    }
}
