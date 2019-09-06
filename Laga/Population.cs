using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// 
    /// </summary>
    public class Population : IEnumerable
    {
        private List<Chromosome> population;
        private int count;

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
        /// 
        /// </summary>
        /// <param name="chromo"></param>
        public void Add(Chromosome chromo)
        {
            population.Add(chromo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Chromosome GetChromosome(int index)
        {
            return population[index];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sizePopulation"></param>
        public Population(int sizePopulation)
        {
            count = sizePopulation;
            population = new List<Chromosome>(sizePopulation);
        }

        /// <summary>
        /// 
        /// </summary>
        public Population()
        {
            population = new List<Chromosome>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return population.GetEnumerator();
        }

    }
}
