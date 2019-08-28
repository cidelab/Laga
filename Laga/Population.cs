using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    public class Population<T> : List<T>, IPopulation<T>
    {
        private List<T> population;

        public Population(int sizePopulation)
        {
            population = new List<T>(sizePopulation);
        }

        public Population()
        {
            population = new List<T>();
        }

    }
}
