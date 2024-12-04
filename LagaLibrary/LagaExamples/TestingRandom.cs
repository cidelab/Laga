using System;
using System.Collections.Generic;
using System.Drawing;
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
            Console.WriteLine("\n /// - Use the class Laga.Numbers.Rand() to generate random data: - /// \n");

            double dblRand = Rand.NextDouble(0, 5);
            Console.WriteLine("Random double between 0.0 and 5.0 (exc.): {0} \n", dblRand);

            char charRand = Rand.NextChar(65, 91);
            Console.WriteLine("Any capital letter from A to Z: {0} \n", charRand);

            Console.WriteLine("Array of capital characters:");
            char[] arrChs = Rand.Characters(20, 65, 91);
            Console.WriteLine(string.Join(", ", arrChs)+ "\n");

            Console.WriteLine("It's possible to generate lists as well; float list:");
            float[] arrFloats = Rand.Floats(10, 10f, 20f);
            Console.WriteLine(string.Join(", ", arrFloats) + "\n");

            Console.WriteLine("Random color:");
            Color clr = Rand.NextColor();
            Console.WriteLine(clr.ToString());

            Console.WriteLine("\n /// - Press any key to return to the menu - /// ");

        }
    }
}
