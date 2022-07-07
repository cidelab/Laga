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
    public class Population<T> : IEnumerable
    {
        private List<Chromosome<T>> population;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SizePopulation"></param>
        public Population(int SizePopulation)
        {
            population = new List<Chromosome<T>>(SizePopulation);
        }

        /// <summary>
        /// 
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
        /// <returns></returns>
        public Chromosome<T> Higher()
        {
            return population.OrderBy(chr => chr.Fitness).Last();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparamref name="T">The type for chromosome</typeparamref>
        /// <param name="chromosome"></param>
        public void Add(Chromosome<T> chromosome)
        {
            population.Add(chromosome);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            population.RemoveAt(index);
        }
        /// <summary>
        /// Return the Lower ranked chromosome based on the fitness evaluation
        /// </summary>
        /// <returns></returns>
        public Chromosome<T> Lower()
        {
            return population.OrderBy(chr => chr.Fitness).First();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Chromosome<T> GetChromosome(int index)
        {
            return population[index];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       public double FitnessAverage()
        {
            double fltAverage = 0;
            for (int i = 0; i < population.Count; i++)
            {
                fltAverage += population[i].Fitness;
            }

            return fltAverage / population.Count;
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
