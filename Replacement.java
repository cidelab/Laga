package laga;
import java.util.Random;

import processing.core.*;

/**
 *The Replace class has some methods to create and initialize the replacement population with the new individuals.
 *only a char random replace is implemented
 */
public class Replacement {
	PApplet myparent;
	LagaTools lTools;
	
	public Replacement(PApplet parent)
	{
		myparent = parent;
		lTools = new LagaTools();
	}
	
	//////////////////////////OBJECTS/////////////////////////////////////
	/**
	 * ReplaceInheritance method.
	 * this replace method is ideal for combinatorial problems with objects types in chromsome.
	 * and where is not possible generate new data in the replacement population.
	 * The Replace Inheritance use the parents and the mutated Inheritance. becareful...
	 *
	 * @param sonMutPopulation  -> the son mutated population
	 * @param ParentsPopulation -> the parents population.
	 * @param sizePopulation    -> the size of the population.
	 * @return Object[][] new population.
	 * 
	 * 
	 */
	public Object[][] ReplaceInheritance(Object[][] sonMutPopulation, Object[][] ParentsPopulation, int sizePopulation)
	{
		Object[][] newPopulation = new Object[sizePopulation][];
		
		Object[][] newPopulation1 = new Object[sonMutPopulation.length][]; //copy the sons part.
		for(int i = 0; i < sonMutPopulation.length; i++) {
			newPopulation1[i] = new Object[sonMutPopulation[i].length];
			System.arraycopy(sonMutPopulation[i], 0, newPopulation1[i], 0, sonMutPopulation[i].length);
		}
		
		Object[][] newPopulation2 = new Object[ParentsPopulation.length][]; //copy the parents part.
		for(int i = 0; i < ParentsPopulation.length; i++) {
			newPopulation2[i] = new Object[ParentsPopulation[i].length];
			System.arraycopy(ParentsPopulation[i], 0, newPopulation2[i], 0, ParentsPopulation[i].length);
		}
		

		for(int i = 0; i < sonMutPopulation.length; ++i) { //copy the son parts...
			newPopulation[i] = newPopulation1[i];
		}
		
		Random rnd = new Random();
		int rndIndex;
		for(int i = sonMutPopulation.length; i < sizePopulation; ++i)
		{
			rndIndex = rnd.nextInt(ParentsPopulation.length);
			newPopulation[i] = newPopulation2[rndIndex];
		}
		
		return newPopulation;
	}
	
	/**
	 * ReplaceRandom method.
	 * this replace method create a new population using the mutated inheritance and new random chromsomes.
	 *
	 * @param sonMutPopulation  -> the son mutated population
	 * @param percent 			-> the random level of the new chromosomes. 0 < level < 1.
	 * @param sizePopulation    -> the size of the population.
	 * @return Object[][] new population.
	 * 
	 * 
	 */
	public Object[][] ReplaceRandom(Object[][] sonMutPopulation, float percent, int sizePopulation)
	{
		Object[][] newPopulation = new Object[sizePopulation][];
		
		Object[][] newPopulation1 = new Object[sonMutPopulation.length][]; //copy the sons part.
		for(int i = 0; i < sonMutPopulation.length; i++) {
			newPopulation1[i] = new Object[sonMutPopulation[i].length];
			System.arraycopy(sonMutPopulation[i], 0, newPopulation1[i], 0, sonMutPopulation[i].length);
		}
		
		for(int i = 0; i < sonMutPopulation.length; ++i) { //copy the son parts...
			newPopulation[i] = newPopulation1[i];
		}
		
		int c = 0;
		for(int i = sonMutPopulation.length; i < sizePopulation; ++i)
		{
			newPopulation[i] = lTools.fisher_yatesPercent(newPopulation1[c], percent);   //fisher_yates_Percent(newPopulation1[c], percent);
			c++;
			if(c == newPopulation1.length) c = 0;
		}
		
		return newPopulation;
	}	
	
