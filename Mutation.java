/**
 * laga
 * A collection of classes to design and create Genetic Algorithms
 * http://designemergente.com
 *
 * Copyright (c) 2015 cidelab http://designemergente.com
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General
 * Public License along with this library; if not, write to the
 * Free Software Foundation, Inc., 59 Temple Place, Suite 330,
 * Boston, MA  02111-1307  USA
 * 
 * @author      cidelab http://designemergente.com
 * @modified    12/22/2015
 * @version     0.0.1 (1)
 */

package laga;
import processing.core.*;
import java.util.Random;

/**
 * The Mutation class has all the methods to create and initialize different flavors
 * of mutations on individuals, (not implemented yet).
 *
 */
public class Mutation{
	PApplet myParent;
	float popPercent;
	private int cant;
	private int[] arrIndex;
	LagaTools lagaT;
	
	/**
	 * The constructor takes two parameters, the first is the parent for processing 
	 * and the second is the mutation percent in the population. always a small number
	 * closer to 0.
	 *
	 */
	public Mutation(PApplet parent, float MutationRate)
	{
		myParent = parent;
		popPercent = MutationRate;
		lagaT = new LagaTools();
	}
	/**
	 * MutationSwap method.
	 * this method swap two or more alleles in the chromosome, same as RNA does in the DNA
	 * Don't forget implement a float parameter in the constructor.
	 *
	 * @param population 	-> population to be mutated.
	 * @param percentChrom  -> percent mutation in the chromsome 0 <= percentChrom <= 1.
	 * @return Object[][] population.
	 * 
	 * 
	 */
	public Object[][] MutationSwap(Object[][] population, float percentChrom)
	{
		cant = (int)(popPercent*population.length);
		if(cant == 0){cant = 1;}
		
		//clone the array.
		Object[][] mutatedPop = new Object[population.length][]; 
		for(int i = 0; i < population.length; i++) {
		    mutatedPop[i] = new Object[population[i].length];
		    System.arraycopy(population[i], 0, mutatedPop[i], 0, population[i].length);
		}
		
		//random list...
		int[] arrindex = new int[population.length];
		for(int i = 0; i < arrindex.length; ++i) arrindex[i] = i;
		arrindex =  lagaT.fisher_yates(arrindex); // fisher_yate(arrindex);
		
		for(int i = 0;  i < cant; ++i) //loop para 
		{
			mutationSwap(mutatedPop[arrindex[i]], percentChrom);
		}
		
		return mutatedPop;
	}
	private void mutationSwap(Object[] chrom, float p)
	{
		int size = (int)(chrom.length*p);
		if(size == 0){size = 1;}

		Random rnd = new Random();
		int index, index2;

		for(int i = 0; i < size; i++)
		{
			index = rnd.nextInt(chrom.length); // 0 <= j <= i-1

			do {
				index2 = rnd.nextInt(chrom.length);
			} while (index == index2);

			//swap
			Object temp = chrom[index];
			chrom[index] = chrom[index2];
			chrom[index2] = temp;
		}
	}

	/**
	 * MutationSwap method.
	 * this method swap two or more alleles in the chromosome, same as RNA does in the DNA
	 * Don't forget implement a float parameter in the constructor.
	 *
	 * @param population 	-> population to be mutated.
	 * @param percentChrom  -> percent mutation in the chromsome 0 <= percentChrom <= 1.
	 * @return double[][] population.
	 * 
	 * 
	 */
	public double[][] NumbMutation(double[][] pop, double min, double max, float percentChrom)
	{
		cant = (int)(popPercent*pop.length);
		if(cant == 0){cant = 1;}

		//clone the array.
		double[][] mutatedPop = new double[pop.length][]; 
		for(int i = 0; i < pop.length; i++) {
			mutatedPop[i] = new double[pop[i].length];
			System.arraycopy(pop[i], 0, mutatedPop[i], 0, pop[i].length);
		}
		
		int[] arrindex = new int[pop.length];
		for(int i = 0; i < arrindex.length; ++i) arrindex[i] = i;
		arrindex = lagaT.fisher_yates(arrindex); //fisher_yate(arrindex);
		
		for(int i = 0;  i < cant; ++i) //loop para 
		{
			DoubleMutation(mutatedPop[arrindex[i]], percentChrom, min, max);
		}
		
		return mutatedPop;
	}
	private void DoubleMutation(double[] mutatedPop, float percent, double min, double max)
	{
		int cant = (int)(mutatedPop.length * percent);
		if(cant == 0){cant = 1;}
		
		Random rnd = new Random();
		int rndIndex;
		for(int i = 0; i < cant; ++i)
		{
			rndIndex = rnd.nextInt(mutatedPop.length);
			mutatedPop[rndIndex] = min + rnd.nextFloat() * (max - min);
		}
	}
	
