package laga;
import java.util.Random;

public class LagaTools {

	public LagaTools()
	{

	}

 public int[] fisher_yates(int[] arrData)
	{ 
		int[] mutChrom = new int[arrData.length];
		System.arraycopy(arrData, 0, mutChrom, 0, arrData.length);

		Random rnd = new Random();
		for (int i = arrData.length; i > 1; i--)
		{
			int j = rnd.nextInt(i);// 0 <= j <= i-1
			int temp = mutChrom[j];

			mutChrom[j] = mutChrom[i - 1];
			mutChrom[i - 1] = temp;
		}
		return mutChrom;
	}
	
	public Object[] fisher_yates(Object[] chrom)
	{
		Random rnd = new Random();
		for (int i = chrom.length - 1; i > 0; i--)
		{
			int index = rnd.nextInt(i); // 0 <= j <= i-1
			
			//swap
			Object temp = chrom[index];
			chrom[index] = chrom[i];
			chrom[i] = temp;
		}
		return chrom;
	}
	
	public Object[] fisher_yatesPercent(Object[] chrom, float percent)
	{
		int cant = (int)(chrom.length * percent);
		if (cant == 0){cant = 1;}
		
		Random rnd = new Random();
		for (int i = cant - 1; i > 0; i--)
		{
			int index = rnd.nextInt(i);// 0 <= j <= i-1
			
			//swap
			Object temp = chrom[index];
			chrom[index] = chrom[i];
			chrom[i] = temp;
		}
		return chrom;
	}
	
	public char RandomCharBinary() {
		Random rnd = new Random();
		char t;
		if(rnd.nextFloat() < 0.5)
		{
			t = '1';
		}
		else
		{
			t = '0';
		}
		return t;
	}
		
	public char RandomChar()
	{
		Random rnd = new Random();
		int index;
		
		if(rnd.nextFloat() < 0.8) 
		{ 
			index = rnd.nextInt(26) + 97;
		}
		else 
		{
			index = 95;
		}

		return (char)index;
	}

}