	/**
	 * ReplaceInheritanceRandom method.
	 * this replace method is based in a mix between inheritance and random method, the percentInherit, determines how many
	 * individuals will (parents) and how many new ones will be created for the new population.
	 * 
	 *
	 * @param sonMutPopulation  -> the son mutated population
	 * @param ParentsPopulation -> the parents population.
	 * @param sizePopulation    -> the size of the population.
	 * @param min    			-> min value in the chromosome.
	 * @param max    			-> max value in the chromosome.
	 * @param percentInherit    -> percentInherit.
	 * @return Object[][] new population.
	 * 
	 * 
	 */
	public Object[][] ReplaceInheritanceRandom(Object[][] sonMutPopulation, Object[][] ParentsPopulation, int sizePopulation, float percentInherit)
	{
		int resta = sizePopulation - sonMutPopulation.length;
		int cant = (int)(resta*percentInherit);
		if(cant > ParentsPopulation.length){cant = ParentsPopulation.length;}
		
		Object[][] newPopulation = new Object[sizePopulation][];
		
		Object[][] newSon = new Object[sonMutPopulation.length][]; //copiamos la herencia...
		for(int i = 0; i < sonMutPopulation.length; ++i) {
			newSon[i] = new Object[sonMutPopulation[i].length];
			System.arraycopy(sonMutPopulation[i], 0, newSon[i], 0, sonMutPopulation[i].length); }
		
		Object[][] newParents = new Object[ParentsPopulation.length][]; //copiamos los padres...
		for(int i = 0; i < ParentsPopulation.length; ++i) {
			newParents[i] = new Object[ParentsPopulation[i].length];
			System.arraycopy(ParentsPopulation[i], 0, newParents[i], 0, ParentsPopulation[i].length); }
		
		//construccion
		//copiamos los hijos...
		for(int i = 0; i < sonMutPopulation.length; ++i) { //copy the son parts...
			newPopulation[i] = newSon[i];
		}
		
		//copiamos a los padres...
		int c  = newSon.length;
		for(int i = 0; i < cant; ++i)
		{
			if(i == ParentsPopulation.length){ break; }
			newPopulation[c] = newParents[i];
			c++;
		}
		
		for(int i = c; i < sizePopulation; i++)
		{
			newPopulation[i] = lTools.fisher_yates(ParentsPopulation[0]); //) fisher_yates(ParentsPopulation[0]);
		}
		
		return newPopulation;
	}	

	//////////////////////////DOUBLE/////////////////////////////////////
	/**
	 * ReplaceInheritance method.
	 * this replace method is ideal for combinatorial problems with float types in chromsome.
	 * and where is not possible generate new data in the replacement population.
	 * The Replace Inheritance use the parents and the mutated Inheritance. to create a new population
	 *
	 * @param sonMutPopulation  -> the son mutated population
	 * @param ParentsPopulation -> the parents population.
	 * @param sizePopulation    -> the size of the population.
	 * @return double[][] new population.
	 * 
	 * 
	 */
	public double[][] ReplaceInheritance(double[][] sonMutPopulation, double[][] ParentsPopulation, int sizePopulation)
	{
		double[][] newPopulation = new double[sizePopulation][];
		
		double[][] newPopulation1 = new double[sonMutPopulation.length][]; //copy the sons part.
		for(int i = 0; i < sonMutPopulation.length; i++) {
			newPopulation1[i] = new double[sonMutPopulation[i].length];
			System.arraycopy(sonMutPopulation[i], 0, newPopulation1[i], 0, sonMutPopulation[i].length);
		}
		
		double[][] newPopulation2 = new double[ParentsPopulation.length][]; //copy the parents part.
		for(int i = 0; i < ParentsPopulation.length; i++) {
			newPopulation2[i] = new double[ParentsPopulation[i].length];
			System.arraycopy(ParentsPopulation[i], 0, newPopulation2[i], 0, ParentsPopulation[i].length);
		}
		

		for(int i = 0; i < sonMutPopulation.length; ++i) { //copy the son parts...
			newPopulation[i] = newPopulation1[i];
		}
		
		Random rnd = new Random();
		int rndIndex;
		for(int i = sonMutPopulation.length; i < sizePopulation; ++i)
		{
			rndIndex = rnd.nextInt(ParentsPopulation.length);
			newPopulation[i] = newPopulation2[rndIndex];
		}
		
		return newPopulation;
	}
	
