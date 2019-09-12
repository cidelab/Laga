using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// Population Class
    /// </summary>
    public class Population : IEnumerable
    {
        private List<Chromosome> population;
        private int count;

        /// <summary>
        /// The population count
        /// </summary>
        public int Count
        {
            get
            {
                return population.Count;
            }
        }

        /// <summary>
        /// Return the Higher Ranked Chromosome based on the fitness evaluation
        /// </summary>
        public Chromosome Higher()
        {
            return population.OrderBy(chr => chr.Fitness).Last();
        }

        /// <summary>
        /// Return the Lower ranked chromosome based on the fitness evaluation
        /// </summary>
        public Chromosome Lower()
        {
            return population.OrderBy(chr => chr.Fitness).First();
        }

        /// <summary>
        /// Add a chromsome to the population
        /// </summary>
        /// <param name="chromosome"></param>
        public void Add(Chromosome chromosome)
        {
            population.Add(chromosome);
        }

        /// <summary>
        /// Remove a Chromosome at specific index;
        /// </summary>
        /// <param name="index">The index in the population</param>
        public void Delete(int index)
        {
            population.RemoveAt(index);
        }

        /// <summary>
        /// Return a chromosome at specific index.
        /// </summary>
        /// <param name="index">The index in the population</param>
        /// <returns>Chromosome</returns>
        public Chromosome GetChromosome(int index)
        {
            return population[index];
        }

        /// <summary>
        /// Calculate the average fitness in the population
        /// </summary>
        /// <returns>float</returns>
        public float FitnessAverage()
        {
            float fltAverage = 0;
            for(int i = 0; i < population.Count; i++)
            {
                fltAverage += population[i].Fitness;
            }

            return fltAverage / population.Count;
        }

        /// <summary>
        /// Build a population by size
        /// </summary>
        /// <param name="sizePopulation"></param>
        public Population(int sizePopulation)
        {
            count = sizePopulation;
            population = new List<Chromosome>(sizePopulation);
        }

        /// <summary>
        /// Builds a clean population
        /// </summary>
        public Population()
        {
            population = new List<Chromosome>();
        }

        /// <summary>
        /// IEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return population.GetEnumerator();
        }

    }
}
