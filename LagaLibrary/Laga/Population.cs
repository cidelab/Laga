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
        private List<Chromosome<T>> pop;
        private int popSize;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SizePopulation"></param>
        public Population(int SizePopulation)
        {
            this.popSize = SizePopulation;
            pop = new List<Chromosome<T>>(SizePopulation);
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get
            {
                return pop.Count;
            }
        }

        /// <summary>
        /// Return the Higher Ranked Chromosome based on the fitness evaluation
        /// </summary>
        /// <returns></returns>
        public Chromosome<T> Higher()
        {
            return pop.OrderBy(chr => chr.Fitness).Last();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparamref name="T">The type for Chr</typeparamref>
        /// <param name="chromosome"></param>
        public void Add(Chromosome<T> chromosome)
        {
            pop.Add(chromosome);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            pop.RemoveAt(index);
        }
        /// <summary>
        /// Return the Lower ranked Chr based on the fitness evaluation
        /// </summary>
        /// <returns></returns>
        public Chromosome<T> Lower()
        {
            return pop.OrderBy(chr => chr.Fitness).First();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Chromosome<T> GetChromosome(int index)
        {
            return pop[index];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       public double FitnessAverage()
        {
            double fltAverage = 0;
            for (int i = 0; i < pop.Count; i++)
            {
                fltAverage += pop[i].Fitness;
            }

            return fltAverage / pop.Count;
        }

        /// <summary>
        /// IEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return pop.GetEnumerator();
        }

        /// <summary>
        /// Print a population
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Population: ");

            for (int i = 0; i < pop.Count; i++)
                sb.AppendLine(pop[i].ToString());
            
            return sb.ToString();
        }
    }
}