	/**
	 * ReplaceRandom method.
	 * this replace method create a new population using the mutated inheritance and new random chromsomes.
	 *
	 * @param sonMutPopulation  -> the son mutated population
	 * @param sizePopulation    -> the size of the population.
	 * @param min				-> the minimum value in the crhomosome
	 * @param max				-> the maximum value in the chromosome
	 * @return double[][] new population.
	 * 
	 * 
	 */
	public double[][] ReplaceRandom(double[][] sonMutPopulation, int sizePopulation, double min, double max)
	{
		double[][] newPopulation = new double[sizePopulation][];
		
		double[][] newPopulation1 = new double[sonMutPopulation.length][]; //copy the sons part.
		for(int i = 0; i < sonMutPopulation.length; i++) {
			newPopulation1[i] = new double[sonMutPopulation[i].length];
			System.arraycopy(sonMutPopulation[i], 0, newPopulation1[i], 0, sonMutPopulation[i].length);
		}
		
		for(int i = 0; i < newPopulation1.length;++i)	
		{
			newPopulation[i] = newPopulation1[i];
		}

		double[] newChrom;
		Random rnd = new Random();
		for(int i = newPopulation1.length; i < sizePopulation; ++i)
		{
			newChrom = new double[sonMutPopulation[0].length];
			for(int j = 0; j < newChrom.length; ++j)
			{
				newChrom[j] = min + rnd.nextDouble() * (max - min);
			}
			newPopulation[i] = newChrom;
		}
		
		return newPopulation;
	}
	
	/**
	 * ReplaceInheritanceRandom method.
	 * this replace method is based in a mix between inheritance and random method, the percentInherit, determines how many
	 * individuals will (parents) and how many new ones will be created for the new population.
	 * 
	 *
	 * @param sonMutPopulation  -> the son mutated population
	 * @param ParentsPopulation -> the parents population.
	 * @param sizePopulation    -> the size of the population.
	 * @param min    			-> min value in the chromosome.
	 * @param max    			-> max value in the chromosome.
	 * @param percentInherit    -> percentInherit.
	 * @return double[][] new population.
	 * 
	 * 
	 */
	public double[][] ReplaceInheritanceRandom(double[][] sonMutPopulation, double[][] ParentsPopulation, int sizePopulation, double min, double max, float percentInherit)
	{
		int resta = sizePopulation - sonMutPopulation.length;
		int cant = (int)(resta * percentInherit);
		if(cant > ParentsPopulation.length) {cant = ParentsPopulation.length;}
		
		double[][] newPopulation = new double[sizePopulation][];
		
		double[][] sonPop = new double[sonMutPopulation.length][]; //copy the sons part.
		for(int i = 0; i < sonMutPopulation.length; i++) {
			sonPop[i] = new double[sonMutPopulation[i].length];
			System.arraycopy(sonMutPopulation[i], 0, sonPop[i], 0, sonMutPopulation[i].length);
		}
		
		double[][] newPopulation2 = new double[ParentsPopulation.length][]; //copy the parents part.
		for(int i = 0; i < ParentsPopulation.length; i++) {
			newPopulation2[i] = new double[ParentsPopulation[i].length];
			System.arraycopy(ParentsPopulation[i], 0, newPopulation2[i], 0, ParentsPopulation[i].length);
		}
		
		//copiamos a los hijos
		for(int i = 0; i < sonPop.length; ++i) {newPopulation[i] = sonPop[i];}
		
		//copiamos a los padres.
		int c  = sonPop.length;
		for(int i = 0; i < cant; ++i)
		{
			if(i == ParentsPopulation.length){ break; }
			newPopulation[c] = newPopulation2[i];
			c++;
		}
		
		Random rnd = new Random();
		double[] newChrom;
		for(int i = c; i < newPopulation.length; ++i)
		{
			newChrom = new double[sonMutPopulation[0].length];
			for(int j = 0; j < newChrom.length; ++j)
			{
				newChrom[j] = min + rnd.nextDouble() * (max - min);
			}
			newPopulation[i] = newChrom;
		}
		
		return newPopulation;
	}

