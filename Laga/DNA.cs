using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// the dna in the chromosome
    /// </summary>
    public class DNA
    {
        // T used in non-generic constructor.
        public DNA(object t)
        {
            data = t;
        }

        private Object data;

        public static explicit operator DNA(char v)
        {
            throw new NotImplementedException();
        }
    }
}
