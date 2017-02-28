using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Laga
{
    class LagaTools
    {
        Random rnd;
        public LagaTools()
        {
            rnd = new Random((int)DateTime.Now.Millisecond);
        }
        /// <summary>
        /// Fisher-Yates Shuffle Algorithm for an array of integers.
        /// </summary>
        /// <param name="arrInt"> the array of integers to shuffle</param>
        /// <returns></returns>
        public int[] Fisher_Yates(int[] arrInt)
        {
            int cant = arrInt.Length;
            
            for(int i = 0; i < cant; i++)
            {
                int index = i + (int)(rnd.NextDouble() * (cant - i));
                int temp = arrInt[index];
                arrInt[index] = arrInt[i];
                arrInt[i] = temp;
            }
            return arrInt;
        }

        /// <summary>
        /// Fisher-Yates Shuffle Algorithm for an array of objects.
        /// </summary>
        /// <param name="arrObj">the array of objects to shuffle</param>
        /// <returns></returns>
        public Object[] Fisher_Yates(Object[] arrObj)
        {
            int n = arrObj.Length;

            for (int i = 0; i < n; i++)
            {
                int index = i + (int)(rnd.NextDouble() * (n - i));
                
                //swap
                Object temp = arrObj[index];
                arrObj[index] = arrObj[i];
                arrObj[i] = temp;
            }

            return arrObj;
        }

        /// <summary>
        /// Fisher-Yates Shuffle Algorithm for an array of objects.
        /// </summary>
        /// <param name="arrObj">the array of objects to shuffle</param>
        /// <param name="percent">the percent to shuffle</param>
        /// <returns></returns>
        public Object[] Fisher_YatesPercent(Object[] arrObj, float percent)
        {
            int cant = (int)(arrObj.Length * percent);
            if (cant == 0) { cant = 1; }

            for (int i = 0; i < cant; i++)
            {
                int index = i + (int)(rnd.NextDouble() * (cant - i)); //rnd.Next(i);// 0 <= j <= i-1

                //swap
                Object temp = arrObj[index];
                arrObj[index] = arrObj[i];
                arrObj[i] = temp;
            }
            return arrObj;
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

    }
}