	//////////////////////////FLOAT/////////////////////////////////////	
	/**
	 * ReplaceInheritance method.
	 * this replace method is ideal for combinatorial problems with float types in chromsome.
	 * and where is not possible generate new data in the replacement population.
	 * The Replace Inheritance use the parents and the mutated Inheritance. to create a new population
	 *
	 * @param sonMutPopulation  -> the son mutated population
	 * @param ParentsPopulation -> the parents population.
	 * @param sizePopulation    -> the size of the population.
	 * @return float[][] new population.
	 * 
	 * 
	 */
	public float[][] ReplaceInheritance(float[][] sonMutPopulation, float[][] ParentsPopulation, int sizePopulation)
	{
		float[][] newPopulation = new float[sizePopulation][];
		
		float[][] newPopulation1 = new float[sonMutPopulation.length][]; //copy the sons part.
		for(int i = 0; i < sonMutPopulation.length; i++) {
			newPopulation1[i] = new float[sonMutPopulation[i].length];
			System.arraycopy(sonMutPopulation[i], 0, newPopulation1[i], 0, sonMutPopulation[i].length);
		}
		
		float[][] newPopulation2 = new float[ParentsPopulation.length][]; //copy the parents part.
		for(int i = 0; i < ParentsPopulation.length; i++) {
			newPopulation2[i] = new float[ParentsPopulation[i].length];
			System.arraycopy(ParentsPopulation[i], 0, newPopulation2[i], 0, ParentsPopulation[i].length);
		}
		

		for(int i = 0; i < sonMutPopulation.length; ++i) { //copy the son parts...
			newPopulation[i] = newPopulation1[i];
		}
		
		Random rnd = new Random();
		int rndIndex;
		for(int i = sonMutPopulation.length; i < sizePopulation; ++i)
		{
			rndIndex = rnd.nextInt(ParentsPopulation.length);
			newPopulation[i] = newPopulation2[rndIndex];
		}
		
		return newPopulation;
	}
	
	/**
	 * ReplaceRandom method.
	 * this replace method create a new population using the mutated inheritance and new random chromsomes.
	 *
	 * @param sonMutPopulation  -> the son mutated population
	 * @param sizePopulation    -> the size of the population.
	 * @param min				-> the minimum value in the crhomosome
	 * @param max				-> the maximum value in the chromosome
	 * @return float[][] new population.
	 * 
	 * 
	 */
	public float[][] ReplaceRandom(float[][] sonMutPopulation, int sizePopulation, float min, float max)
	{
		float[][] newPopulation = new float[sizePopulation][];
		
		float[][] newPopulation1 = new float[sonMutPopulation.length][]; //copy the sons part.
		for(int i = 0; i < sonMutPopulation.length; i++) {
			newPopulation1[i] = new float[sonMutPopulation[i].length];
			System.arraycopy(sonMutPopulation[i], 0, newPopulation1[i], 0, sonMutPopulation[i].length);
		}
		
		for(int i = 0; i < newPopulation1.length;++i)	
		{
			newPopulation[i] = newPopulation1[i];
		}

		float[] newChrom;
		Random rnd = new Random();
		for(int i = newPopulation1.length; i < sizePopulation; ++i)
		{
			newChrom = new float[sonMutPopulation[0].length];
			for(int j = 0; j < newChrom.length; ++j)
			{
				newChrom[j] = min + rnd.nextFloat() * (max - min);
			}
			newPopulation[i] = newChrom;
		}
		
		return newPopulation;
	}
	
