package laga;
import java.util.Random;
import processing.core.PApplet;

/**
 * The GenrChromosome class has all the methods to create and initialize different flavors
 * of chromosomes:
 */

public class GenrChromosome {
	
	PApplet myParent;
	//private int[] arrIndex;
	LagaTools lgTools;
	
	public GenrChromosome (PApplet theParent) {
		myParent = theParent;
		lgTools = new LagaTools();
	}
	/**
	 * the method generate a number chromosome composed by random numbers between a 
	 * minimum parameter and a maximum parameter. The method is based on double numbers.
	 *
	 * @param sizeChromosome -> the size of the chromosome
	 * @param minParam 		 -> the smallest value in the chromosome
	 * @param maxParam 		 -> the bigger value in the chromosome
	 * @return double random chromosome
	 * 
	 */
	public double[] NumberChromosome(int sizeChromosome, double minParam, double maxParam) 
	{
		double[] pop = new double[sizeChromosome];
		Random rand = new Random();
		
		for(int i = 0; i < sizeChromosome; ++i)
		{
			pop[i] = minParam + rand.nextDouble() * (maxParam - minParam);
		}
		
		return pop;
	}

	/**
	 * the method generate a number chromosome composed by random numbers between a 
	 * minimum parameter and a maximum parameter.
	 * the method is based on float numbers.
	 *
	 * @param sizeChromosome -> the size of the chromosome
	 * @param minParam 		 -> the smallest value in the chromosome
	 * @param maxParam 		 -> the bigger value in the chromosome
	 * @return float list in the flavor: float[]
	 * 
	 */
	public float[] NumberChromosome(int sizeChromosome, float minParam, float maxParam) 
	{
		float[] pop = new float[sizeChromosome];
		Random rand = new Random();
		
		for(int i = 0; i < sizeChromosome; ++i)
		{
			pop[i] = minParam + rand.nextFloat() * (maxParam - minParam);
		}
		
		return pop;
	}
	
	/**
	 * the method generate a number chromosome composed by random numbers between a 
	 * minimum parameter and a maximum parameter.
	 * the method is based on int numbers.
	 * 
	 * @param sizeChromosome -> the size of the chromosome
	 * @param minParam 		 -> the smallest value in the chromosome
	 * @param maxParam 		 -> the bigger value in the chromosome
	 * @return int list in the flavor: int[]
	 * 
	 */
	public int[] NumberChromosome(int sizeChromosome, int minParam, int maxParam) 
	{
		int[] pop = new int[sizeChromosome];
		Random rand = new Random();
		
		for(int i = 0; i < sizeChromosome; ++i)
		{
			pop[i] =  rand.nextInt((maxParam - minParam ) + 1 ) + minParam;
		}
		
		return pop;
	}

	/**
	 * This method generate a binary chromosome composed by 1s and 0s in random flavor...
	 * 
	 * @param sizeChromosome -> the size of the population
	 * @return Integer list in the flavor: int[]
	 * 
	 */
	public int[] BinaryChromosome(int sizeChromosome) 
	{
		int[] pop = new int[sizeChromosome];
		int binary;
		
		double v;
		Random rand = new Random();
		
		for(int i = 0; i < sizeChromosome; ++i)
		{
			v = rand.nextDouble();
			if(v < 0.5)
			{
				binary = 0;
			}
			else
			{
				binary = 1;
			}
			pop[i] = binary;
		}
		return pop;
	}

	/**
	 * this method generate a character chromosome composed by lower case characters 
	 * and spaces in a random flavor.
	 * composed by singles characters from a to z plus (space)
	 * 
	 * @param sizeChromosome -> the size of the population
	 * @return char list in the flavor: char[]
	 *  
	 */
	public char[] CharChromosome(int sizeChromosome) 
	{
		int index;
		char[] pop = new char[sizeChromosome];
		Random rand = new Random();
		
		for(int i = 0; i < sizeChromosome; ++i)
		{
			if(rand.nextFloat() < 0.8)
			{
				index = rand.nextInt(26) + 97;
			}
			else
			{
				index = 95;
			}

			pop[i] = (char)index;
		}
		return pop;
	}

	/**
	 * the method generate a number chromosome composed by non repeated numbers between 0 and sizeChromosome(not inclusive).
	 * the method is based on integer numbers. this method is designed by combinatorial problems.
	 * 
	 * @param sizeChromosome -> the size of the chromosome
	 * @return int list in the flavor: int[]
	 * 
	 */
	public int[] NumberChromosomeSwap(int sizeChromosome) 
	{
		int[] pop = new int[sizeChromosome];
		
		for(int i = 0; i < sizeChromosome; ++i)
		{
			pop[i] = i;
		}
		pop = lgTools.fisher_yates(pop); 
		return pop;
	}

}
