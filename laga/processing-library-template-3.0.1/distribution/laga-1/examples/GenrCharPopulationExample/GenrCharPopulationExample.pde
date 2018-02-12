import laga.*;

/*
show how to initialize and implement the GenrPopulation class.
laga supports 7 different population types but only one way
to build them.
 */

GenrPopulation charPop; //initialise the class

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
  int sizeChromosome = 20;

  //laga part
  charPop = new GenrPopulation(this);
  char[][] letterCharPop = charPop.CharPopulation(sizePop,sizeChromosome);
  char[][] binaryCharPop = charPop.BinaryPopulationChr(sizePop,sizeChromosome);
  
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
      text(binaryCharPop[i][j], 65 + (j * 15), 265 + (i*18));
    }
  }
  
}

void title()
{
  fill(88, 0, 0);
  text("letter Char Population", 14, 40);
  text("binnary Char Population", 14, 250);

  
  textSize(16);
  fill(10);
  text("Generate char Populations", 15, 15);
}