package laga;

import processing.core.*;
import java.util.ArrayList;
import java.util.Random;

/**
 * The NaturalSelection class has all the methods to create and initialize different flavors
 * of Selections:
 */
public class NaturalSelection 
{
	PApplet myparent;

	public NaturalSelection(PApplet parent)
	{
		myparent = parent;
	}
	
	//////////////////////////OBJECT/////////////////////////////////////
	/**
	 * ElitismSelection method.
	 * select the number of the best indiviudals in the population.
	 *
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param count         -> quantity of individuals selected for the next generation.
	 * @return Object[][] population.
	 * 
	 * 
	 */
	public Object[][] ElitismSelection(Object[][] srtPopulation, int count)
	{
		//clone the array.
		Object[][] elitismPop = new Object[srtPopulation.length][];
		for(int i = 0; i < srtPopulation.length; i++) 
		{
			elitismPop[i] = new Object[srtPopulation[i].length];
			System.arraycopy(srtPopulation[i], 0, elitismPop[i], 0, srtPopulation[i].length);
		}
		
		int start = (srtPopulation.length - count);
		Object[][] selChromosome = new Object[count][];
		int c = 0;

		for(int i = start; i < elitismPop.length; ++i)
		{
			selChromosome[c] = elitismPop[i];
			c++;
		}

		return selChromosome;
	}
	/**
	 * RouletteWheelNonPolinomicMin method.
	 * select a number of indiviudals depending of their ranking in the population.
	 * the best ranked individuals have more chance to be selected thant worst. 
	 * Although all the individuals has a chance to be selected. the roulette wheel is based in a non polinomic curve (y = 1/x).
	 * Since is a non polinomic curve the best individual has the less value in the result and the first individual in the population.
	 * the method is based on the Roulette Wheel natural selection. This method return a new population, same size as the origin
	 * 
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param results 		-> the array of results from the evaluation in int[] flavor
	 * @param pointer 		-> the pointer is the maximum number of individuals in the roulette wheel.
	 * @param displace 		-> this parameter move the nonpolinomic curve in the y Axis.
	 * @return Object[][] population.
	 * 
	 * 
	 */
	public Object[][] RouletteWheelNonPolinomicMin(Object[][] srtPopulation, int[] results, int pointer, int displace)
	{
		//clone the array.
		ArrayList<Object> arrRwheelPop = new ArrayList <Object>();
		int index;
		
		for(int i = 0; i < srtPopulation.length; i++) 
		{
			index = (int)((results[0] / results[i] * (pointer / (i + 1))) - displace);
			for(int j = 0; j < index; ++j)
			{
				arrRwheelPop.add(srtPopulation[i]);
			}
		}
		Object[][] bigArray = new Object[arrRwheelPop.size()][];
		bigArray = arrRwheelPop.toArray(bigArray);
		
		Object[][] RwheelPop = new Object[srtPopulation.length][];
		Random rand = new Random();
		for(int i = 0; i < srtPopulation.length; i++)
		{
			RwheelPop[i] = new Object[srtPopulation[i].length];
			RwheelPop[i] = bigArray[rand.nextInt(bigArray.length)];
		}
		
	return RwheelPop;
	}
	/**
	 * RouletteWheelNonPolinomicMin method.
	 * select a number of indiviudals depending of their ranking in the population.
	 * the best ranked individuals have more chance to be selected thant worst. 
	 * Although all the individuals has a chance to be selected. the roulette wheel is based in a non polinomic curve (y = 1/x).
	 * Since is a non polinomic curve the best individual has the less value in the result and the first individual in the population.
	 * the method is based on the Roulette Wheel natural selection. This method return a new population, same size as the origin
	 * 
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param results 		-> the array of results from the evaluation in float[] flavor
	 * @param pointer 		-> the pointer is the maximum number of individuals in the roulette wheel.
	 * @param displace 		-> this parameter move the nonpolinomic curve in the y Axis.
	 * @return Object[][] population.
	 * 
	 * 
	 */
	public Object[][] RouletteWheelNonPolinomicMin(Object[][] srtPopulation, float[] results, int pointer, int displace)
	{
		//clone the array.
		ArrayList<Object> arrRwheelPop = new ArrayList <Object>();
		int index;
		
		for(int i = 0; i < srtPopulation.length; i++) 
		{
			index = (int)((results[0] / results[i] * (pointer / (i + 1))) - displace);
			for(int j = 0; j < index; ++j)
			{
				arrRwheelPop.add(srtPopulation[i]);
			}
		}
		Object[][] bigArray = new Object[arrRwheelPop.size()][];
		bigArray = arrRwheelPop.toArray(bigArray);
		
		Object[][] RwheelPop = new Object[srtPopulation.length][];
		Random rand = new Random();
		for(int i = 0; i < srtPopulation.length; i++)
		{
			RwheelPop[i] = new Object[srtPopulation[i].length];
			RwheelPop[i] = bigArray[rand.nextInt(bigArray.length)];
		}
		
	return RwheelPop;
	}
	/**
	 * RouletteWheelSigmoidal method.
	 * select a number of indiviudals depending of their ranking in the population.
	 * the best ranked individuals have more chance to be selected thant worst. 
	 * Although all the individuals has a chance to be selected. the roulette wheel is based in sigmoidal curve, (See RouletteWheelSigmoidalEngine.pde).
	 * 
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param sizeRoulette  -> number of the individuals selected.
	 * @param A1			-> the maximum number of individuals in the roulette wheel (aprox).
	 * @param A2 			-> the minimum number of individuals in the roulette wheel (aprox).
	 * @param B1 	 		-> the start scope in the population, i.e. 1 the selection will start in the second individual
	 * @param B2	 		-> the end scope in the population, i.e. the size of the population: the las individuals (worst) will be included.
	 * @param s				-> the decay of the curve. 0 < s < 1  (See RouletteWheelSigmoidalEngine.pde).
	 * @return Object[][] population.
	 * 
	 * 
	 */
	public Object[][] RouletteWheelSigmoidal(Object[][] srtPopulation, int sizeRoulette, int A1, int A2, int B1, int B2, float s)
	{
		//clone the array.
		ArrayList<Object> arrRwheelPop = new ArrayList <Object>();
		int index;
		
		for(int i = B1; i < B2; i++) 
		{
			index = (int)(A1 + (A2 - A1) / (1 + Math.exp(Math.log(1 / s - 1) * (B1 + B2 - 2 * i) / (B2 - B1))));
			for(int j = 0; j < index; ++j)
			{
				arrRwheelPop.add(srtPopulation[i]);
			}
		}
		Object[][] bigArray = new Object[arrRwheelPop.size()][];
		bigArray = arrRwheelPop.toArray(bigArray);
		
		Object[][] RwheelPop = new Object[sizeRoulette][];
		Random rand = new Random();
		for(int i = 0; i < sizeRoulette; i++)
		{
			RwheelPop[i] = new Object[srtPopulation[i].length];
			RwheelPop[i] = bigArray[rand.nextInt(bigArray.length)];
		}
		
	return RwheelPop;
	}
	/**
	 * TournamentSelection method.
	 * select a number of indiviudals trough a tournament selection.
	 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
	 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
	 * This method return a new population and can be bigger than the original size.
	 * in the TorunamentSelection method is not necessary a sorted population.
	 * 
	 * @param srtPopulation -> a population.
	 * @param resutls		-> the array of results from the evaluation in int[] flavor.
	 * @param numbTour 		-> the quantity of tournaments, any integer.
	 * @param preasure 	 	-> number of individuals in the competition.
	 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
	 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
	 * @return Object[][] population.
	 * 
	 * 
	 */
	public Object[][] TournamentSelection(Object[][] srtPopulation, int[] results, int numbTour, int preasure, String type)
	{
		Object[][] TourPop = new Object[numbTour][];
		Object[][] arrTour;
		int[] arrResults = new int[preasure];
		
		Random rnd = new Random();
		int index;
		for(int i = 0; i < numbTour; ++i)
		{
			arrTour = new Object[preasure][];
			for(int j = 0; j < preasure; ++j)
			{
				index = rnd.nextInt(srtPopulation.length);
				arrTour[j] = srtPopulation[index];
				arrResults[j] = results[index];
				
			}
			TourPop[i] = Tournament(arrTour, arrResults, type);
		}
		
		return TourPop;
	}	
	/**
	 * TournamentSelection method.
	 * select a number of indiviudals trough a tournament selection.
	 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
	 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
	 * This method return a new population and can be bigger than the original size.
	 * in the TorunamentSelection method is not necessary a sorted population.
	 * 
	 * @param srtPopulation -> a population.
	 * @param resutls		-> the array of results from the evaluation in float[] flavor.
	 * @param numbTour 		-> the quantity of tournaments, any integer.
	 * @param preasure 	 	-> number of individuals in the competition.
	 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
	 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
	 * @return Object[][] population.
	 * 
	 * 
	 */
	public Object[][] TournamentSelection(Object[][] srtPopulation, float[] results, int numbTour, int preasure, String type)
	{
		Object[][] TourPop = new Object[numbTour][];
		Object[][] arrTour;
		float[] arrResults = new float[preasure];
		
		Random rnd = new Random();
		int index;
		
		for(int i = 0; i < numbTour; ++i)
		{
			arrTour = new Object[preasure][];
			for(int j = 0; j < preasure; ++j)
			{
				index = rnd.nextInt(srtPopulation.length);
				arrTour[j] = srtPopulation[index];
				arrResults[j] = results[index];
				
			}
			TourPop[i] = Tournament(arrTour, arrResults, type);
		}
		
		return TourPop;
	}
	Object[] Tournament(Object[][] torneo, float[] results, String type)
	{
		float test = results[0];
		int c = 0;
		
		if(type == "min")
		{
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test > results[i])
				{
					test = results[i];
					c = i;
				}
			}
		}
		else
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test < results[i])
				{
					test = results[i];
					c = i;
				}
			}

	
		Object[] winner = new Object[torneo[0].length];
		winner = torneo[c];
		return winner;
	}
	Object[] Tournament(Object[][] torneo, int[] results, String type)
	{
		int test = results[0];
		int c = 0;
		if(type == "min")
		{
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test > results[i])
				{
					test = results[i];
					c = i;
				}
			}
		}
		else
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test < results[i])
				{
					test = results[i];
					c = i;
				}
			}
	
		Object[] winner = new Object[torneo[0].length];
		winner = torneo[c];
		return winner;
	}
	
	//////////////////////////DOUBLE/////////////////////////////////////
	/**
	 * ElitismSelection method.
	 * select the number of the best indiviudals in the population.
	 *
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param count         -> quantity of individuals selected for the next generation.
	 * @return double[][] population.
	 * 
	 * 
	 */
	public double[][] ElitismSelection(double[][] srtPopulation, int count)
	{
		//clone the array.
		double[][] elitismPop = new double[srtPopulation.length][];
		for(int i = 0; i < srtPopulation.length; i++) 
		{
			elitismPop[i] = new double[srtPopulation[i].length];
			System.arraycopy(srtPopulation[i], 0, elitismPop[i], 0, srtPopulation[i].length);
		}
		
		double[][] RwheelPop = new double[count][];
		for(int i = 0; i < count; ++i)
		{
			RwheelPop[i] = elitismPop[i];
		}
		return RwheelPop;
	}
	/**
	 * RouletteWheelNonPolinomicMin method.
	 * select a number of indiviudals depending of their ranking in the population.
	 * the best ranked individuals have more chance to be selected thant worst. 
	 * Although all the individuals has a chance to be selected. the roulette wheel is based in a non polinomic curve (y = 1/x).
	 * Since is a non polinomic curve the best individual has the less value in the result and the first individual in the population.
	 * the method is based on the Roulette Wheel natural selection. This method return a new population, same size as the origin
	 * 
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param results 		-> the array of results from the evaluation in float[] flavor
	 * @param pointer 		-> the pointer is the maximum number of individuals in the roulette wheel.
	 * @param displace 		-> this parameter move the nonpolinomic curve in the y Axis.
	 * @return double[][] population.
	 * 
	 * 
	 */
	public double[][] RouletteWheelNonPolinomicMin(double[][] srtPopulation, float[] results, int pointer, int displace)
	{
		//clone the array.
		ArrayList<double[]> arrRwheelPop = new ArrayList <double[]>();
		int index;
		
		for(int i = 0; i < srtPopulation.length; i++) 
		{
			index = (int)((results[0] / results[i] * (pointer / (i + 1))) - displace);
			for(int j = 0; j < index; ++j)
			{
				arrRwheelPop.add(srtPopulation[i]);
			}
		}
		double[][] bigArray = new double[arrRwheelPop.size()][];
		bigArray = arrRwheelPop.toArray(bigArray);
		
		double[][] RwheelPop = new double[srtPopulation.length][];
		Random rand = new Random();
		for(int i = 0; i < srtPopulation.length; i++)
		{
			RwheelPop[i] = new double[srtPopulation[i].length];
			RwheelPop[i] = bigArray[rand.nextInt(bigArray.length)];
		}
		
	return RwheelPop;
	}
	/**
	 * RouletteWheelNonPolinomicMin method.
	 * select a number of indiviudals depending of their ranking in the population.
	 * the best ranked individuals have more chance to be selected thant worst. 
	 * Although all the individuals has a chance to be selected. the roulette wheel is based in a non polinomic curve (y = 1/x).
	 * Since is a non polinomic curve the best individual has the less value in the result and the first individual in the population.
	 * the method is based on the Roulette Wheel natural selection. This method return a new population, same size as the origin
	 * 
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param results 		-> the array of results from the evaluation in int[] flavor
	 * @param pointer 		-> the pointer is the maximum number of individuals in the roulette wheel.
	 * @param displace 		-> this parameter move the nonpolinomic curve in the y Axis.
	 * @return double[][] population.
	 * 
	 * 
	 */
	public double[][] RouletteWheelNonPolinomicMin(double[][] srtPopulation, int[] results, int pointer, int displace)
	{
		//clone the array.
		ArrayList<double[]> arrRwheelPop = new ArrayList <double[]>();
		int index;
		
		for(int i = 0; i < srtPopulation.length; i++) 
		{
			index = (int)((results[0] / results[i] * (pointer / (i + 1))) - displace);
			for(int j = 0; j < index; ++j)
			{
				arrRwheelPop.add(srtPopulation[i]);
			}
		}
		double[][] bigArray = new double[arrRwheelPop.size()][];
		bigArray = arrRwheelPop.toArray(bigArray);
		
		double[][] RwheelPop = new double[srtPopulation.length][];
		Random rand = new Random();
		for(int i = 0; i < srtPopulation.length; i++)
		{
			RwheelPop[i] = new double[srtPopulation[i].length];
			RwheelPop[i] = bigArray[rand.nextInt(bigArray.length)];
		}
		
	return RwheelPop;
	}
	/**
	 * RouletteWheelSigmoidal method.
	 * select a number of indiviudals depending of their ranking in the population.
	 * the best ranked individuals have more chance to be selected thant worst. 
	 * Although all the individuals has a chance to be selected. the roulette wheel is based in sigmoidal curve, (See RouletteWheelSigmoidalEngine.pde).
	 * 
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param sizeRoulette  -> number of the individuals selected.
	 * @param A1			-> the maximum number of individuals in the roulette wheel (aprox).
	 * @param A2 			-> the minimum number of individuals in the roulette wheel (aprox).
	 * @param B1 	 		-> the start scope in the population, i.e. 1 the selection will start in the second individual
	 * @param B2	 		-> the end scope in the population, i.e. the size of the population: the las individuals (worst) will be included.
	 * @param s				-> the decay of the curve. 0 < s < 1 (See RouletteWheelSigmoidalEngine.pde).
	 * @return float[][] population.
	 * 
	 * 
	 */
	public double[][] RouletteWheelSigmoidal(double[][] srtPopulation, int sizeRoulette, int A1, int A2, int B1, int B2, float s)
	{
		//clone the array.
		ArrayList<double[]> arrRwheelPop = new ArrayList <double[]>();
		int index;
		
		for(int i = B1; i < B2; i++) 
		{
			index = (int)(A1 + (A2 - A1) / (1 + Math.exp(Math.log(1 / s - 1) * (B1 + B2 - 2 * i) / (B2 - B1))));
			for(int j = 0; j < index; ++j)
			{
				arrRwheelPop.add(srtPopulation[i]);
			}
		}
		double[][] bigArray = new double[arrRwheelPop.size()][];
		bigArray = arrRwheelPop.toArray(bigArray);
		
		double[][] RwheelPop = new double[sizeRoulette][];
		Random rand = new Random();
		for(int i = 0; i < sizeRoulette; i++)
		{
			RwheelPop[i] = new double[srtPopulation[i].length];
			RwheelPop[i] = bigArray[rand.nextInt(bigArray.length)];
		}
		
	return RwheelPop;
	}
	/**
	 * TournamentSelection method.
	 * select a number of indiviudals trough a tournament selection.
	 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
	 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
	 * This method return a new population and can be bigger than the original size.
	 * in the TorunamentSelection method is not necessary a sorted population.
	 * 
	 * @param srtPopulation -> a population.
	 * @param resutls		-> the array of results from the evaluation in float[] flavor.
	 * @param numbTour 		-> the quantity of tournaments, any integer.
	 * @param preasure 	 	-> number of individuals in the competition.
	 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
	 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
	 * @return double[][] population.
	 * 
	 * 
	 */
	public double[][] TournamentSelection(double[][] srtPopulation, float[] results, int numbTour, int preasure, String type)
	{
		double[][] TourPop = new double[numbTour][];
		double[][] arrTour;
		float[] arrResults = new float[preasure];
		
		Random rnd = new Random();
		int index;
		for(int i = 0; i < numbTour; ++i)
		{
			arrTour = new double[preasure][];
			for(int j = 0; j < preasure; ++j)
			{
				index = rnd.nextInt(srtPopulation.length);
				arrTour[j] = srtPopulation[index];
				arrResults[j] = results[index];
				
			}
			TourPop[i] = Tournament(arrTour, arrResults, type);
		}
		
		return TourPop;
	}
	/**
	 * TournamentSelection method.
	 * select a number of indiviudals trough a tournament selection.
	 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
	 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
	 * This method return a new population and can be bigger than the original size.
	 * in the TorunamentSelection method is not necessary a sorted population.
	 * 
	 * @param srtPopulation -> a population.
	 * @param resutls		-> the array of results from the evaluation in int[] flavor.
	 * @param numbTour 		-> the quantity of tournaments, any integer.
	 * @param preasure 	 	-> number of individuals in the competition.
	 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
	 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
	 * @return double[][] population.
	 * 
	 * 
	 */
	public double[][] TournamentSelection(double[][] srtPopulation, int[] results, int numbTour, int preasure, String type)
	{
		double[][] TourPop = new double[numbTour][];
		double[][] arrTour;
		int[] arrResults = new int[preasure];
		
		Random rnd = new Random();
		int index;
		for(int i = 0; i < numbTour; ++i)
		{
			arrTour = new double[preasure][];
			for(int j = 0; j < preasure; ++j)
			{
				index = rnd.nextInt(srtPopulation.length);
				arrTour[j] = srtPopulation[index];
				arrResults[j] = results[index];
				
			}
			TourPop[i] = Tournament(arrTour, arrResults, type);
		}
		
		return TourPop;
	}	
	double[] Tournament(double[][] torneo, float[] results, String type)
	{
		float test = results[0];
		int c = 0;
		if(type == "min")
		{
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test > results[i])
				{
					test = results[i];
					c = i;
				}
			}
		}
		else
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test < results[i])
				{
					test = results[i];
					c = i;
				}
			}
	
		double[] winner = new double[torneo[0].length];
		winner = torneo[c];
		return winner;
	}
	double[] Tournament(double[][] torneo, int[] results, String type)
	{
		int test = results[0];
		int c = 0;
		if(type == "min")
		{
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test > results[i])
				{
					test = results[i];
					c = i;
				}
			}
		}
		else
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test < results[i])
				{
					test = results[i];
					c = i;
				}
			}
	
		double[] winner = new double[torneo[0].length];
		winner = torneo[c];
		return winner;
	}
	
	//////////////////////////FLOAT/////////////////////////////////////
	/**
	 * ElitismSelection method.
	 * select the number of the best indiviudals in the population.
	 *
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param count         -> quantity of individuals selected for the next generation.
	 * @return float[][] population.
	 * 
	 * 
	 */
	public float[][] ElitismSelection(float[][] srtPopulation, int count)
	{
		//clone the array.
		float[][] elitismPop = new float[srtPopulation.length][];
		for(int i = 0; i < srtPopulation.length; i++) 
		{
			elitismPop[i] = new float[srtPopulation[i].length];
			System.arraycopy(srtPopulation[i], 0, elitismPop[i], 0, srtPopulation[i].length);
		}
		
		float[][] RwheelPop = new float[count][];

		for(int i = 0; i < count; ++i)
		{
			RwheelPop[i] = elitismPop[i];
		}

		return RwheelPop;
	}
	/**
	 * RouletteWheelNonPolinomicMin method.
	 * select a number of indiviudals depending of their ranking in the population.
	 * the best ranked individuals have more chance to be selected thant worst. 
	 * Although all the individuals has a chance to be selected. the roulette wheel is based in a non polinomic curve (y = 1/x).
	 * Since is a non polinomic curve the best individual has the less value in the result and the first individual in the population.
	 * the method is based on the Roulette Wheel natural selection. This method return a new population, same size as the origin
	 * 
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param results 		-> the array of results from the evaluation in float[] flavor
	 * @param pointer 		-> the pointer is the maximum number of individuals in the roulette wheel.
	 * @param displace 		-> this parameter move the nonpolinomic curve in the y Axis.
	 * @return float[][] population.
	 * 
	 * 
	 */
	public float[][] RouletteWheelNonPolinomicMin(float[][] srtPopulation, float[] results, int pointer, int displace)
	{
		//clone the array.
		ArrayList<float[]> arrRwheelPop = new ArrayList <float[]>();
		int index;
		
		for(int i = 0; i < srtPopulation.length; i++) 
		{
			index = (int)((results[0] / results[i] * (pointer / (i + 1))) - displace);
			for(int j = 0; j < index; ++j)
			{
				arrRwheelPop.add(srtPopulation[i]);
			}
		}
		float[][] bigArray = new float[arrRwheelPop.size()][];
		bigArray = arrRwheelPop.toArray(bigArray);
		
		float[][] RwheelPop = new float[srtPopulation.length][];
		Random rand = new Random();
		for(int i = 0; i < srtPopulation.length; i++)
		{
			RwheelPop[i] = new float[srtPopulation[i].length];
			RwheelPop[i] = bigArray[rand.nextInt(bigArray.length)];
		}
		
	return RwheelPop;
	}
	/**
	 * RouletteWheelNonPolinomicMin method.
	 * select a number of indiviudals depending of their ranking in the population.
	 * the best ranked individuals have more chance to be selected thant worst. 
	 * Although all the individuals has a chance to be selected. the roulette wheel is based in a non polinomic curve (y = 1/x).
	 * Since is a non polinomic curve the best individual has the less value in the result and the first individual in the population.
	 * the method is based on the Roulette Wheel natural selection. This method return a new population, same size as the origin
	 * 
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param results 		-> the array of results from the evaluation in int[] flavor
	 * @param pointer 		-> the pointer is the maximum number of individuals in the roulette wheel.
	 * @param displace 		-> this parameter move the nonpolinomic curve in the y Axis.
	 * @return float[][] population.
	 * 
	 * 
	 */
	public float[][] RouletteWheelNonPolinomicMin(float[][] srtPopulation, int[] results, int pointer, int displace)
	{
		//clone the array.
		ArrayList<float[]> arrRwheelPop = new ArrayList <float[]>();
		int index;
		
		for(int i = 0; i < srtPopulation.length; i++) 
		{
			index = (int)((results[0] / results[i] * (pointer / (i + 1))) - displace);
			for(int j = 0; j < index; ++j)
			{
				arrRwheelPop.add(srtPopulation[i]);
			}
		}
		float[][] bigArray = new float[arrRwheelPop.size()][];
		bigArray = arrRwheelPop.toArray(bigArray);
		
		float[][] RwheelPop = new float[srtPopulation.length][];
		Random rand = new Random();
		for(int i = 0; i < srtPopulation.length; i++)
		{
			RwheelPop[i] = new float[srtPopulation[i].length];
			RwheelPop[i] = bigArray[rand.nextInt(bigArray.length)];
		}
		
	return RwheelPop;
	}
	/**
	 * RouletteWheelSigmoidal method.
	 * select a number of indiviudals depending of their ranking in the population.
	 * the best ranked individuals have more chance to be selected thant worst. 
	 * Although all the individuals has a chance to be selected. the roulette wheel is based in sigmoidal curve, (See RouletteWheelSigmoidalEngine.pde).
	 * 
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param sizeRoulette  -> number of the individuals selected.
	 * @param A1			-> the maximum number of individuals in the roulette wheel (aprox).
	 * @param A2 			-> the minimum number of individuals in the roulette wheel (aprox).
	 * @param B1 	 		-> the start scope in the population, i.e. 1 the selection will start in the second individual
	 * @param B2	 		-> the end scope in the population, i.e. the size of the population: the las individuals (worst) will be included.
	 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
	 * @return float[][] population.
	 * 
	 * 
	 */
	public float[][] RouletteWheelSigmoidal(float[][] srtPopulation, int sizeRoulette, int A1, int A2, int B1, int B2, float s)
	{
		//clone the array.
		ArrayList<float[]> arrRwheelPop = new ArrayList <float[]>();
		int index;
		
		for(int i = B1; i < B2; i++) 
		{
			index = (int)(A1 + (A2 - A1) / (1 + Math.exp(Math.log(1 / s - 1) * (B1 + B2 - 2 * i) / (B2 - B1))));
			for(int j = 0; j < index; ++j)
			{
				arrRwheelPop.add(srtPopulation[i]);
			}
		}
		float[][] bigArray = new float[arrRwheelPop.size()][];
		bigArray = arrRwheelPop.toArray(bigArray);
		
		float[][] RwheelPop = new float[sizeRoulette][];
		Random rand = new Random();
		for(int i = 0; i < sizeRoulette; i++)
		{
			RwheelPop[i] = new float[srtPopulation[i].length];
			RwheelPop[i] = bigArray[rand.nextInt(bigArray.length)];
		}
		
	return RwheelPop;
	}
	/**
	 * TournamentSelection method.
	 * select a number of indiviudals trough a tournament selection.
	 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
	 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
	 * This method return a new population and can be bigger than the original size.
	 * in the TorunamentSelection method is not necessary a sorted population.
	 * 
	 * @param srtPopulation -> a population.
	 * @param resutls		-> the array of results from the evaluation in float[] flavor.
	 * @param numbTour 		-> the quantity of tournaments, any integer.
	 * @param preasure 	 	-> number of individuals in the competition.
	 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
	 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
	 * @return float[][] population.
	 * 
	 * 
	 */
	public float[][] TournamentSelection(float[][] srtPopulation, float[] results, int numbTour, int preasure, String type)
	{
		float[][] TourPop = new float[numbTour][];
		float[][] arrTour;
		float[] arrResults = new float[preasure];
		
		Random rnd = new Random();
		int index;
		for(int i = 0; i < numbTour; ++i)
		{
			arrTour = new float[preasure][];
			for(int j = 0; j < preasure; ++j)
			{
				index = rnd.nextInt(srtPopulation.length);
				arrTour[j] = srtPopulation[index];
				arrResults[j] = results[index];
				
			}
			TourPop[i] = Tournament(arrTour, arrResults, type);
		}
		
		return TourPop;
	}
	/**
	 * TournamentSelection method.
	 * select a number of indiviudals trough a tournament selection.
	 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
	 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
	 * This method return a new population and can be bigger than the original size.
	 * in the TorunamentSelection method is not necessary a sorted population.
	 * 
	 * @param srtPopulation -> a population.
	 * @param resutls		-> the array of results from the evaluation in int[] flavor.
	 * @param numbTour 		-> the quantity of tournaments, any integer.
	 * @param preasure 	 	-> number of individuals in the competition.
	 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
	 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
	 * @return float[][] population.
	 * 
	 * 
	 */
	public float[][] TournamentSelection(float[][] srtPopulation, int[] results, int numbTour, int preasure, String type)
	{
		float[][] TourPop = new float[numbTour][];
		float[][] arrTour;
		int[] arrResults = new int[preasure];
		
		Random rnd = new Random();
		int index;
		for(int i = 0; i < numbTour; ++i)
		{
			arrTour = new float[preasure][];
			for(int j = 0; j < preasure; ++j)
			{
				index = rnd.nextInt(srtPopulation.length);
				arrTour[j] = srtPopulation[index];
				arrResults[j] = results[index];
				
			}
			TourPop[i] = Tournament(arrTour, arrResults, type);
		}
		
		return TourPop;
	}	
	float[] Tournament(float[][] torneo, float[] results, String type)
	{
		float test = results[0];
		int c = 0;
		if(type == "min")
		{
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test > results[i])
				{
					test = results[i];
					c = i;
				}
			}
		}
		else
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test < results[i])
				{
					test = results[i];
					c = i;
				}
			}
	
		float[] winner = new float[torneo[0].length];
		winner = torneo[c];
		return winner;
	}
	float[] Tournament(float[][] torneo, int[] results, String type)
	{
		int test = results[0];
		int c = 0;
		if(type == "min")
		{
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test > results[i])
				{
					test = results[i];
					c = i;
				}
			}
		}
		else
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test < results[i])
				{
					test = results[i];
					c = i;
				}
			}
	
		float[] winner = new float[torneo[0].length];
		winner = torneo[c];
		return winner;
	}
	
	//////////////////////////INTEGER/////////////////////////////////////
	/**
	 * ElitismSelection method.
	 * select the number of the best indiviudals in the population.
	 *
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param count         -> quantity of individuals selected for the next generation.
	 * @return int[][] population.
	 * 
	 * 
	 */
	public int[][] ElitismSelection(int[][] srtPopulation, int count)
	{
		//clone the array.
		int[][] elitismPop = new int[srtPopulation.length][];
		for(int i = 0; i < srtPopulation.length; i++) 
		{
			elitismPop[i] = new int[srtPopulation[i].length];
			System.arraycopy(srtPopulation[i], 0, elitismPop[i], 0, srtPopulation[i].length);
		}
		
		int[][] RwheelPop = new int[count][];

		for(int i = 0; i < count; ++i)
		{
			RwheelPop[i] = elitismPop[i];
		}

		return RwheelPop;
	}
	/**
	 * RouletteWheelNonPolinomicMin method.
	 * select a number of indiviudals depending of their ranking in the population.
	 * the best ranked individuals have more chance to be selected thant worst. 
	 * Although all the individuals has a chance to be selected. the roulette wheel is based in a non polinomic curve (y = 1/x).
	 * Since is a non polinomic curve the best individual has the less value in the result and the first individual in the population.
	 * the method is based on the Roulette Wheel natural selection. This method return a new population, same size as the origin
	 * 
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param results 		-> the array of results from the evaluation in float[] flavor
	 * @param pointer 		-> the pointer is the maximum number of individuals in the roulette wheel.
	 * @param displace 		-> this parameter move the nonpolinomic curve in the y Axis.
	 * @return int[][] population.
	 * 
	 * 
	 */
	public int[][] RouletteWheelNonPolinomicMin(int[][] srtPopulation, float[] results, int pointer, int displace)
	{
		//clone the array.
		ArrayList<int[]> arrRwheelPop = new ArrayList <int[]>();
		int index;
		
		for(int i = 0; i < srtPopulation.length; i++) 
		{
			index = (int)((results[0] / results[i] * (pointer / (i + 1))) - displace);
			for(int j = 0; j < index; ++j)
			{
				arrRwheelPop.add(srtPopulation[i]);
			}
		}
		int[][] bigArray = new int[arrRwheelPop.size()][];
		bigArray = arrRwheelPop.toArray(bigArray);
		
		int[][] RwheelPop = new int[srtPopulation.length][];
		Random rand = new Random();
		for(int i = 0; i < srtPopulation.length; i++)
		{
			RwheelPop[i] = new int[srtPopulation[i].length];
			RwheelPop[i] = bigArray[rand.nextInt(bigArray.length)];
		}
		
	return RwheelPop;
	}
	/**
	 * RouletteWheelNonPolinomicMin method.
	 * select a number of indiviudals depending of their ranking in the population.
	 * the best ranked individuals have more chance to be selected thant worst. 
	 * Although all the individuals has a chance to be selected. the roulette wheel is based in a non polinomic curve (y = 1/x).
	 * Since is a non polinomic curve the best individual has the less value in the result and the first individual in the population.
	 * the method is based on the Roulette Wheel natural selection. This method return a new population, same size as the origin
	 * 
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param results 		-> the array of results from the evaluation in int[] flavor
	 * @param pointer 		-> the pointer is the maximum number of individuals in the roulette wheel.
	 * @param displace 		-> this parameter move the nonpolinomic curve in the y Axis.
	 * @return int[][] population.
	 * 
	 * 
	 */
	public int[][] RouletteWheelNonPolinomicMin(int[][] srtPopulation, int[] results, int pointer, int displace)
	{
		//clone the array.
		ArrayList<int[]> arrRwheelPop = new ArrayList <int[]>();
		int index;
		
		for(int i = 0; i < srtPopulation.length; i++) 
		{
			index = (int)((results[0] / results[i] * (pointer / (i + 1))) - displace);
			for(int j = 0; j < index; ++j)
			{
				arrRwheelPop.add(srtPopulation[i]);
			}
		}
		int[][] bigArray = new int[arrRwheelPop.size()][];
		bigArray = arrRwheelPop.toArray(bigArray);
		
		int[][] RwheelPop = new int[srtPopulation.length][];
		Random rand = new Random();
		for(int i = 0; i < srtPopulation.length; i++)
		{
			RwheelPop[i] = new int[srtPopulation[i].length];
			RwheelPop[i] = bigArray[rand.nextInt(bigArray.length)];
		}
		
	return RwheelPop;
	}
	/**
	 * RouletteWheelSigmoidal method.
	 * select a number of indiviudals depending of their ranking in the population.
	 * the best ranked individuals have more chance to be selected thant worst. 
	 * Although all the individuals has a chance to be selected. the roulette wheel is based in sigmoidal curve, (See RouletteWheelSigmoidalEngine.pde).
	 * 
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param sizeRoulette  -> number of the individuals selected.
	 * @param A1			-> the maximum number of individuals in the roulette wheel (aprox).
	 * @param A2 			-> the minimum number of individuals in the roulette wheel (aprox).
	 * @param B1 	 		-> the start scope in the population, i.e. 1 the selection will start in the second individual
	 * @param B2	 		-> the end scope in the population, i.e. the size of the population: the las individuals (worst) will be included.
	 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
	 * @return int[][] population.
	 * 
	 * 
	 */
	public int[][] RouletteWheelSigmoidal(int[][] srtPopulation, int sizeRoulette, int A1, int A2, int B1, int B2, float s)
	{
		//clone the array.
		ArrayList<int[]> arrRwheelPop = new ArrayList <int[]>();
		int index;
		
		for(int i = B1; i < B2; i++) 
		{
			index = (int)(A1 + (A2 - A1) / (1 + Math.exp(Math.log(1 / s - 1) * (B1 + B2 - 2 * i) / (B2 - B1))));
			for(int j = 0; j < index; ++j)
			{
				arrRwheelPop.add(srtPopulation[i]);
			}
		}
		int[][] bigArray = new int[arrRwheelPop.size()][];
		bigArray = arrRwheelPop.toArray(bigArray);
		
		int[][] RwheelPop = new int[sizeRoulette][];
		Random rand = new Random();
		for(int i = 0; i < sizeRoulette; i++)
		{
			RwheelPop[i] = new int[srtPopulation[i].length];
			RwheelPop[i] = bigArray[rand.nextInt(bigArray.length)];
		}
		
	return RwheelPop;
	}
	/**
	 * TournamentSelection method.
	 * select a number of indiviudals trough a tournament selection.
	 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
	 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
	 * This method return a new population and can be bigger than the original size.
	 * in the TorunamentSelection method is not necessary a sorted population.
	 * 
	 * @param srtPopulation -> a population.
	 * @param resutls		-> the array of results from the evaluation in float[] flavor.
	 * @param numbTour 		-> the quantity of tournaments, any integer.
	 * @param preasure 	 	-> number of individuals in the competition.
	 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
	 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
	 * @return int[][] population.
	 * 
	 * 
	 */
	public int[][] TournamentSelection(int[][] srtPopulation, float[] results, int numbTour, int preasure, String type)
	{
		int[][] TourPop = new int[numbTour][];
		int[][] arrTour;
		float[] arrResults = new float[preasure];
		
		Random rnd = new Random();
		int index;
		for(int i = 0; i < numbTour; ++i)
		{
			arrTour = new int[preasure][];
			for(int j = 0; j < preasure; ++j)
			{
				index = rnd.nextInt(srtPopulation.length);
				arrTour[j] = srtPopulation[index];
				arrResults[j] = results[index];
				
			}
			TourPop[i] = Tournament(arrTour, arrResults, type);
		}
		
		return TourPop;
	}
	/**
	 * TournamentSelection method.
	 * select a number of indiviudals trough a tournament selection.
	 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
	 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
	 * This method return a new population and can be bigger than the original size.
	 * in the TorunamentSelection method is not necessary a sorted population.
	 * 
	 * @param srtPopulation -> a population.
	 * @param resutls		-> the array of results from the evaluation in int[] flavor.
	 * @param numbTour 		-> the quantity of tournaments, any integer.
	 * @param preasure 	 	-> number of individuals in the competition.
	 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
	 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
	 * @return int[][] population.
	 * 
	 * 
	 */
	public int[][] TournamentSelection(int[][] srtPopulation, int[] results, int numbTour, int preasure, String type)
	{
		int[][] TourPop = new int[numbTour][];
		int[][] arrTour;
		int[] arrResults = new int[preasure];
		
		Random rnd = new Random();
		int index;
		for(int i = 0; i < numbTour; ++i)
		{
			arrTour = new int[preasure][];
			for(int j = 0; j < preasure; ++j)
			{
				index = rnd.nextInt(srtPopulation.length);
				arrTour[j] = srtPopulation[index];
				arrResults[j] = results[index];
				
			}
			TourPop[i] = Tournament(arrTour, arrResults, type);
		}
		
		return TourPop;
	}	
	int[] Tournament(int[][] torneo, float[] results, String type)
	{
		float test = results[0];
		int c = 0;
		if(type == "min")
		{
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test > results[i])
				{
					test = results[i];
					c = i;
				}
			}
		}
		else
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test < results[i])
				{
					test = results[i];
					c = i;
				}
			}
	
		int[] winner = new int[torneo[0].length];
		winner = torneo[c];
		return winner;
	}
	int[] Tournament(int[][] torneo, int[] results, String type)
	{
		int test = results[0];
		int c = 0;
		if(type == "min")
		{
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test > results[i])
				{
					test = results[i];
					c = i;
				}
			}
		}
		else
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test < results[i])
				{
					test = results[i];
					c = i;
				}
			}
	
		int[] winner = new int[torneo[0].length];
		winner = torneo[c];
		return winner;
	}

	//////////////////////////CHARACTER///////////////////////////////////
	/**
	 * ElitismSelection method.
	 * select the number of the best indiviudals in the population.
	 *
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param count         -> quantity of individuals selected for the next generation.
	 * @return char[][] population.
	 * 
	 * 
	 */
	public char[][] ElitismSelection(char[][] srtPopulation, int count)
	{
		//clone the array.
		char[][] elitismPop = new char[srtPopulation.length][];
		for(int i = 0; i < srtPopulation.length; i++) 
		{
			elitismPop[i] = new char[srtPopulation[i].length];
			System.arraycopy(srtPopulation[i], 0, elitismPop[i], 0, srtPopulation[i].length);
		}
		
		int start = (srtPopulation.length - count);
		char[][] selChromosome = new char[count][];
		int c = 0;

		for(int i = start; i < elitismPop.length; ++i)
		{
			selChromosome[c] = elitismPop[i];
			c++;
		}

		return selChromosome;
	}
	/**
	 * RouletteWheelNonPolinomicMin method.
	 * select a number of indiviudals depending of their ranking in the population.
	 * the best ranked individuals have more chance to be selected thant worst. 
	 * Although all the individuals has a chance to be selected. the roulette wheel is based in a non polinomic curve (y = 1/x).
	 * Since is a non polinomic curve the best individual has the less value in the result and the first individual in the population.
	 * the method is based on the Roulette Wheel natural selection. This method return a new population, same size as the origin
	 * 
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param results 		-> the array of results from the evaluation in float[] flavor
	 * @param pointer 		-> the pointer is the maximum number of individuals in the roulette wheel.
	 * @param displace 		-> this parameter move the nonpolinomic curve in the y Axis.
	 * @return char[][] population.
	 * 
	 * 
	 */
	public char[][] RouletteWheelNonPolinomicMin(char[][] srtPopulation, float[] results, int pointer, int displace)
	{
		//clone the array.
		ArrayList<char[]> arrRwheelPop = new ArrayList <char[]>();
		int index;
		
		for(int i = 0; i < srtPopulation.length; i++) 
		{
			index = (int)((results[0] / results[i] * (pointer / (i + 1))) - displace);
			for(int j = 0; j < index; ++j)
			{
				arrRwheelPop.add(srtPopulation[i]);
			}
		}
		char[][] bigArray = new char[arrRwheelPop.size()][];
		bigArray = arrRwheelPop.toArray(bigArray);
		
		char[][] RwheelPop = new char[srtPopulation.length][];
		Random rand = new Random();
		for(int i = 0; i < srtPopulation.length; i++)
		{
			RwheelPop[i] = new char[srtPopulation[i].length];
			RwheelPop[i] = bigArray[rand.nextInt(bigArray.length)];
		}
		
	return RwheelPop;
	}
	/**
	 * RouletteWheelNonPolinomicMin method.
	 * select a number of indiviudals depending of their ranking in the population.
	 * the best ranked individuals have more chance to be selected thant worst. 
	 * Although all the individuals has a chance to be selected. the roulette wheel is based in a non polinomic curve (y = 1/x).
	 * Since is a non polinomic curve the best individual has the less value in the result and the first individual in the population.
	 * the method is based on the Roulette Wheel natural selection. This method return a new population, same size as the origin
	 * 
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param results 		-> the array of results from the evaluation in int[] flavor
	 * @param pointer 		-> the pointer is the maximum number of individuals in the roulette wheel.
	 * @param displace 		-> this parameter move the nonpolinomic curve in the y Axis.
	 * @return char[][] population.
	 * 
	 * 
	 */
	public char[][] RouletteWheelNonPolinomicMin(char[][] srtPopulation, int[] results, int pointer, int displace)
	{
		//clone the array.
		ArrayList<char[]> arrRwheelPop = new ArrayList <char[]>();
		int index;
		
		for(int i = 0; i < srtPopulation.length; i++) 
		{
			index = (int)((results[0] / results[i] * (pointer / (i + 1))) - displace);
			for(int j = 0; j < index; ++j)
			{
				arrRwheelPop.add(srtPopulation[i]);
			}
		}
		char[][] bigArray = new char[arrRwheelPop.size()][];
		bigArray = arrRwheelPop.toArray(bigArray);
		
		char[][] RwheelPop = new char[srtPopulation.length][];
		Random rand = new Random();
		for(int i = 0; i < srtPopulation.length; i++)
		{
			RwheelPop[i] = new char[srtPopulation[i].length];
			RwheelPop[i] = bigArray[rand.nextInt(bigArray.length)];
		}
		
	return RwheelPop;
	}
	/**
	 * RouletteWheelSigmoidal method.
	 * select a number of indiviudals depending of their ranking in the population.
	 * the best ranked individuals have more chance to be selected thant worst. 
	 * Although all the individuals has a chance to be selected. the roulette wheel is based in sigmoidal curve, (See RouletteWheelSigmoidalEngine.pde).
	 * 
	 * @param srtPopulation -> a sorted population by any sort algorithm.
	 * @param sizeRoulette  -> number of the individuals selected.
	 * @param A1			-> the maximum number of individuals in the roulette wheel (aprox).
	 * @param A2 			-> the minimum number of individuals in the roulette wheel (aprox).
	 * @param B1 	 		-> the start scope in the population, i.e. 1 the selection will start in the second individual
	 * @param B2	 		-> the end scope in the population, i.e. the size of the population: the las individuals (worst) will be included.
	 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
	 * @return char[][] population.
	 * 
	 * 
	 */
	public char[][] RouletteWheelSigmoidal(char[][] srtPopulation, int sizeRoulette, int A1, int A2, int B1, int B2, float s)
	{
		//clone the array.
		ArrayList<char[]> arrRwheelPop = new ArrayList <char[]>();
		int index;
		
		for(int i = B1; i < B2; i++) 
		{
			index = (int)(A1 + (A2 - A1) / (1 + Math.exp(Math.log(1 / s - 1) * (B1 + B2 - 2 * i) / (B2 - B1))));
			for(int j = 0; j < index; ++j)
			{
				arrRwheelPop.add(srtPopulation[i]);
			}
		}
		char[][] bigArray = new char[arrRwheelPop.size()][];
		bigArray = arrRwheelPop.toArray(bigArray);
		
		char[][] RwheelPop = new char[sizeRoulette][];
		Random rand = new Random();
		for(int i = 0; i < sizeRoulette; i++)
		{
			RwheelPop[i] = new char[srtPopulation[i].length];
			RwheelPop[i] = bigArray[rand.nextInt(bigArray.length)];
		}
		
	return RwheelPop;
	}
	/**
	 * TournamentSelection method.
	 * select a number of indiviudals trough a tournament selection.
	 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
	 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
	 * This method return a new population and can be bigger than the original size.
	 * in the TorunamentSelection method is not necessary a sorted population.
	 * 
	 * @param srtPopulation -> a population.
	 * @param resutls		-> the array of results from the evaluation in float[] flavor.
	 * @param numbTour 		-> the quantity of tournaments, any integer.
	 * @param preasure 	 	-> number of individuals in the competition.
	 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
	 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
	 * @return char[][] population.
	 * 
	 * 
	 */
	public char[][] TournamentSelection(char[][] srtPopulation, float[] results, int numbTour, int preasure, String type)
	{
		char[][] TourPop = new char[numbTour][];
		char[][] arrTour;
		float[] arrResults = new float[preasure];
		
		Random rnd = new Random();
		int index;
		for(int i = 0; i < numbTour; ++i)
		{
			arrTour = new char[preasure][];
			for(int j = 0; j < preasure; ++j)
			{
				index = rnd.nextInt(srtPopulation.length);
				arrTour[j] = srtPopulation[index];
				arrResults[j] = results[index];
				
			}
			TourPop[i] = Tournament(arrTour, arrResults, type);
		}
		
		return TourPop;
	}
	/**
	 * TournamentSelection method.
	 * select a number of indiviudals trough a tournament selection.
	 * As medieval tournament, the individuals have to compete in a tournament, the best individuals will be selected by the next generation
	 * An interest parameter is the preasure: as bigger value is, best individuals will be selected.
	 * This method return a new population and can be bigger than the original size.
	 * in the TorunamentSelection method is not necessary a sorted population.
	 * 
	 * @param srtPopulation -> a population.
	 * @param resutls		-> the array of results from the evaluation in int[] flavor.
	 * @param numbTour 		-> the quantity of tournaments, any integer.
	 * @param preasure 	 	-> number of individuals in the competition.
	 * @param type	 		-> String value: if is "min" the competition will select as a "winner" the smallest value in the population. other the bigger.
	 * @param s				-> the decay of the curve. (See RouletteWheelSigmoidalEngine.pde).
	 * @return char[][] population.
	 * 
	 * 
	 */
	public char[][] TournamentSelection(char[][] srtPopulation, int[] results, int numbTour, int preasure, String type)
	{
		char[][] TourPop = new char[numbTour][];
		char[][] arrTour;
		int[] arrResults = new int[preasure];
		
		Random rnd = new Random();
		int index;
		for(int i = 0; i < numbTour; ++i)
		{
			arrTour = new char[preasure][];
			for(int j = 0; j < preasure; ++j)
			{
				index = rnd.nextInt(srtPopulation.length);
				arrTour[j] = srtPopulation[index];
				arrResults[j] = results[index];
				
			}
			TourPop[i] = Tournament(arrTour, arrResults, type);
		}
		
		return TourPop;
	}	
	char[] Tournament(char[][] torneo, float[] results, String type)
	{
		float test = results[0];
		int c = 0;
		if(type == "min")
		{
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test > results[i])
				{
					test = results[i];
					c = i;
				}
			}
		}
		else
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test < results[i])
				{
					test = results[i];
					c = i;
				}
			}
	
		char[] winner = new char[torneo[0].length];
		winner = torneo[c];
		return winner;
	}
	char[] Tournament(char[][] torneo, int[] results, String type)
	{
		int test = results[0];
		int c = 0;
		if(type == "min")
		{
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test > results[i])
				{
					test = results[i];
					c = i;
				}
			}
		}
		else
			for(int i = 0; i < torneo.length; ++i)
			{
				if(test < results[i])
				{
					test = results[i];
					c = i;
				}
			}
		char[] winner = new char[torneo[0].length];
		winner = torneo[c];
		return winner;
	}

}
