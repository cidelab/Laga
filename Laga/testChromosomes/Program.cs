using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Laga;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int msize = 10;
            GenrChromosome ch = new GenrChromosome(msize);
            
            double[] chrome = ch.NumberChromosome(1.00, 10.00);
            int[] intChr = ch.NumberChromosome(0, 11);
            int[] intSwap = ch.NumberChromosomeSwap(0);

            int i = 0;
            foreach (double dbl in chrome)
            {
                //Console.WriteLine(dbl + "  " + intChr[i] + " " + intSwap[i]);
                Console.WriteLine(" " + intSwap[i]);
                i++;
            }

            Console.ReadLine();
        }
    }
}
