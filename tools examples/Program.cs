using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laga.GeneticAlgorithm;

namespace tools_examples
{
    class Program
    {
        static void Main(string[] args)
        {
            point[] points = new point[3];
            points[0] = new point(0.17452, 0.12315, 0.43423);
            points[1] = new point(0.56752, 0.48579, 0.56273);
            points[2] = new point(0.34745, 0.08343, 0.13459);

            string[] strPtParse = LagaTools.Parse(points, 2);

            Console.ReadLine();

        }
    }
}
