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
    /// <typeparam name="T"></typeparam>
    public class Population2<T> : IEnumerable
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SizePopulation"></param>
        public Population2(int SizePopulation)
        {
            pop2 = new List<Chromosome2<T>>(SizePopulation);
        }

        /// <summary>
        ///
        /// </summary>
        public Population2()
        {
            pop2 = new List<Chromosome2<T>>();
        }

        private List<Chromosome2<T>> pop2;

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get
            {
                return pop2.Count;
            }
        }

        /// <summary>
        /// Return the Higher Ranked Chromosome based on the fitness evaluation
        /// </summary>
        /// <returns></returns>
        public Chromosome2<T> Higher()
        {
            return pop2.OrderBy(chr => chr.Fitness).Last();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="chromosome2"></param>
        public void Add(Chromosome2<T> chromosome2)
        {
            pop2.Add(chromosome2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            pop2.RemoveAt(index);
        }
        /// <summary>
        /// Return the Lower ranked chromosome based on the fitness evaluation
        /// </summary>
        /// <returns></returns>
        public Chromosome2<T> Lower()
        {
            return pop2.OrderBy(chr => chr.Fitness).First();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Chromosome2<T> GetChromosome(int index)
        {
            return pop2[index];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       public double FitnessAverage()
        {
            double fltAverage = 0;
            for (int i = 0; i < pop2.Count; i++)
            {
                fltAverage += pop2[i].Fitness;
            }

            return fltAverage / pop2.Count;
        }


        /// <summary>
        /// IEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return pop2.GetEnumerator();
        }

    }
}
