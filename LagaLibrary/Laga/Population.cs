using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{ 
    /// <summary>
    /// Create and Manipulate Populations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Population<T> : IEnumerable<Chromosome<T>>
    {
        readonly private List<Chromosome<T>> pop;
        readonly private int popSize;
        private Chromosome<T> highestFitnessChromosome;
        private Chromosome<T> lowestFitnessChromosome;
        private double totalFitness;

        /// <summary>
        /// Return the higher chromosome in the population
        /// </summary>
        /// <returns><![CDATA[Chromosome<T>]]></returns>
        public Chromosome<T> Higher() => highestFitnessChromosome;

        /// <summary>
        /// Return the lower chromosome in the population
        /// </summary>
        /// <returns><![CDATA[Chromosome<T>]]></returns>
        public Chromosome<T> Lower() => lowestFitnessChromosome;

        /// <summary>
        /// return the average fitness in the population
        /// </summary>
        /// <returns>double</returns>
        public double FitnessAverage() => totalFitness / pop.Count;

        /// <summary>
        /// Construct a predifined size population 
        /// </summary>
        /// <param name="SizePopulation"></param>
        public Population(int SizePopulation)
        {
            this.popSize = SizePopulation;
            pop = new List<Chromosome<T>>(SizePopulation);
        }

        /// <summary>
        /// Construct a population with no size
        /// </summary>
        public Population()
        {
            pop = new List<Chromosome<T>>();
        }

        /// <summary>
        /// Population count
        /// </summary>
        public int Count
        {
            get
            {
                return pop.Count;
            }
        }

        /// <summary>
        /// Add a chromosome to the population
        /// </summary>
        /// <typeparamref name="T">The type for Chr</typeparamref>
        /// <param name="chromosome"></param>
        public void Add(Chromosome<T> chromosome)
        {
            if (popSize > 0 && pop.Count >= popSize)
                throw new InvalidOperationException("Population size limit reached");

            UpdateFitnessStatistics(chromosome);

            pop.Add(chromosome);
        }

        private void UpdateFitnessStatistics(Chromosome<T> newChromosome)
        {
            totalFitness += newChromosome.Fitness;
            if (highestFitnessChromosome == null || newChromosome.Fitness > highestFitnessChromosome.Fitness)
                highestFitnessChromosome = newChromosome;
            if (lowestFitnessChromosome == null || newChromosome.Fitness < lowestFitnessChromosome.Fitness)
                lowestFitnessChromosome = newChromosome;
        }

        /// <summary>
        /// Delete a chromosome from the population
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            pop.RemoveAt(index);
        }

        /// <summary>
        /// Get the chromosome from the population.
        /// </summary>
        /// <param name="index"></param>
        /// <returns><![CDATA[Chromosome<T>]]></returns>
        public Chromosome<T> GetChromosome(int index)
        {
            return pop[index];
        }

        /// <summary>
        /// Print a population
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Population:");

            for (int i = 0; i < pop.Count; i++)
                sb.AppendLine($"Chromosome {i}: {pop[i].ToString()} (Fitness: {pop[i].Fitness})");
            
            return sb.ToString();
        }

        IEnumerator<Chromosome<T>> IEnumerable<Chromosome<T>>.GetEnumerator()
        {
            return pop.GetEnumerator();
        }

        /// <summary>
        /// IEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return pop.GetEnumerator();
        }

    }
}
