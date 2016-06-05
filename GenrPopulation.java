package laga;
import java.util.Random;
import processing.core.PApplet;

/**
 * The GenrPopulation class has all the methods to create and initialise different flavours
 * of populations, this class must be called to create the first random population. 
 */

public class GenrPopulation {
	
	PApplet myParent;
	
	LagaTools lgTools;
	
	public GenrPopulation (PApplet theParent) {
		myParent = theParent;
		lgTools = new LagaTools();
	}
	
	/**
	 * ObjectPopulationSwap.
	 * Create a random population based on seed of Object[] chromosome.
	 * this method is designed for combinatorial problems.
	 * 
	 * @param sizePopulation -> the size of the population;
	 * @param seedChromosome -> the seed chromosome to create the population.
	 * @param percent 		 -> the mutation percent in the population 0 <= percent <= 1
	 * @param InOut 		 -> if is true the seed will be included in the population
	 * @return a population in the flavour Object[][] based on a seed Object[] chromosome.
	 * 
	 * 
	 */
	public Object[][] ObjectPopulationSwap(int sizePopulation, Object[] SeedChromosome, float percent, boolean InOut)
	{
		
		Object[][] pop = new Object[sizePopulation][];
		Object[] copyChromosome;
		
		for(int i = 0; i < sizePopulation; ++i)
		{
			copyChromosome= new Object[SeedChromosome.length];
			System.arraycopy(SeedChromosome, 0, copyChromosome, 0, SeedChromosome.length);
			if((i == 0)&&(InOut))
			{
				pop[i] = SeedChromosome;
			}
			else
			{
				pop[i] = lgTools.fisher_yatesPercent(copyChromosome, percent);
			}
		}
		
		return pop;
		
	}
	
	/**
	 * NumberPopulation method.
	 * Create a Random population by float numbers.
	 * 
	 * @param sizePopulation -> the size of the population;
	 * @param sizeChromosome -> the length of each Chromosome in the population.
	 * @param min -> the minimum value in the chromosome;
	 * @param max -> the maximum value in the chromosome;.
	 * @return a NumberPopulation in the flavour double[][].
	 * 
	 * 
	 */
	public double[][] NumbPopulation(int sizePopulation, int sizeChromosome, double min, double max)
	{
		double[][] pop = new double[sizePopulation][];
		double[] chromosome;
		
		Random rnd = new Random();
		for(int i = 0; i < sizePopulation; ++i)
		{
			chromosome = new double[sizeChromosome];
			for(int j = 0; j< sizeChromosome; ++j)
			{
				chromosome[j] = min + rnd.nextDouble() * (max - min);
			}
			pop[i] = chromosome;
		}
		return pop;
	}

	/**
	 * NumberPopulation method.
	 * Create a Random population by float numbers.
	 * 
	 * @param sizePopulation -> the size of the population;
	 * @param sizeChromosome -> the length of each Chromosome in the population.
	 * @param min -> the minimum value in the chromosome;
	 * @param max -> the maximum value in the chromosome;.
	 * @return a NumberPopulation in the flavor float[][].
	 * 
	 * 
	 */
	public float[][] NumbPopulation(int sizePopulation, int sizeChromosome, float min, float max)
	{
		float[][] pop = new float[sizePopulation][];
		float[] chromosome;
		
		Random rnd = new Random();
		for(int i = 0; i < sizePopulation; ++i)
		{
			chromosome = new float[sizeChromosome];
			for(int j = 0; j< sizeChromosome; ++j)
			{
				chromosome[j] = min + rnd.nextFloat() * (max - min);
			}
			pop[i] = chromosome;
		}
		return pop;
	}
	
