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

            int c = 0;

            do //GA loop
            {
                
                for (int i = 0; i < popSize; i++)
                {
                    result[i] = Evaluation(charPop[i]);
                }

                rs.BidirectionalBubbleSort(charPop, result, true);

                eval = result[0];
                PrintData(charPop[0], eval, c);

                selChro = ns.Elitism(charPop, 5); //select the top five chromosomes...
                sonPop = cs.SinglePointCrossover(selChro, 0.6f, 2);
                mutPop = mut.BinaryCharMutation(sonPop, 0.2f);
                charPop = ReplacementPop(selChro, mutPop, sonPop, popSize);

                c++;
                
            } while (eval != 9); 

            Console.WriteLine("founded!");
            Console.ReadKey();
        }

        private static char[][] ReplacementPop(char[][] selIndividuals, char[][] mutPop, char[][] sonPop, int sizePop)
        {
            char[][] replacement = new char[sizePop][];
            char[] tempChromosome;
            int count = 0;

            for (int i = 0; i < mutPop.Length; ++i) //we copy first the mutated...
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

            if (count < sizePop)
            {
                for (int i = 0; i < replacement.Length - count; ++i)
                {
                    tempChromosome = new char[sonPop[i].Length];
                    tempChromosome = sonPop[i];
                    replacement[count] = tempChromosome;
                    count++;
                }
            }

            return replacement;
        }

        private static void PrintData(char[] arrCh, float e, int c)
        {
            //maximise f(x) = -x2 + 4x + 5
            string f = new string(arrCh);

            int x = Convert.ToInt32(f, 2);

            float res = (float)(-Math.Pow(-x, 2) + 4 * x + 5);

            string dta = "Genr: "+ c + ":  -" + x + "^2 + 4*" + x + " + 5 = " + res;
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
