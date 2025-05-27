using Laga.Numbers;
using Laga;

namespace LagaExamples
{
    public static class Rastrigin
    {
        public static void Run()
        {
            Console.WriteLine("\n /// - Rastrigin Function, continuous optimization - /// \n");
            Console.WriteLine("Fitness: f(x)=A∗n+Σ[pow(x,2)i − A ∗ COS(2πxi)], where A = 10");
            Console.WriteLine("Find the global minimum at x = 0, where f(x) = 0  \n");

            int c = 0;
            int popSize = 40;
            int chrLength = 10; // dimensions
            int maxGenerations = 1000;
            double mutationRate = 0.18;
            double crossoverRate = 0.4;
            double minGeneValue = -5.12;
            double maxGeneValue = 5.12;

            // Initialize population with real - valued genes in range[-5.12, 5.12]
            Population<double> population = new Population<double>();

            for (int i = 0; i < popSize; i++)
                population.Add(new Chromosome<double>(FitnessFunc, GenrGenes.RandomChromosome<double>(chrLength, minGeneValue, maxGeneValue, Rand.NextDouble).ToList()));

            // Genetic loop
            double minFitness = double.MaxValue;
            while ((c < maxGenerations) && (minFitness > 1e-5)) // stop if near-zero fitness
            {
                minFitness = population.LowestFitnessChromosome().Fitness;
                PrintData(population, c);

                population.Selection("roulette", invert: true, elitism: true, eliteCount: 2); // Minimize fitness
                population.Crossover("onepoint", crossoverRate); // For real values, use BLX-alpha or arithmetic crossover
                //population.Mutation("dblRandom", populationRate: mutationRate, chromosomeRate: crossoverRate, dMin: -0.1, dMax: 0.1); // best results using these parameters.
                population.Mutation("dblGaussian", populationRate: mutationRate, chromosomeRate: crossoverRate, mean: 0.5, stdDev: 1); // Use Gaussian noise
                population.Evaluation(FitnessFunc);

                c++;
            }

        }

        private static void PrintData(Population<double> pop, int c)
        {
            Console.SetCursorPosition(0, 17);
            Chromosome<double> chr = pop.LowestFitnessChromosome();
            Console.WriteLine("Iter:(" + c + ") > LowestFitness: {0} ,  Average fitness: {1}", chr.Fitness, pop.GetAverageFitness());
            Console.WriteLine(chr.ToFormattedString());
        }


        private static Func<Chromosome<double>, double> FitnessFunc = chromosome =>
        {
            int n = chromosome.Count;
            double A = 10.0;
            double sum = A * n;

            for (int i = 0; i < n; i++)
            {
                double x = chromosome.GetGene(i);
                sum += (x * x - A * Math.Cos(2 * Math.PI * x));
            }

            return sum; // Lower is better
        };
    }
}
