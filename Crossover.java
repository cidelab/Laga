package laga;
import java.util.Random;
import processing.core.PApplet;

public class Crossover {
	
	PApplet myParent;
	private int[] arrIndex;
	
	public Crossover (PApplet theParent) {
		myParent = theParent;
	}
	
	/**
	 * SinglePointCrossover method.
	 * Single Method prepared to recieve any type of class, ideal for combintorial problems.
	 * 
	 * @param population  -> An object type population.
	 * @param percent     -> Number between 0.0 and 1.0 to represent the percent of crossover in the population.
	 * @param pointCutter -> An integer to represent where you want to cut the chromosome for the crossover.
	 * 
	 * 
	 */
	public Object[][] SinglePointCrossover(Object[][] population, float percent, int pointCutter)
	{
		SelectDadMom(population, percent); //call the method to determine who with who is going to have sex. 
		Object[] dad;
		Object[] mom;
		Object[] son1;
		Object[] son2;
		
		Object[][] inherencePop = new Object[arrIndex.length][];
		
		//clone the array.
		Object[][] crossPop = new Object[population.length][];
		for(int i = 0; i < population.length; i++) {
			crossPop[i] = new Object[population[i].length];
		    System.arraycopy(population[i], 0, crossPop[i], 0, population[i].length);
		}
		
		for(int i = 0; i < arrIndex.length - 1; i += 2)
		{
			dad = crossPop[arrIndex[i]];
			mom = crossPop[arrIndex[i+1]];
			son1 = new Object[dad.length];
			son2 = new Object[mom.length];

			int t = pointCutter;
			int t2 = pointCutter;

			for(int j = 0; j < pointCutter; ++j)
			{
				son1[j] = dad[j];
				son2[j] = mom[j];
			}
			
			for(int j = 0; j < mom.length; ++j)
			{
				for(int k = pointCutter; k < dad.length; ++k)
				{
					if(mom[j].equals(dad[k]))
					{
						son1[t] = mom[j];
						t++;
					}
				}
			}
			
			for(int j = 0; j < dad.length; ++j)
			{
				for(int k = pointCutter; k < mom.length; ++k)
				{
					if(dad[j].equals(mom[k]))
					{
						son2[t2] = dad[j];
						t2++;
					}
				}
			}
			inherencePop[i] = son1;
			inherencePop[i + 1] = son2;
		}
		return inherencePop;
	}
	private void SelectDadMom(Object[][] charPop, float percent)
	{
		//numbers and utilities..
		int size = (int)(percent*charPop.length);
		
		if(size % 2 == 1) {
			size--;
		}
		int c;

		//random zone.
		Random rnd = new Random();
		int index;
		arrIndex = new int[size];
		
		//loop to find random and not repeated indexes.
		for(int i = 0; i < size; ++i)
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
	/**
	* SinglePointCrossover method.
	 * Single Method prepared to recieve any type of class, ideal for combintorial problems.
	 * 
	 * @param population  -> An object type population.
	 * @param percent     -> Number between 0.0 and 1.0 to represent the percent of crossover in the population.
	 * @param pointCutter -> An integer to represent where you want to cut the chromosome for the crossover.
	 * 
	 * 
	 */
	public double[][] SinglePointCrossover(double[][] population, float percent, int pointCutter)
	{
		SelectDadMom(population, percent); //call the method to determine who with who is going to have sex. 
		double[] dad;
		double[] mom;
		double[] son1;
		double[] son2;
		
		double[][] inherencePop = new double[arrIndex.length][];
		
		//clone the array.
		double[][] crossPop = new double[population.length][];
		for(int i = 0; i < population.length; i++) {
			crossPop[i] = new double[population[i].length];
		    System.arraycopy(population[i], 0, crossPop[i], 0, population[i].length);
		}
		
		for(int i = 0; i < arrIndex.length - 1; i += 2)
		{
			dad = crossPop[arrIndex[i]];
			mom = crossPop[arrIndex[i+1]];
			son1 = new double[dad.length];
			son2 = new double[mom.length];

			for(int j = 0; j < pointCutter; ++j)
			{
				son1[j] = dad[j];
				son2[j] = mom[j];
			}

			for(int k = pointCutter; k < dad.length; ++k)
			{
				son1[k] = mom[k];
				son2[k] = dad[k];
			}
			
			inherencePop[i] = son1;
			inherencePop[i + 1] = son2;
		}
		return inherencePop;
	}
	private void SelectDadMom(double[][] charPop, float percent)
	{
		//numbers and utilities..
		int size = (int)(percent*charPop.length);
		
		if(size % 2 == 1) {
			size--;
		}
		int c;

		//random zone.
		Random rnd = new Random();
		int index;
		arrIndex = new int[size];
		
		//loop to find random and not repeated indexes.
		for(int i = 0; i < size; ++i)
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
	/**
	 * SinglePointCrossover method.
	 * Single Method prepared to recieve any type of class, ideal for combintorial problems.
	 * 
	 * @param population  -> An object type population.
	 * @param percent     -> Number between 0.0 and 1.0 to represent the percent of crossover in the population.
	 * @param pointCutter -> An integer to represent where you want to cut the chromosome for the crossover.
	 * 
	 * 
	 */
	public float[][] SinglePointCrossover(float[][] population, float percent, int pointCutter)
	{
		SelectDadMom(population, percent); //call the method to determine who with who is going to have sex. 
		float[] dad;
		float[] mom;
		float[] son1;
		float[] son2;
		
		float[][] inherencePop = new float[arrIndex.length][];
		
		//clone the array.
		float[][] crossPop = new float[population.length][];
		for(int i = 0; i < population.length; i++) {
			crossPop[i] = new float[population[i].length];
		    System.arraycopy(population[i], 0, crossPop[i], 0, population[i].length);
		}
		
		for(int i = 0; i < arrIndex.length - 1; i += 2)
		{
			dad = crossPop[arrIndex[i]];
			mom = crossPop[arrIndex[i+1]];
			son1 = new float[dad.length];
			son2 = new float[mom.length];

			for(int j = 0; j < pointCutter; ++j)
			{
				son1[j] = dad[j];
				son2[j] = mom[j];
			}

			for(int k = pointCutter; k < dad.length; ++k)
			{
				son1[k] = mom[k];
				son2[k] = dad[k];
			}
			
			inherencePop[i] = son1;
			inherencePop[i + 1] = son2;
		}
		return inherencePop;
	}
	private void SelectDadMom(float[][] charPop, float percent)
	{
		//numbers and utilities..
		int size = (int)(percent*charPop.length);
		
		if(size % 2 == 1) {
			size--;
		}
		int c;

		//random zone.
		Random rnd = new Random();
		int index;
		arrIndex = new int[size];
		
		//loop to find random and not repeated indexes.
		for(int i = 0; i < size; ++i)
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
	/**
	 * SinglePointCrossover method.
	 * Single Method prepared to recieve any type of class, ideal for combintorial problems.
	 * 
	 * @param population  -> An object type population.
	 * @param percent     -> Number between 0.0 and 1.0 to represent the percent of crossover in the population.
	 * @param pointCutter -> An integer to represent where you want to cut the chromosome for the crossover.
	 * 
	 * 
	 */
	public int[][] SinglePointCrossover(int[][] population, float percent, int pointCutter)
	{
		SelectDadMom(population, percent); //call the method to determine who with who is going to have sex. 
		int[] dad;
		int[] mom;
		int[] son1;
		int[] son2;
		
		int[][] inherencePop = new int[arrIndex.length][];
		
		//clone the array.
		int[][] crossPop = new int[population.length][];
		for(int i = 0; i < population.length; i++) {
			crossPop[i] = new int[population[i].length];
		    System.arraycopy(population[i], 0, crossPop[i], 0, population[i].length);
		}
		
		for(int i = 0; i < arrIndex.length - 1; i += 2)
		{
			dad = crossPop[arrIndex[i]];
			mom = crossPop[arrIndex[i+1]];
			son1 = new int[dad.length];
			son2 = new int[mom.length];

			for(int j = 0; j < pointCutter; ++j)
			{
				son1[j] = dad[j];
				son2[j] = mom[j];
			}

			for(int k = pointCutter; k < dad.length; ++k)
			{
				son1[k] = mom[k];
				son2[k] = dad[k];
			}
			
			inherencePop[i] = son1;
			inherencePop[i + 1] = son2;
		}
		return inherencePop;
	}
	private void SelectDadMom(int[][] charPop, float percent)
	{
		//numbers and utilities..
		int size = (int)(percent*charPop.length);
		
		if(size % 2 == 1) {
			size--;
		}
		int c;

		//random zone.
		Random rnd = new Random();
		int index;
		arrIndex = new int[size];
		
		//loop to find random and not repeated indexes.
		for(int i = 0; i < size; ++i)
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
	/**
	 * SinglePointCrossover method.
	 * Single Method prepared to receive a char type population.
	 * 
	 * @param population  -> An object type population.
	 * @param percent     -> Number between 0.0 and 1.0 to represent the percent of crossover in the population.
	 * @param pointCutter -> An integer to represent where you want to cut the chromosome for the crossover.
	 * 
	 * 
	 */
	public char[][] SinglePointCrossover(char[][] population, float percent, int pointCutter)
	{
		SelectDadMom(population, percent); //call the method to determine who with who is going to have sex. 
		
		char[][] inherencePop = new char[arrIndex.length][];
		int count = 0;
		
		//clone the array.
		char[][] crossPop = new char[population.length][];
		for(int i = 0; i < population.length; i++) {
			crossPop[i] = new char[population[i].length];
		    System.arraycopy(population[i], 0, crossPop[i], 0, population[i].length);
		}
		
		for(int i = 0; i < arrIndex.length - 1; i += 2)
		{
			
			char[] dad = crossPop[arrIndex[i]];
			char[] mom = crossPop[arrIndex[i+1]];
		
			char[] son1 = new char[dad.length];
			char[] son2 = new char[mom.length];

			for(int j = 0; j < pointCutter; ++j)
			{
				son1[j] = dad[j];
				son2[j] = mom[j];
			}

			for(int k = pointCutter; k < dad.length; ++k)
			{
				son1[k] = mom[k];
				son2[k] = dad[k];
			}

			inherencePop[count] = son1;
			inherencePop[count + 1] = son2;
			
			count += 2;
		}
		return inherencePop;
	}
	private void SelectDadMom(char[][] charPop, float percent)
	{
		//numbers and utilities..
		int size = (int)(percent*charPop.length);
		
		if(size % 2 == 1) {
			size--;
		}
		int c;

		//random zone.
		Random rnd = new Random();
		int index;
		arrIndex = new int[size];
		
		//loop to find random and not repeated indexes.
		for(int i = 0; i < size; ++i)
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
