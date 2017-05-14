using System;
using System.Collections.Generic;
using System.Text;
using Laga;

namespace TestingCrossover
{
    class Program
    {
        static void Main(string[] args)
        {
            GenrPopulation gnerPop = new GenrPopulation(6);
            Crossover csr = new Crossover();

            GenrChromosome ch = new GenrChromosome(10);
            int[] arrch = ch.NumberChromosomeSwap(1, 10);
            char[] arrchar = ch.CharChromosome(97, 122);

            char[][] charPop = gnerPop.CharPopulation(6, 97, 122);

            Console.WriteLine("Population return");

            foreach (char[] chromosome in charPop)
            {
                Console.WriteLine(new string(chromosome));

            }

            char[][] pop = csr.SinglePointCrossover(charPop, 1.0f, 3);
            Console.WriteLine("After Crossover");
            foreach (char[] son in pop)
            {
                Console.WriteLine(new string(son));
            }
            Console.ReadLine();
        }
    }
}
