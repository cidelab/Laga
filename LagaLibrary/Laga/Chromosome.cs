using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Laga.Numbers;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// Create and manipulate Chromosomes
    /// </summary>
    public class Chromosome<T>
    {
        private List<T> genes;
        private double? cachedFitness;
        private Func<Chromosome<T>, double> fitnessFunction;

        /// <summary>
        /// The size of the Chr++                                                                        
        /// </summary>
        public int Count
        {
            get
            {
                return Chr.Count;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<T> Chr { get; set; }

        /// <summary>
        /// Constructor accepting a fitness function
        /// </summary>
        /// <param name="FitnessFunction">Function to evaluate chromosome fitness</param>
        public Chromosome(Func<Chromosome<T>, double> FitnessFunction)
        {
            this.genes = new List<T>();
            this.fitnessFunction = FitnessFunction ?? throw new ArgumentNullException(nameof(fitnessFunction), "Fitness function cannot be null.");
        }

        /// <summary>
        /// Constructor by size
        /// </summary>
        public Chromosome(int size)
        {
            this.genes = new List<T>(size);
        }

        /// <summary>
        /// constructor from a list of genes
        /// </summary>
        /// <param name="genes"></param>
        public Chromosome(List<T> genes)
        {
            this.genes = genes ?? new List<T>();
        }

        /// <summary>
        ///  Generic constructor
        /// </summary>
        public Chromosome()
        {
            this.genes = new List<T>();
        }

        /// <summary>
        /// Get and set the Chr fitness
        /// </summary>
        public double Fitness
        {
            get
            {
                if (!cachedFitness.HasValue)
                {
                    cachedFitness = fitnessFunction(this);
                }
                return cachedFitness.Value;
            }
        }

        /// <summary>
        /// Get the gene at specific index
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>T</returns>
        public T GetGene(int index)
        {
            return genes[index];
        }

        /// <summary>
        /// set a gene at a specific index
        /// </summary>
        /// <param name="index">The location in the Chr</param>
        /// <param name="gene">The gene to insert</param>
        public void SetGene(int index, T gene)
        {
            if (index < 0 || index >= genes.Count)
                throw new ArgumentOutOfRangeException("index", "Index is out of range.");
            genes[index] = gene;
            cachedFitness = null;
        }

        /// <summary>
        /// Add gene to the Chromosome
        /// </summary>
        /// <param name="gene">The gene type</param>
        public void Add(T gene)
        {
            genes.Add(gene);
            cachedFitness = null;
        }

        /// <summary>
        /// Add data as collection into the Chr
        /// </summary>
        /// <param name="geneCollection">The collection of data</param>
        public void AddGenes(IEnumerable<T> geneCollection)
        {
            genes.AddRange(geneCollection);
            cachedFitness = null;
        }

        /// <summary>
        /// Convert the Chromosome in a list
        /// </summary>
        /// <returns>List</returns>
        public List<T> ToList()
        {
            return new List<T>(genes);
        }
        
        /// <summary>
        /// Convert the Chromosome in Array;
        /// </summary>
        /// <returns>Array</returns>
        public T[] ToArray()
        {
            return genes.ToArray();
        }

        /// <summary>
        /// Fisher_Yates algorithm for the Chromosome
        /// </summary>
        public void Fisher_Yates()
        {
            int count = this.Count;

            for (int i = count - 1; i > 0; i--)
            {
                int index = Rand.NextInt(i, count);

                T temp = this.GetGene(i);

                this.SetGene(i, this.GetGene(index));
                this.SetGene(index, temp);
            }
        }

        /// <summary>
        /// Chromosome to String
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return string.Join(",", Chr);
        }





        
    }
}