	/**
	 * MutationSwap method.
	 * this method swap two or more alleles in the chromosome, same as RNA does in the DNA
	 * Don't forget implement a float parameter in the constructor.
	 *
	 * @param population 	-> population to be mutated.
	 * @param percentChrom  -> percent mutation in the chromsome 0 <= percentChrom <= 1.
	 * @return float[][] population.
	 * 
	 * 
	 */
	public float[][] NumbMutation(float[][] pop, float min, float max, float percentChrom)
	{
		cant = (int)(popPercent*pop.length);
		if(cant == 0){cant = 1;}

		//clone the array.
		float[][] mutatedPop = new float[pop.length][]; 
		for(int i = 0; i < pop.length; i++) {
			mutatedPop[i] = new float[pop[i].length];
			System.arraycopy(pop[i], 0, mutatedPop[i], 0, pop[i].length);
		}
		
		int[] arrindex = new int[pop.length];
		for(int i = 0; i < arrindex.length; ++i) arrindex[i] = i;
		arrindex = lagaT.fisher_yates(arrindex); //fisher_yate(arrindex);
		
		for(int i = 0;  i < cant; ++i) //loop para 
		{
			FloatMutation(mutatedPop[arrindex[i]], percentChrom, min, max);
		}
		
		return mutatedPop;
	}
	private void FloatMutation(float[] mutatedPop, float percent, float min, float max)
	{
		int cant = (int)(mutatedPop.length * percent);
		if(cant == 0){cant = 1;}
		
		Random rnd = new Random();
		int rndIndex;
		for(int i = 0; i < cant; ++i)
		{
			rndIndex = rnd.nextInt(mutatedPop.length);
			mutatedPop[rndIndex] = min + rnd.nextFloat() * (max - min);
		}
	}
	
	/**
	 * MutationSwap method.
	 * this method swap two or more alleles in the chromosome, same as RNA does in the DNA
	 * Don't forget implement a float parameter in the constructor.
	 *
	 * @param population 	-> population to be mutated.
	 * @param percentChrom  -> percent mutation in the chromsome 0 <= percentChrom <= 1.
	 * @return int[][] population.
	 * 
	 * 
	 */
	public int[][] NumbMutation(int[][] pop, int min, int max, float percentChrom)
	{
		cant = (int)(popPercent*pop.length);
		if(cant == 0){cant = 1;}

		//clone the array.
		int[][] mutatedPop = new int[pop.length][]; 
		for(int i = 0; i < pop.length; i++) {
			mutatedPop[i] = new int[pop[i].length];
			System.arraycopy(pop[i], 0, mutatedPop[i], 0, pop[i].length);
		}
		
		int[] arrindex = new int[pop.length];
		for(int i = 0; i < arrindex.length; ++i) arrindex[i] = i;
		arrindex = lagaT.fisher_yates(arrindex); //fisher_yate(arrindex);
		
		for(int i = 0;  i < cant; ++i) //loop para 
		{
			intMutation(mutatedPop[arrindex[i]], percentChrom, min, max);
		}
		
		return mutatedPop;
	}
	private void intMutation(int[] mutatedPop, float percent, float min, float max)
	{
		int cant = (int)(mutatedPop.length * percent);
		if(cant == 0){cant = 1;}
		
		Random rnd = new Random();
		int rndIndex;
		for(int i = 0; i < cant; ++i)
		{
			rndIndex = rnd.nextInt(mutatedPop.length);
			mutatedPop[rndIndex] = (int)(min + rnd.nextFloat() * (max - min));
		}
	}
	
	/**
	 * The Method GenrMutation() takes two arguments. the population that is going to be mutated and the
	 * percent of the chromosome mutated.
	 *@param pop
	 * 				the population that is going to be mutated;
	 * @param Chromosomepercent
	 * 				the percent rate in the chromosome that is going to be mutated.
	 * @return a mutated population in the passed flavor.
	 */
	public char[][] CharMutation(char[][] pop, float ChroPercent)
	{
		SelectChromosomes(pop);
		int chroCant = (int)(pop[0].length * ChroPercent);
		if(chroCant == 0){ chroCant = 1;}
		
		//clone the array.
		char[][] mutatedPop = new char[pop.length][];
		for(int i = 0; i < pop.length; i++) 
		{
		    mutatedPop[i] = new char[pop[i].length];
		    System.arraycopy(pop[i], 0, mutatedPop[i], 0, pop[i].length);
		}
		
		char rndChar; //random Character to replace
		int pointer; //random pointer, for the index
		
		for(int i = 0; i < cant; ++i) //the loop for the population
		{ 
			for(int j = 0; j < chroCant; ++j) //the loop for the chromosomes
			{
				rndChar = lagaT.RandomChar(); // RandomChar();
				pointer = new Random().nextInt(pop[i].length);
				mutatedPop[arrIndex[i]][pointer] = rndChar;
			}
		}

		return mutatedPop;
	}

	private void SelectChromosomes(char[][] charPop)
	{
		//numbers and utilities..
		cant = (int)(popPercent*charPop.length);
		if(cant == 0){cant = 1;}
		
		int c;

		//random zone.
		Random rnd = new Random();
		int index;
		arrIndex = new int[cant];
		
		//loop to find random and not repeated indexes.
		for(int i = 0; i < cant; ++i)
		{
			do 
			{
				c = 0;
				index = rnd.nextInt(charPop.length);
				if(i > 0)
				{
					for(int j = 0; j < i; ++j)
					{
						if(arrIndex[j] == index)
						{
							c++;
						}
					}
					if(c == 0)
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

