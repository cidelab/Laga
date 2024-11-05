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
            Console.WriteLine("Use this class to generate random numbers and data: \n");

            double dblRand = Rand.NextDouble(0, 5);
            Console.WriteLine("random double between 0.0 and 5.0 (exc.): {0}", dblRand);

            char charRand = Rand.NextChar(65, 91);
            Console.WriteLine("any capital letter from A to Z: {0} \n", charRand);

            Console.WriteLine("it possible to generate lists as well; float list:");
            float[] arrFloats = Rand.Floats(10, 10f, 20f);
            arrFloats.ToList().ForEach(Console.WriteLine);
            

            Console.ReadLine();
        }
    }
}
