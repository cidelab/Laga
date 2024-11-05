using Laga.GeneticAlgorithm;
using Laga.Geometry;
using Laga.Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagaExamples
{
    public static class TestingChromosomes
    {
        public static void Run()
        {
            Console.WriteLine("Use this class to create chromosomes: \n");

            Chromosome<float> chrFloats = GenrGenes.RandomChromosome<float>(10, 6f, 7f, Rand.NextFloat);
            Console.WriteLine(chrFloats.ToString());

            chrFloats.Fitness = 0.678;
            Console.WriteLine("with fitness value: " + chrFloats.ToString());

            chrFloats.Shuffle();
            Console.WriteLine("chromosome shuffle: " + chrFloats.ToString());

            Console.WriteLine("\n Other chromosome by default types \n");

            Chromosome<int> intChr = GenrGenes.RandomChromosome<int>(30, 0, 10, Rand.NextInt);
            Console.WriteLine(intChr.ToString());

            Range r = new Range(0, 10);
            Chromosome<Vector> vecChr = GenrGenes.Rand_Vector(20, r, r, r);
            Console.WriteLine(vecChr.ToString());

            Console.WriteLine("A chromosome can take a list of any type.");

            Console.ReadLine();
        }
    }
}
