using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laga;
using Microsoft.Office.Interop.Excel;

namespace LagaExamples
{
    public static class Knapsack
    {
        private static List<Item> items = new List<Item>
        { 
            new Item(4.0, 10),  new Item(2.0, 15),  new Item(3.0, 18),  new Item(1.5, 9),   new Item(5.0, 25), 
            new Item(3.5, 30),  new Item(2.5, 14),  new Item(4.5, 20),  new Item(1.0, 8),   new Item(3.0, 16),
            new Item(6.0, 35),  new Item(2.2, 11),  new Item(3.8, 19),  new Item(1.7, 10),  new Item(5.5, 28),
            new Item(2.8, 13),  new Item(4.0, 21),  new Item(1.3, 6),   new Item(3.3, 15),  new Item(2.1, 12),
        };

    public static void Run()
        {
            Console.WriteLine("\n /// - Knapsack, optimize the selection - /// \n");
            Console.WriteLine("Turn on the most valuable switches — but don’t blow the fuse. \n");

            int popSize = 50;
            int chrLength = items.Count; // dimensions
            int maxGenerations = 1000;

            // Initialize population with binary numbers
            Population<int> population = new Population<int>();

            for (int i = 0; i < popSize; i++)
                population.Add(new Chromosome<int>(FitnessFunc, GenrGenes.Binary_Integer(chrLength).ToList()));

            //Genetic loop
            double maxFitness = 0;
            for (int i = 0; i < maxGenerations; i++)
            {
                maxFitness = population.HighestFitnessChromosome().Fitness;
                PrintData(population, i);

                population.Selection("roulette", invert: false, elitism: true, eliteCount: 2); //Maximize fitness
                population.Crossover("onepoint", 0.6); //For real values, use BLX-alpha or arithmetic crossover
                population.Mutation("binary", populationRate: 0.2, chromosomeRate: 0.1); //using Binary
                population.Evaluation(FitnessFunc);
            }
        }

        private static void PrintData(Population<int> pop, int c)
        {
            Console.SetCursorPosition(0, 17);
            Chromosome<int> chr = pop.HighestFitnessChromosome();
            Console.WriteLine("Iter:(" + c + "); Highest Fitness: {0}, Average fitness: {1}", chr.Fitness, pop.GetAverageFitness());
            Console.WriteLine(chr.ToFormattedString());
        }

        private static Func<Chromosome<int>, double> FitnessFunc = chromosome =>
        {
            double maxWeight = 15;
            double penaltyFactor = 20; // tune this
            double totalWeight = 0;
            double totalValue = 0;

            for (int i = 0; i < chromosome.Count; i++)
            {
                if (chromosome.GetGene(i) == 1)
                {
                    totalWeight += items[i].Weight;
                    totalValue += items[i].Value;
                }
            }
            
            return (totalWeight > maxWeight) ? totalValue - penaltyFactor * (totalWeight - maxWeight) : totalValue;
        };
    }
    public class Item
    {
        public double Weight { get; set; }
        public double Value { get; set; }

        public Item(double weight, double value)
        {
            Weight = weight;
            Value = value;
        }

        public override string ToString()
        {
            return $"Item [Weight: {Weight}, Value: {Value}]";
        }
    }
}
