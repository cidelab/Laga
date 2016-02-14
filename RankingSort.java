package laga;
import processing.core.*;

/**
 * The RankingSort class has all the methods to create and initialize the bidirectional BubbleSort algorithm.
 */
public class RankingSort 
{
	PApplet myParent;
	
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
	 *An optimized BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(Object[][] population, float[] arrResults)
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
		
		objPopulation = population;
		fltArrResults = arrResults;
	}
	/**
	 *An optimized BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(Object[][] population, int[] arrResults)
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
		
		objPopulation = population;
		intArrResults = arrResults;
	}
	/**
	 *An optimized BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(double[][] population, float[] arrResults)
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
		
		dblPopulation = population;
		fltArrResults = arrResults;
	}
	/**
	 *An optimized BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(double[][] population, int[] arrResults)
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

		dblPopulation = population;
		intArrResults = arrResults;

	}
	/**
	 *An optimized BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(float[][] population, float[] arrResults)
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
		
		fltPopulation = population;
		fltArrResults = arrResults;
	}
	/**
	 *An optimized BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(float[][] population, int[] arrResults)
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
		
		fltPopulation = population;
		intArrResults = arrResults;
	}
	/**
	 *An optimized BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(int[][] population, float[] arrResults)
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
		
		intPopulation = population;
		fltArrResults = arrResults;
	}	
	/**
	 *An optimized BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(int[][] population, int[] arrResults)
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
		
		intPopulation = population;
		intArrResults = arrResults;
	}
	/**
	 *An optimized BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(char[][] population, float[] arrResults)
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
		
		srtPopulation = population;
		fltArrResults = arrResults;
	}
	/**
	 *An optimized BidirectionalBubbleSort method.
	 * Sort the individuals in the population by fitness value.
	 * 
	 * @param population -> population to sort;
	 * @param arrResults -> Array of fitness in the population. Only two flavors are supported: int[] and float[].
	 * @param minmax 	 -> if is true the sort is by min to max, else max to min.
	 * @return automatically the population is sorted updated. the original population will be modified.
	 * 
	 * 
	 */
	public void BidirectionalBubbleSort(char[][] population, int[] arrResults)
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
		
		srtPopulation = population;
		intArrResults = arrResults;
	}

	
}

