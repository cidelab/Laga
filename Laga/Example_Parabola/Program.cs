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

            RankingSort rs = new RankingSort();
            NaturalSelection ns = new NaturalSelection();
            Crossover cs = new Crossover();
            Mutation mut = new Mutation(1f);

            result = new float[popSize];
            float eval = 0;

            do //GA loop
            {
                for (int i = 0; i < popSize; i++)
                {
                    result[i] = Evaluation(charPop[i]);
                }

                rs.BidirectionalBubbleSort(charPop, result, true);

                eval = result[0];
                PrintData(charPop[0], eval);

                selChro = ns.Elitism(charPop, 5); //select the top five chromosomes...
                sonPop = cs.SinglePointCrossover(selChro, 0.6f, 2);
                mutPop = mut.BinaryCharMutation(sonPop, 0.02f);
                charPop = ReplacementPop(selChro, sonPop, mutPop, popSize);

            } while (eval != 9);

            Console.WriteLine("founded!");
            Console.ReadKey();
        }

        private static char[][] ReplacementPop(char[][] selIndividuals, char[][] sonPop, char[][] mutPop, int sizePop)
        {
            char[][] replacement = new char[sizePop][];
            char[] tempChromosome;
            int count = 0;
            for (int i = 0; i < mutPop.Length; ++i)
            {
                tempChromosome = new char[mutPop[i].Length];
                tempChromosome = mutPop[i];
                replacement[count] = tempChromosome;
                count++;
            }

            for (int i = 0; i < selIndividuals.Length; ++i)
            {
                tempChromosome = new char[selIndividuals[i].Length];
                tempChromosome = selIndividuals[i];
                replacement[count] = tempChromosome;
                count++;
            }

            for (int i = 0; i < sonPop.Length; ++i)
            {
                tempChromosome = new char[sonPop[i].Length];
                tempChromosome = sonPop[i];
                replacement[count] = tempChromosome;
                count++;
            }

            if (count < sizePop)
            {
                for (int i = count; i < sizePop; ++i)
                {
                    tempChromosome = new char[mutPop[0].Length];
                    tempChromosome = mutPop[0];
                    replacement[i] = tempChromosome;
                }
            }

            return replacement;
        }

        private static void PrintData(char[] arrCh, float e)
        {
            //maximise f(x) = -x2 + 4x + 5
            string f = new string(arrCh);

            int x = Convert.ToInt32(f, 2);

            float res = (float)(-Math.Pow(-x, 2) + 4 * x + 5);

            string dta = "-" + x + "^2 + 4*" + x + " + 5 = " + res;
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
