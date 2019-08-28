using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    public interface IPopulation<T>
    {
        int Count { get; }
        void Add(T Get);
    }
}
