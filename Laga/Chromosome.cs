using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// 
    /// </summary>
    public class Chromosome
    {
        private int count;
        private float fitness;
          
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get
            {
                return chromosome.Count;
            }
        }
    
        /// <summary>
        /// 
        /// </summary>
        public List<char> chromosome { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public char GetDNA(int index)
        {
            return chromosome[index];
        }

        /// <summary>
        /// 
        /// </summary>
        public float Fitness
        {
            get
            {
                return fitness;
            }
            set
            {
                fitness = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="DNA"></param>
        public void SetDNA(int index, char DNA)
        {
            chromosome[index] = DNA;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Size"></param>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        public Chromosome(int Size, int Start, int End)
        {
            count = Size;
            chromosome = new GenrChromosome(Size).CharChromosome(Start, End).ToList<char>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Size"></param>
        public Chromosome(int Size)
        {
            count = Size;
            chromosome = new GenrChromosome(Size).CharChromosomeBinary().ToList<char>();
        }

        /// <summary>
        /// 
        /// </summary>
        public Chromosome()
        {
           chromosome = new List<char>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Dna"></param>
        public void Add(char Dna)
        {
            chromosome.Add(Dna);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Chrom2String()
        {
            return new string(chromosome.ToArray());
        }

    }
}
