using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    public class Population<T> : List<T> , IPopulation<T>
    {
        private List<Chromosome> population;

        /// <summary>
        /// Return the Higher Ranked Chromosome based on the fitness evaluation
        /// </summary>
        public Chromosome Higher
        {
            get
            {
                Chromosome crHigher = this.population.OrderBy(o => o.Fitness).ToList()[population.Count - 1];
                return crHigher;
            }
        }

        /// <summary>
        /// Return the Lower ranked chromosome based on the fitness evaluation
        /// </summary>
        public Chromosome Lower
        {
            get
            {
                Chromosome crLower = population.OrderBy(o => o.Fitness).ToList()[0];
                return crLower;
            }
        }
        
        public Population(int sizePopulation)
        {
            population = new List<Chromosome>(sizePopulation);
        }

        public Population()
        {
            population = new List<Chromosome>();
        }

    }
}
