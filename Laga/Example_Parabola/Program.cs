using System;
using System.Collections.Generic;
using System.Text;
using Laga;

namespace Example_Parabola
{
    class Program
    {
        static void Main(string[] args)
        {
            // fields... //
            int popSize = 10; //population size...
            int chromeSize = 4; //chromosome size....
            float[] result; //to store the results of the evaluation.
            char[][] charPop;

            char[][] selChro;
            char[][] sonPop;
            char[][] mutPop;

            GenrPopulation genPop = new GenrPopulation(popSize);
            charPop = genPop.BinaryPopulationChr(chromeSize);

            Console.ReadKey();
        }

        private static void PrintData(char[] arrCh, float e)
        {
            //maximise f(x) = -x2 + 4x + 5
            string f = new string(arrCh);

            int x = Convert.ToInt32(f, 2);

            float res = (float)(Math.Pow(x, 2) + 4 * x + 5);

            string dta = "-Math.pow(" + x + ",2) + 4*" + x + " + 5 = " + res;
            Console.WriteLine(dta);
        }

        private static float Evaluation(char[] arrch)
        {
            string f = new string(arrch);
            int x = Convert.ToInt32(f, 2);

            return (float)(-Math.Pow(x, 2) + 4 * x + 5);
        }
    }
}
