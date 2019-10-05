using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga
{
    interface IChromosome<T>
    {
        int Count { get; }

        double Fitness { get; set; }

        void InsertDNA(int index, T DNA);

        void Add(T DNA);

        string Chr2Str(string Sep);

    }
}