	/**
	 * NumberPopulation method.
	 * Create a Random population by integers chromosome.
	 * 
	 * @param sizePopulation -> the size of the population;
	 * @param sizeChromosome -> the length of each Chromosome in the population.
	 * @param min 			 -> the minimum value in the chromosome;
	 * @param max 			 -> the maximum value in the chromosome;.
	 * @return a NumberPopulation in the flavor int[][].
	 * 
	 * 
	 */
	public int[][] NumbPopulation(int sizePopulation, int sizeChromosome, int min, int max)
	{
		int[][] pop = new int[sizePopulation][];
		int[] chromosome;
		
		Random rnd = new Random();
		for(int i = 0; i < sizePopulation; ++i)
		{
			chromosome = new int[sizeChromosome];
			for(int j = 0; j< sizeChromosome; ++j)
			{
				chromosome[j] = (int)(min + rnd.nextFloat() * ((max+1) - min));
			}
			pop[i] = chromosome;
		}
		return pop;
	}

	/**
	 * NumberPopulationSwap method.
	 * Create a Random population by integer numbers from 0 to the max value (not inclusive).
	 * designed by combinatorial problems...
	 * 
	 * @param sizePopulation -> the size of the population;
	 * @param max -> the maximum value in the chromosome;.
	 * @return a NumberPopulation in the flavor int[][].
	 * 
	 */
	public int[][] NumbPopulationSwap(int sizePopulation, int max)
	{

		int[][] pop = new int[sizePopulation][];
		int[] chromosome = new int[max];
		
		for(int i = 0; i < max; ++i) { chromosome[i] = i;}
		
		for(int i = 0; i < sizePopulation; ++i)
		{
			pop[i] = lgTools.fisher_yates(chromosome);
		}
		return pop;
	}

	/**
	 * BinaryPopulation.
	 * Create a Random binary population.
	 * 
	 * @param sizePopulation -> the size of the population;
	 * @param sizeChromosome -> the length of each chromosome in the population.
	 * @return a population in the flavor int[][] in the type 1010110101.
	 * 
	 * 
	 */
	public int[][] BinaryPopulationInt(int sizePopulation, int sizeChromosome)
	{
		int[][] pop = new int[sizePopulation][];
		int[] chromosome;

		Random rnd = new Random();
		for(int i = 0; i < sizePopulation; ++i)
		{
			chromosome = new int[sizeChromosome];
			for(int j = 0; j< sizeChromosome; ++j)
			{
				if(rnd.nextFloat() < 0.5)
				{
					chromosome[j] = 1;
				}
				else
				{
					chromosome[j] = 0;
				}
			}
			pop[i] = chromosome;
		}
		return pop;
	}
	
	/**
	 * BinaryPopulation.
	 * Create a Random binary population.
	 * 
	 * @param sizePopulation -> the size of the population;
	 * @param sizeChromosome -> the length of each chromosome in the population.
	 * @return a population in the flavor char[] of type 1010110101.
	 * 
	 * 
	 */
	public char[][] BinaryPopulationChr(int sizePopulation, int sizeChromosome)
	{
		char[][] pop = new char[sizePopulation][sizeChromosome];
		char[] arrChr;
		
		for(int i = 0; i < sizePopulation; ++i)
		{
			arrChr = new char[sizeChromosome];
			for(int j = 0; j< sizeChromosome; ++j)
			{
				arrChr[j] = lgTools.RandomCharBinary();
			}
			
			pop[i] = arrChr;
		}
		return pop;
	}

	/**
	 * CharPopulation method.
	 * Create a Random population by characters chromosome in the flavor charChromosome method
	 * 
	 * @param sizePopulation -> the size of the population;
	 * @param sizeChromosome -> the length of each Chromosome in the population.
	 * @return a charPopulation in the flavor char[][].
	 * 
	 * 
	 */
	public char[][] CharPopulation(int sizePopulation, int sizeChromosome)
	{
		int index;
		char[] chromosome;
		char[][] charPopulation = new char[sizePopulation][];
		
		Random rnd = new Random();
		for(int i = 0; i < sizePopulation; ++i)
		{
			chromosome = new char[sizeChromosome];
			for(int j = 0; j < sizeChromosome; ++j)
			{
				if(rnd.nextFloat() < 0.8)
				{
					index = rnd.nextInt(26) + 97;
				}
				else
				{
					index = 95;
				}
				chromosome[j] = (char)index;
			}
			charPopulation[i] = chromosome;
		}
		
		return charPopulation;
	}
}