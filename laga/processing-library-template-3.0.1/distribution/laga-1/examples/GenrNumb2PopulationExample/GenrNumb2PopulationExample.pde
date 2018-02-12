import laga.*;

/*
show how to initialize and implement the GenrPopulation class.
laga supports 7 different population types but only one way
to build them.
 */

GenrPopulation numbPop; //initialise the class

PFont f;

void setup() {
  
  size(700, 450);
  background(255);
  f = createFont("Lucida Console", 12);
  textFont(f);
  textAlign(LEFT, CENTER);
  smooth();
   title();

  int sizePop = 10;
  int sizeChromosome = 12;
  int sizeDblChromosome = 4;

  //laga part
  numbPop = new GenrPopulation(this);
  int[][] intPop = numbPop.NumbPopulation(sizePop,sizeChromosome, 1, 10);
  double[][] dblPop = numbPop.NumbPopulation(sizePop,sizeDblChromosome,0d,1d);
  
  String strDbl;
  
  textSize(12);
   for(int i = 0; i < sizePop; i++)
  {
    fill(0);
    text("ind " + i + ": ", 15, 55 + (i*18));
    text("ind " + i + ": ", 15, 265 + (i*18));
    fill(0, 0, 255);
    for(int j = 0; j < sizeChromosome; j++)
      text(intPop[i][j], 65 + (j * 20), 55 + (i*18));
    
    for(int j = 0; j < sizeDblChromosome; j++)
    {
      strDbl = Double.toString(dblPop[i][j]);
      text(strDbl, 65 + (j * 150), 265 + (i*18));
    }
  }
  
}

void title()
{
  fill(88, 0, 0);
  text("int (1, 10) Population", 14, 40);
  text("double (0, 1) Population", 14, 250);

  
  textSize(16);
  fill(10);
  text("Generate Number Populations", 15, 15);
}