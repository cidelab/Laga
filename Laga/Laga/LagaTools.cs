using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Laga
{
    public class LagaTools
    {
        Random rnd;
        public LagaTools()
        {
            rnd = new Random((int)DateTime.Now.Millisecond);
        }

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

        public static void ReversePopulation(int[][] intPop) { }
        public static void ReversePopulation(double[][] dblPop) { }
        public static void ReversePopulation(float[][] flPop) { }
        public static void ReversePopulation(object[][] objPop) { }

        /// <summary>
        /// Fisher-Yates Shuffle Algorithm for an array of integers.
        /// </summary>
        /// <param name="arrInt"> the array of integers to shuffle</param>
        /// <returns></returns>
        public int[] Fisher_Yates(int[] arrInt)
        {
            int cant = arrInt.Length;

            int[] arrMut = new int[cant];
            Array.Copy(arrInt, arrMut, cant);
            
            for(int i = 0; i < cant; i++)
            {
                int index = i + (int)(rnd.NextDouble() * (cant - i));
                int temp = arrMut[index];
                arrMut[index] = arrMut[i];
                arrMut[i] = temp;
            }
            return arrMut;
        }

        /// <summary>
        /// Fisher-Yates Shuffle Algorithm for an array of objects.
        /// </summary>
        /// <param name="arrObj">the array of objects to shuffle</param>
        /// <returns></returns>
        public object[] Fisher_Yates(object[] arrObj)
        {
            int cant = arrObj.Length;
            object[] arrObjMuts = new object[cant];
            Array.Copy(arrObj, arrObjMuts, cant);

            for (int i = 0; i < cant; i++)
            {
                int index = i + (int)(rnd.NextDouble() * (cant - i));
                
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
        public object[] Fisher_YatesPercent(object[] arrObj, float percent)
        {
            int l = arrObj.Length;
            object[] arrObjMuts = new object[l];
            Array.Copy(arrObj, arrObjMuts, l);

            int cant = (int)(l * percent);
            cant = (cant <= 0) ? cant = 2 : cant;

            for (int i = 0; i < cant; i++)
            {
                int index = i + (int)(rnd.NextDouble() * (cant - i));

                //swap
                object temp = arrObjMuts[index];
                arrObjMuts[index] = arrObjMuts[i];
                arrObjMuts[i] = temp;
            }
            return arrObjMuts;
        }

        /// <summary>
        /// Returns a Char in the format 0 or 1
        /// </summary>
        /// <param name="thershold">thershold parameter. 0.5 = 50%</param>
        /// <returns></returns>
        public char RandomCharBinary(float thershold)
        {
            char t;
            if (rnd.NextDouble() < thershold)
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
        public char RandomChar(int start, int end)
        {
            int index = (int)(start * rnd.NextDouble() + (end - start));
            return (char)index;
        }

        /// <summary>
        /// Experimental Fisher_Yates
        /// </summary>
        /// <typeparam name="T">the type of data</typeparam>
        /// <param name="arrData">the array of data</param>
        public void Fishe_Yates<T>(T[] arrData)
        {
            int n = arrData.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + (int)(rnd.NextDouble() * (n - i));
                T t = arrData[r];
                arrData[r] = arrData[i];
                arrData[i] = t;
            }
        }

        public int[] Mom_Dad(int lengthPop, float percent)
        {
            //numbers and utilities..
            int size = (int)(percent * lengthPop);
            size = (size <= 0) ? 2 : size; //check if is too small...
            size = (size % 2 == 1) ? size-- : size; //check if is even...

            int[] arrIndex = new int[size];

            int c;

            //random zone.
            int index;

            //loop to find random and not repeated indexes.
            for (int i = 0; i < size; ++i)
            {
                do
                {
                    c = 0;
                    index = rnd.Next(lengthPop);
                    if (i > 0)
                    {
                        for (int j = 0; j < i; ++j)
                        {
                            if (arrIndex[j] == index)
                            {
                                c++;
                            }
                        }
                        if (c == 0)
                        {
                            arrIndex[i] = index;
                        }

                    }
                    else
                    {
                        arrIndex[i] = index;
                    }
                } while (c != 0);
            }

            return arrIndex;
        }

    }
}
