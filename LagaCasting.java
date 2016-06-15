package laga;

public class LagaCasting {
	
	public LagaCasting()
	{
		
	}
	
	public void ReversePopulation(char[][] charPop){
		char[] arrTempInd;
		for(int i = 0; i < charPop.length / 2; i++)
		{
			arrTempInd = new char[charPop[i].length];
			arrTempInd = charPop[i];
			charPop[i] = charPop[charPop.length - i - 1];
			charPop[charPop.length - i - 1] = arrTempInd;
		}
	}
	public void ReversePopulation(int[][] intPop){}
	public void ReversePopulation(double[][] dblPop){}
	public void ReversePopulation(float[][] flPop){}
	public void ReversePopulation(Object[][] objPop){}
	
	public void Reverse(float[] arrFloat){
		float temp;
		for(int i = 0; i < arrFloat.length / 2; i++)
		{
		    temp = arrFloat[i];
		    arrFloat[i] = arrFloat[arrFloat.length - i - 1];
		    arrFloat[arrFloat.length - i - 1] = temp;
		}
	}
	public void Reverse(int[] arrInt){
		int temp;
		for(int i = 0; i < arrInt.length / 2; i++)
		{
		    temp = arrInt[i];
		    arrInt[i] = arrInt[arrInt.length - i - 1];
		    arrInt[arrInt.length - i - 1] = temp;
		}
	}
	public void Reverse(double[] arrDbl){
		double temp;
		for(int i = 0; i < arrDbl.length / 2; i++)
		{
		    temp = arrDbl[i];
		    arrDbl[i] = arrDbl[arrDbl.length - i - 1];
		    arrDbl[arrDbl.length - i - 1] = temp;
		}
	}
}
