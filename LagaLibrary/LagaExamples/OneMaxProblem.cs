using Laga;

namespace LagaExamples
{
    public static class OneMaxProblem
    {
        public static void Run()
        {
            Console.WriteLine("\n /// - Example One Max Problem - /// \n");
            Console.WriteLine("Fitness: Evolve a binary string with as many 1s as possible \n");

            // Define chromosome and GA setup
            int c = 0;
            int popSize = 5;
            int chrLength = 10;
            int maxGenerations = 1000;
            double pr = 0.5;
            double chr = 0.1;

            Console.WriteLine("GA parameters:");
            Console.WriteLine("Population size: {0} , Chromosome length: {1}", popSize, chrLength);
            Console.WriteLine("Mutation in population rate: {0} , Mutation in Chromosome rate: {1} \n", pr, chr);

            //initialize the population:
            Population<int> population = new Population<int>();
            for (int i = 0; i < popSize; i++)
                population.Add(new Chromosome<int>(FitnessFunc, GenrGenes.Binary_Integer(chrLength).ToList()));
            
            double maxFitness = 0;
            while ((maxGenerations > c) || (maxFitness < chrLength)) //Genetic loop
            {
                maxFitness = population.HighestFitnessChromosome().Fitness;
                PrintData(population, c);

                population.Selection("roulette", invert: false, elitism: true, eliteCount: 2); //selection
                population.Crossover("onePoint", 0.50); //crossover
                population.Mutation("binary", populationRate: pr, chromosomeRate: chr);//mutation
                population.Evaluation(FitnessFunc); //evaluation

                c++;
            }
        }

        private static void PrintData(Population<int> pop, int c)
        {
            Console.SetCursorPosition(0, 18);
            Chromosome<int> chr = pop.HighestFitnessChromosome();
            Console.WriteLine($"Iter:({c}) > Highest Fitness: {chr.Fitness} , Average Fitness: {pop.GetAverageFitness():F2}");
            Console.WriteLine(chr.ToString());
            Console.WriteLine(pop.ToString());
        }

        //calculate the fitness.
        private static Func<Chromosome<int>, double> FitnessFunc = chromosome =>
        {
            int geneSum = 0;
            for (int i = 0; i < chromosome.Count; i++)
                geneSum += chromosome.GetGene(i);

            return geneSum;
        };
    }
}
