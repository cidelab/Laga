using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    public class Chromosome
    {
        private int i;
        private int count;
        public int Count
        {
            get
            {
                return chromosome.Count;
            }
        }
    
        public List<char> chromosome { get; set; }

        public char GetDNA(int index)
        {
            return chromosome[index];
        }

        public void SetDNA(int index, char DNA)
        {
            chromosome[index] = DNA;
        }
        
        public Chromosome(int Size, int Start, int End)
        {
            count = Size;
            chromosome = new GenrChromosome(Size).CharChromosome(Start, End).ToList<char>();
        }

        public Chromosome(int Size)
        {
            count = Size;
            chromosome = new GenrChromosome(Size).CharChromosomeBinary().ToList<char>();
        }

        public Chromosome()
        {
           chromosome = new List<char>();
        }

        public void Add(char Dna)
        {
            chromosome.Add(Dna);
        }

        public string Chrom2String()
        {
            return new string(chromosome.ToArray());
        }

    }
}
