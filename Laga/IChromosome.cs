using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// IDNA
    /// </summary>
    public interface IChromosome<T>
    {
        void Add(T Get);
        int Count { get; }
    }
}
