using System;

namespace Laga
{
    public class Mutation
    {
        private float popPercent;
        private int cant;
        private int[] arrIndex;
        LagaTools lagaT;
        private Random rnd;

        public Mutation(float MutationRate)
        {
            popPercent = MutationRate;
            lagaT = new LagaTools();
            rnd = new Random((int)DateTime.Now.Millisecond);
        }

        public object[][] MutationSwap(object[][] population, float percentChrom)
        {
            cant = (int)(popPercent * population.Length);
            if (cant == 0) { cant = 1; }

            //clone the array.
            object[][] mutatedPop = population.Clone() as object[][];

            //random list...
            int[] arrindex = new int[population.Length];
            for (int i = 0; i < arrindex.Length; ++i) arrindex[i] = i;
            arrindex = lagaT.Fisher_Yates(arrindex); // fisher_yate(arrindex);

            for (int i = 0; i < cant; ++i) //loop para 
            {
                mutationSwap(mutatedPop[arrindex[i]], percentChrom);
            }

            return mutatedPop;
        }
        private void mutationSwap(object[] chrom, float p)
        {
            int size = (int)(chrom.Length * p);
            if (size == 0) { size = 1; }

            int index, index2;

            for (int i = 0; i < size; i++)
            {
                index = rnd.Next(chrom.Length); // 0 <= j <= i-1

                do
                {
                    index2 = rnd.Next(chrom.Length);
                } while (index == index2);

                //swap
                object temp = chrom[index];
                chrom[index] = chrom[index2];
                chrom[index2] = temp;
            }
        }

        public double[][] NumbMutation(double[][] pop, double min, double max, float percentChrom)
        {
            cant = (int)(popPercent * pop.Length);
            if (cant == 0) { cant = 1; }

            //clone the array.
            double[][] mutatedPop = pop.Clone() as double[][];

            int[] arrindex = new int[pop.Length];
            for (int i = 0; i < arrindex.Length; ++i) arrindex[i] = i;
            arrindex = lagaT.Fisher_Yates(arrindex); //fisher_yate(arrindex);

            for (int i = 0; i < cant; ++i) //loop para 
            {
                DoubleMutation(mutatedPop[arrindex[i]], percentChrom, min, max);
            }

            return mutatedPop;
        }
        private void DoubleMutation(double[] mutatedPop, float percent, double min, double max)
        {
            int cant = (int)(mutatedPop.Length * percent);
            if (cant == 0) { cant = 1; }

            Random rnd = new Random();
            int rndIndex;
            for (int i = 0; i < cant; ++i)
            {
                rndIndex = rnd.Next(mutatedPop.Length);
                mutatedPop[rndIndex] = min + rnd.NextDouble() * (max - min);
            }
        }

        public float[][] NumbMutation(float[][] pop, float min, float max, float percentChrom)
        {
            cant = (int)(popPercent * pop.Length);
            if (cant == 0) { cant = 1; }

            //clone the array.
            float[][] mutatedPop = pop.Clone() as float[][];

            int[] arrindex = new int[pop.Length];
            for (int i = 0; i < arrindex.Length; ++i) arrindex[i] = i;
            arrindex = lagaT.Fisher_Yates(arrindex); //fisher_yate(arrindex);

            for (int i = 0; i < cant; ++i) //loop para 
            {
                FloatMutation(mutatedPop[arrindex[i]], percentChrom, min, max);
            }

            return mutatedPop;
        }
        private void FloatMutation(float[] mutatedPop, float percent, float min, float max)
        {
            int cant = (int)(mutatedPop.Length * percent);
            if (cant == 0) { cant = 1; }

            int rndIndex;
            for (int i = 0; i < cant; ++i)
            {
                rndIndex = rnd.Next(mutatedPop.Length);
                mutatedPop[rndIndex] = (float)(min + rnd.NextDouble() * (max - min));
            }
        }

        public int[][] NumbMutation(int[][] pop, int min, int max, float percentChrom)
        {
            cant = (int)(popPercent * pop.Length);
            if (cant == 0) { cant = 1; }

            //clone the array.
            int[][] mutatedPop = pop.Clone() as int[][];

            int[] arrindex = new int[pop.Length];
            for (int i = 0; i < arrindex.Length; ++i) arrindex[i] = i;
            arrindex = lagaT.Fisher_Yates(arrindex); //fisher_yate(arrindex);

            for (int i = 0; i < cant; ++i) //loop para 
            {
                intMutation(mutatedPop[arrindex[i]], percentChrom, min, max);
            }

            return mutatedPop;
        }
        private void intMutation(int[] mutatedPop, float percent, float min, float max)
        {
            int cant = (int)(mutatedPop.Length * percent);
            if (cant == 0) { cant = 1; }

            int rndIndex;
            for (int i = 0; i < cant; ++i)
            {
                rndIndex = rnd.Next(mutatedPop.Length);
                mutatedPop[rndIndex] = (int)(min + rnd.NextDouble() * (max - min));
            }
        }

        public char[][] BinaryCharMutation(char[][] pop, float ChroPercent)
        {
            SelectChromosomes(pop);
            int chroCant = (int)(pop[0].Length * ChroPercent);
            if (chroCant == 0) { chroCant = 1; }

            //clone the array.
            char[][] mutatedPop = pop.Clone() as char[][];

            char rndChar; //random Character to replace
            int pointer; //random pointer, for the index

            for (int i = 0; i < cant; ++i) //the loop for the population
            {
                for (int j = 0; j < chroCant; ++j) //the loop for the chromosomes
                {
                    rndChar = lagaT.RandomCharBinary(1.0f);
                    pointer = rnd.Next(pop[i].Length);
                    mutatedPop[arrIndex[i]][pointer] = rndChar;
                }
            }

            return mutatedPop;
        }

        public char[][] CharMutation(char[][] pop, float ChroPercent, int start, int end)
        {
            SelectChromosomes(pop);
            int chroCant = (int)(pop[0].Length * ChroPercent);
            if (chroCant == 0) { chroCant = 1; }

            //clone the array.
            char[][] mutatedPop = pop.Clone() as char[][];

            char rndChar; //random Character to replace
            int pointer; //random pointer, for the index

            for (int i = 0; i < cant; ++i) //the loop for the population
            {
                for (int j = 0; j < chroCant; ++j) //the loop for the chromosomes
                {
                    rndChar = lagaT.RandomChar(start, end); // RandomChar();
                    pointer = rnd.Next(pop[i].Length);
                    mutatedPop[arrIndex[i]][pointer] = rndChar;
                }
            }

            return mutatedPop;
        }

        private void SelectChromosomes(char[][] charPop)
        {
            //numbers and utilities..
            cant = (int)(popPercent * charPop.Length);
            if (cant == 0) { cant = 1; }

            int c;

            //random zone.
            Random rnd = new Random();
            int index;
            arrIndex = new int[cant];

            //loop to find random and not repeated indexes.
            for (int i = 0; i < cant; ++i)
            {
                do
                {
                    c = 0;
                    index = rnd.Next(charPop.Length);
                    if (i > 0)
                    {
                        for (int j = 0; j < i; ++j)
                        {
                            if (arrIndex[j] == index)
                            {
                                c++;
                            }
                        }
                        if (c == 0)
                        {
                            arrIndex[i] = index;
                        }
                    }
                    else
                    {
                        arrIndex[i] = index;
                    }
                } while (c != 0);
            }
        }
    }
}
