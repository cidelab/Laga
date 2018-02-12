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

  //laga part
  numbPop = new GenrPopulation(this);
  int[][] letterCharPop = numbPop.BinaryPopulationInt(sizePop,sizeChromosome);
  float[][] binaryCharPop = numbPop.NumbPopulation(sizePop,sizeChromosome,0f,1f);
  
  textSize(12);
   for(int i = 0; i < sizePop; i++)
  {
    fill(0);
    text("ind " + i + ": ", 15, 55 + (i*18));
    text("ind " + i + ": ", 15, 265 + (i*18));
    for(int j = 0; j < sizeChromosome; j++)
    {
      fill(0, 0, 255);
      text(letterCharPop[i][j], 65 + (j * 15), 55 + (i*18));
      text(binaryCharPop[i][j], 56 + (j * 50), 265 + (i*18));
    }
  }
  
}

void title()
{
  fill(88, 0, 0);
  text("binary int Population", 14, 40);
  text("float (0, 1) Population", 14, 250);

  
  textSize(16);
  fill(10);
  text("Generate Number Populations", 15, 15);
}