	/**
	 * ReplaceInheritanceRandom method.
	 * this replace method is based in a mix between inheritance and random method, the percentInherit, determines how many
	 * individuals will (parents) and how many new ones will be created for the new population.
	 * 
	 *
	 * @param sonMutPopulation  -> the son mutated population
	 * @param ParentsPopulation -> the parents population.
	 * @param sizePopulation    -> the size of the population.
	 * @param min    			-> min value in the chromosome.
	 * @param max    			-> max value in the chromosome.
	 * @param percentInherit    -> percentInherit.
	 * @return float[][] new population.
	 * 
	 * 
	 */
	public float[][] ReplaceInheritanceRandom(float[][] sonMutPopulation, float[][] ParentsPopulation, int sizePopulation, float min, float max, float percentInherit)
	{
		int resta = sizePopulation - sonMutPopulation.length;
		int cant = (int)(resta * percentInherit);
		if(cant > ParentsPopulation.length) {cant = ParentsPopulation.length;}
		
		float[][] newPopulation = new float[sizePopulation][];
		
		float[][] sonPop = new float[sonMutPopulation.length][]; //copy the sons part.
		for(int i = 0; i < sonMutPopulation.length; i++) {
			sonPop[i] = new float[sonMutPopulation[i].length];
			System.arraycopy(sonMutPopulation[i], 0, sonPop[i], 0, sonMutPopulation[i].length);
		}
		
		float[][] newPopulation2 = new float[ParentsPopulation.length][]; //copy the parents part.
		for(int i = 0; i < ParentsPopulation.length; i++) {
			newPopulation2[i] = new float[ParentsPopulation[i].length];
			System.arraycopy(ParentsPopulation[i], 0, newPopulation2[i], 0, ParentsPopulation[i].length);
		}
		
		//copiamos a los hijos
		for(int i = 0; i < sonPop.length; ++i) {newPopulation[i] = sonPop[i];}
		
		//copiamos a los padres.
		int c  = sonPop.length;
		for(int i = 0; i < cant; ++i)
		{
			if(i == ParentsPopulation.length){ break; }
			newPopulation[c] = newPopulation2[i];
			c++;
		}
		
		Random rnd = new Random();
		float[] newChrom;
		for(int i = c; i < newPopulation.length; ++i)
		{
			newChrom = new float[sonMutPopulation[0].length];
			for(int j = 0; j < newChrom.length; ++j)
			{
				newChrom[j] = min + rnd.nextFloat() * (max - min);
			}
			newPopulation[i] = newChrom;
		}
		
		return newPopulation;
	}
	
	//////////////////////////INTEGER///////////////////////////////////////
	/**
	 * ReplaceInheritance method.
	 * this replace method is ideal for combinatorial problems with float types in chromsome.
	 * and where is not possible generate new data in the replacement population.
	 * The Replace Inheritance use the parents and the mutated Inheritance. to create a new population
	 *
	 * @param sonMutPopulation  -> the son mutated population
	 * @param ParentsPopulation -> the parents population.
	 * @param sizePopulation    -> the size of the population.
	 * @return int[][] new population.
	 * 
	 * 
	 */
	public int[][] ReplaceInheritance(int[][] sonMutPopulation, int[][] ParentsPopulation, int sizePopulation)
	{
		int[][] newPopulation = new int[sizePopulation][];
		
		int[][] newPopulation1 = new int[sonMutPopulation.length][]; //copy the sons part.
		for(int i = 0; i < sonMutPopulation.length; i++) {
			newPopulation1[i] = new int[sonMutPopulation[i].length];
			System.arraycopy(sonMutPopulation[i], 0, newPopulation1[i], 0, sonMutPopulation[i].length);
		}
		
		int[][] newPopulation2 = new int[ParentsPopulation.length][]; //copy the parents part.
		for(int i = 0; i < ParentsPopulation.length; i++) {
			newPopulation2[i] = new int[ParentsPopulation[i].length];
			System.arraycopy(ParentsPopulation[i], 0, newPopulation2[i], 0, ParentsPopulation[i].length);
		}
		

		for(int i = 0; i < sonMutPopulation.length; ++i) { //copy the son parts...
			newPopulation[i] = newPopulation1[i];
		}
		
		Random rnd = new Random();
		int rndIndex;
		for(int i = sonMutPopulation.length; i < sizePopulation; ++i)
		{
			rndIndex = rnd.nextInt(ParentsPopulation.length);
			newPopulation[i] = newPopulation2[rndIndex];
		}
		
		return newPopulation;
	}
		
	/**
	 * ReplaceRandom method.
	 * this replace method create a new population using the mutated inheritance and new random chromsomes.
	 *
	 * @param sonMutPopulation  -> the son mutated population
	 * @param sizePopulation    -> the size of the population.
	 * @param min				-> the minimum value in the crhomosome
	 * @param max				-> the maximum value in the chromosome
	 * @return int[][] new population.
	 * 
	 * 
	 */
	public int[][] ReplaceRandom(int[][] sonMutPopulation, int sizePopulation, int min, int max)
	{
		int[][] newPopulation = new int[sizePopulation][];
		
		int[][] newPopulation1 = new int[sonMutPopulation.length][]; //copy the sons part.
		for(int i = 0; i < sonMutPopulation.length; i++) {
			newPopulation1[i] = new int[sonMutPopulation[i].length];
			System.arraycopy(sonMutPopulation[i], 0, newPopulation1[i], 0, sonMutPopulation[i].length);
		}
		
		for(int i = 0; i < newPopulation1.length;++i)	
		{
			newPopulation[i] = newPopulation1[i];
		}

		int[] newChrom;
		Random rnd = new Random();
		for(int i = newPopulation1.length; i < sizePopulation; ++i)
		{
			newChrom = new int[sonMutPopulation[0].length];
			for(int j = 0; j < newChrom.length; ++j)
			{
				newChrom[j] = (int)(min + rnd.nextDouble() * (max - min));
			}
			newPopulation[i] = newChrom;
		}
		
		return newPopulation;
	}
		
