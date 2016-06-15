package laga;

import processing.core.*;

/**
 * The RankingSort class has all the methods to create and initialise the bidirectional BubbleSort algorithm.
 */
public class RankingSort 
{
	PApplet myParent;
	LagaCasting lc = new LagaCasting();
	
	Object[][] objPopulation;
	double[][] dblPopulation;
	float[][] fltPopulation;
	int[][] intPopulation;
	char[][] srtPopulation;

	float[] fltArrResults;
	int[] intArrResults;

	public RankingSort(PApplet parent)
	{
		myParent = parent;
	}
	/**
	 *An optimised BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(Object[][] population, float[] arrResults, boolean minmax)
	{
		int j;
		int st = -1;
		int n = arrResults.length;
		
		while (st <  n) 
		{
			st++;
			n--;
			
			for (j = st; j <  n; j++) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					float T = arrResults[j];
					Object[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
			for (j =  n; --j >= st;) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					float T = arrResults[j];
					Object[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
		}
		
		if(minmax)
		{
			lc.Reverse(arrResults);
			lc.ReversePopulation(population);
		}
		
		objPopulation = population;
		fltArrResults = arrResults;
	}
	/**
	 *An optimised BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(Object[][] population, int[] arrResults, boolean minmax)
	{
		int j;
		int st = -1;
		int n = arrResults.length;
		
		while (st <  n) 
		{
			st++;
			n--;
			
			for (j = st; j <  n; j++) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					int T = arrResults[j];
					Object[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
			for (j =  n; --j >= st;) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					int T = arrResults[j];
					Object[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
		}
		
		if(minmax)
		{
			lc.Reverse(arrResults);
			lc.ReversePopulation(population);
		}
		
		objPopulation = population;
		intArrResults = arrResults;
	}
	/**
	 *An optimised BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(double[][] population, float[] arrResults, boolean minmax)
	{
		int j;
		int st = -1;
		int n = arrResults.length;
		
		while (st <  n) 
		{
			st++;
			n--;
			
			for (j = st; j <  n; j++) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					float T = arrResults[j];
					double[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
			for (j =  n; --j >= st;) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					float T = arrResults[j];
					double[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
		}
		
		if(minmax)
		{
			lc.Reverse(arrResults);
			lc.ReversePopulation(population);
		}
		
		dblPopulation = population;
		fltArrResults = arrResults;
	}
	/**
	 *An optimised BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(double[][] population, int[] arrResults, boolean minmax)
	{
		int j;
		int st = -1;
		int n = arrResults.length;


		while (st <  n) 
		{
			st++;
			n--;

			for (j = st; j <  n; j++) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					int T = arrResults[j];
					double[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
			for (j =  n; --j >= st;) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					int T = arrResults[j];
					double[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
		}
		
		if(minmax)
		{
			lc.Reverse(arrResults);
			lc.ReversePopulation(population);
		}

		dblPopulation = population;
		intArrResults = arrResults;

	}
	/**
	 *An optimised BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(float[][] population, float[] arrResults, boolean minmax)
	{
		int j;
		int st = -1;
		int n = arrResults.length;
		
		while (st <  n) 
		{
			st++;
			n--;
			
			for (j = st; j <  n; j++) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					float T = arrResults[j];
					float[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
			for (j =  n; --j >= st;) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					float T = arrResults[j];
					float[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
		}
		
		if(minmax)
		{
			lc.Reverse(arrResults);
			lc.ReversePopulation(population);
		}
		
		fltPopulation = population;
		fltArrResults = arrResults;
	}
	/**
	 *An optimised BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(float[][] population, int[] arrResults, boolean minmax)
	{
		int j;
		int st = -1;
		int n = arrResults.length;
		
		while (st <  n) 
		{
			st++;
			n--;
			
			for (j = st; j <  n; j++) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					int T = arrResults[j];
					float[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
			for (j =  n; --j >= st;) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					int T = arrResults[j];
					float[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
		}
		
		if(minmax)
		{
			lc.Reverse(arrResults);
			lc.ReversePopulation(population);
		}
		
		fltPopulation = population;
		intArrResults = arrResults;
	}
	/**
	 *An optimised BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(int[][] population, float[] arrResults, boolean minmax)
	{
		int j;
		int st = -1;
		int n = arrResults.length;
		
		while (st <  n) 
		{
			st++;
			n--;
			
			for (j = st; j <  n; j++) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					float T = arrResults[j];
					int[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
			for (j =  n; --j >= st;) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					float T = arrResults[j];
					int[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
		}
		
		if(minmax)
		{
			lc.Reverse(arrResults);
			lc.ReversePopulation(population);
		}
		
		intPopulation = population;
		fltArrResults = arrResults;
	}	
	/**
	 *An optimised BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(int[][] population, int[] arrResults, boolean minmax)
	{
		int j;
		int st = -1;
		int n = arrResults.length;
		
		while (st <  n) 
		{
			st++;
			n--;
			
			for (j = st; j <  n; j++) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					int T = arrResults[j];
					int[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
			for (j =  n; --j >= st;) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					int T = arrResults[j];
					int[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
		}
		
		if(minmax)
		{
			lc.Reverse(arrResults);
			lc.ReversePopulation(population);
		}
		
		intPopulation = population;
		intArrResults = arrResults;
	}
	/**
	 *An optimised BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is false the sort is by min to max, true max to min.
	 * @return automatically the population sorted is updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(char[][] population, float[] arrResults, boolean minmax)
	{
		int j;
		int st = -1;
		int n = arrResults.length;
		
		while (st <  n) 
		{
			st++;
			n--;
			
			for (j = st; j <  n; j++) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					float T = arrResults[j];
					char[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
			for (j =  n; --j >= st;) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					float T = arrResults[j];
					char[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
		}
		
		if(minmax)
		{
			lc.Reverse(arrResults);
			lc.ReversePopulation(population);
		}
		srtPopulation = population;
		fltArrResults = arrResults;
	}

	/**
	 *An optimised BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(char[][] population, int[] arrResults, boolean minmax)
	{
		int j;
		int st = -1;
		int n = arrResults.length;
		
		while (st <  n) 
		{
			st++;
			n--;
			
			for (j = st; j <  n; j++) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					int T = arrResults[j];
					char[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
			for (j =  n; --j >= st;) 
			{
				if (arrResults[j] > arrResults[j + 1]) 
				{
					int T = arrResults[j];
					char[] temp = population[j];
					arrResults[j] = arrResults[j + 1];
					population[j] = population[j + 1];
					arrResults[j + 1] = T;
					population[j + 1] = temp;
				}
			}
		}
		
		if(minmax)
		{
			lc.Reverse(arrResults);
			lc.ReversePopulation(population);
		}
		
		srtPopulation = population;
		intArrResults = arrResults;
	}

	
}