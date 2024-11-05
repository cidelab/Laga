using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laga.GeneticAlgorithm;
using Laga.Numbers;

namespace LagaExamples
{
    public static class TestingRandom
    {
        public static void Run()
        {
            Console.WriteLine("Running Basic Example 1...");
            double dblRand = Rand.NextDouble(0, 1);
            Console.WriteLine("random value between 0 and 1 (ex) is {0}", dblRand);
            Console.ReadLine();
        }
    }
}