	/**
	 * ReplaceInheritanceRandom method.
	 * this replace method is based in a mix between inheritance and random method, the percentInherit, determines how many
	 * individuals will (parents) and how many new ones will be created for the new population.
	 * 
	 *
	 * @param sonMutPopulation  -> the son mutated population
	 * @param ParentsPopulation -> the parents population.
	 * @param sizePopulation    -> the size of the population.
	 * @param min    			-> min value in the chromosome.
	 * @param max    			-> max value in the chromosome.
	 * @param percentInherit    -> percentInherit.
	 * @return int[][] new population.
	 * 
	 * 
	 */
	public int[][] ReplaceInheritanceRandom(int[][] sonMutPopulation, int[][] ParentsPopulation, int sizePopulation, int min, double max, float percentInherit)
	{
		int resta = sizePopulation - sonMutPopulation.length;
		int cant = (int)(resta * percentInherit);
		if(cant > ParentsPopulation.length) {cant = ParentsPopulation.length;}
		
		int[][] newPopulation = new int[sizePopulation][];
		
		int[][] sonPop = new int[sonMutPopulation.length][]; //copy the sons part.
		for(int i = 0; i < sonMutPopulation.length; i++) {
			sonPop[i] = new int[sonMutPopulation[i].length];
			System.arraycopy(sonMutPopulation[i], 0, sonPop[i], 0, sonMutPopulation[i].length);
		}
		
		int[][] newPopulation2 = new int[ParentsPopulation.length][]; //copy the parents part.
		for(int i = 0; i < ParentsPopulation.length; i++) {
			newPopulation2[i] = new int[ParentsPopulation[i].length];
			System.arraycopy(ParentsPopulation[i], 0, newPopulation2[i], 0, ParentsPopulation[i].length);
		}
		
		//copiamos a los hijos
		for(int i = 0; i < sonPop.length; ++i) {newPopulation[i] = sonPop[i];}
		
		//copiamos a los padres.
		int c  = sonPop.length;
		for(int i = 0; i < cant; ++i)
		{
			if(i == ParentsPopulation.length){ break; }
			newPopulation[c] = newPopulation2[i];
			c++;
		}
		
		Random rnd = new Random();
		int[] newChrom;
		for(int i = c; i < newPopulation.length; ++i)
		{
			newChrom = new int[sonMutPopulation[0].length];
			for(int j = 0; j < newChrom.length; ++j)
			{
				newChrom[j] = (int)(min + rnd.nextDouble() * (max - min));
			}
			newPopulation[i] = newChrom;
		}
		
		return newPopulation;
	}

//////////////////////////CHARACTER/////////////////////////////////////
	/** CharRandomReplace method.
	 * set a new a population from the selected individuals.
	 *
	 * @param newPartOfPopulation -> selected individuals.
	 * @param sizePopulation      -> the size of the population.
	 * @return char[][] population.
	 * 
	 * 
	 */
	public char[][] CharRandomReplace(char[][] newPartOfPopulation, int sizePopulation)
	{
		char[][] newPopulation = new char[sizePopulation][];
		char[] charRand;

		for(int i = 0; i < newPartOfPopulation.length; i++)
		{
			newPopulation[i] = new char[newPartOfPopulation[i].length];
			System.arraycopy(newPartOfPopulation[i], 0, newPopulation[i], 0, newPartOfPopulation[i].length);
		}

		for(int i = newPartOfPopulation.length; i < sizePopulation; ++i)
		{
			charRand = new char[newPartOfPopulation[0].length];
			for(int j = 0; j < newPartOfPopulation[0].length; ++j)
			{
				charRand[j] = lTools.RandomChar();
			}
			newPopulation[i] = charRand;
		}
		return newPopulation;
	}
	
}
