using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laga.Geometry;
using Laga.Numbers;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// Generate DNA for Chromosome classes
    /// </summary>
    public static class GenrGenes
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="size"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="generator"></param>
        /// <returns>Chromosome</returns>
        public static Chromosome<T> RandomChromosome<T>(int size, T min, T max, Func<T, T, T> generator)
        {
            Chromosome<T> chrom = new Chromosome<T>(size);
            for (int i = 0; i < size; i++)
                chrom.Add(generator(min, max));
            return chrom;
        }
        /*
        /// <summary>
        /// The method generates a Chr composed by random doubles between min and max.
        /// </summary>
        /// <param name="size">the total doubles in the Chr</param>
        /// <param name="min">The min value in the Chr</param>
        /// <param name="max">The max value in the Chr (excluded)</param>
        /// <returns>double Chromosome</returns>
        public static Chromosome<double> Doubles(int size, double min, double max)
        {
            Chromosome<double> chrom = new Chromosome<double>();
            for (int i = 0; i < size; i++)
                chrom.Add(min + Rand.NextDouble() * (max - min));

            return chrom;
        }
  
        /// <summary>
        /// Generates a float Chr between min and max
        /// </summary>
        /// <param name="size">the number of floats in the Chr</param>
        /// <param name="min">min value</param>
        /// <param name="max">max value</param>
        /// <returns>float Chromosome</returns>
        public static Chromosome<float> Floats(int size, float min, float max)
        {
            Chromosome<float> ch = new Chromosome<float>();

            for (int i = 0; i < size; i++)
                ch.Add(Rand.NextFloat(min, max));

            return ch;
        }

        /// <summary>
        /// Generates a integer Chromosome between min and max
        /// </summary>
        /// <param name="size">the number of floats in the Chr</param>
        /// <param name="min">min value</param>
        /// <param name="max">max value</param>
        /// <returns>int Chromosome</returns>
        public static Chromosome<int> Integers(int size, int min, int max)
        {
            Chromosome<int> ch = new Chromosome<int>();

            for (int i = 0; i < size; i++)
                ch.Add(Rand.NextInt(min, max));

            return ch;
        }
        */
        /// <summary>
        /// Generates a binary Chromosome of 1s and 0s int type.
        /// </summary>
        /// /// <param name="size">the number of integers in the Chr</param> 
        /// <returns>int Chromosome</returns>
        public static Chromosome<int> Binary_Integer(int size)
        {
            Chromosome<int> arrChr = new Chromosome<int>();

            for (int i = 0; i < size; i++)
                arrChr.Add(Rand.NextDouble() >= 0.5 ? 1 : 0);

            return arrChr;
        }

        /// <summary>
        /// Generates a binary Chromosome of 1s and 0s char type.
        /// </summary>
        /// <param name="size">the length in the Chr</param> 
        /// <returns>char Chromosome</returns>
        public static Chromosome<char> Binary_Char(int size)
        {
            Chromosome<char> arrChr = new Chromosome<char>();

            for (int i = 0; i < size; i++)
                arrChr.Add(Rand.NextDouble() >= 0.5 ? '1' : '0');

            return arrChr;
        }

        /// <summary>
        /// Generates a random char Chromosome composed by characters.
        /// See <a href="http://www.asciitable.com/">this link</a> for more information.
        /// </summary>
        /// <param name="size">the length of characters in the Chr</param>
        /// <param name="start">the start number in the table, inclusive</param>
        /// <param name="end">the end number in the table, exclusive</param>
        /// <returns>char Chromosome</returns>
        public static Chromosome<char> Rand_Char(int size, int start, int end)
        {
            Chromosome<char> chr = new Chromosome<char>(size);

            for (int i = 0; i < size; i++)
                chr.Add(Rand.Character(start, end)); //chr.Add((char)rnd.Next(start, end)); 

            return chr;
        }

        /// <summary>
        /// Generates a random Vector chromosome
        /// </summary>
        /// <param name="size">the number of Vectors in the Chr</param>
        /// <param name="Xcoord">The range of values in the X coordinate</param>
        /// <param name="Ycoord">The range of values in the Y coordinate</param>
        /// <param name="Zcoord">The range of values in the Z coordinate</param>
        /// <returns>Vector Chromosome</returns>
        public static Chromosome<Vector> Rand_Vector(int size, Range Xcoord, Range Ycoord, Range Zcoord)
        {
            Chromosome<Vector> chrVector = new Chromosome<Vector>();
            for (int i = 0; i < size; i++)
                chrVector.Add(new Vector(Rand.NextDouble() * (Xcoord.Max - Xcoord.Min), Rand.NextDouble() * (Ycoord.Max - Ycoord.Min), Rand.NextDouble() * (Zcoord.Max - Zcoord.Min)));
        
            return chrVector;
        }

    }
}
