import laga.*;

/*
show how to initialize and implement the GenrPopulation class.
laga supports 7 different population types but only one way
to build them.
 */

GenrPopulation gPop;
Cat[] myCat;
Cat nC;

//variables to define the size and ranges of the population
int popSize = 10;
int chroSize = 5;
double dblMin = 0.01;
double dblMax = 3.99;
float fltMin = 1.0;
float fltMax = 2.0;
int intMin = 0;
int intMax = 10;
float percent = 1;
boolean inOut = false;

//arrays to store the populations...
int[][] binPop;
char[][] charPop;
double[][] dblPop;
float[][] fltPop;
int[][] intMinMaxPop;
int[][] intSwapPop;
Object[][] catPop;

PFont f;

void setup()
{
  size(700, 985);
  f = createFont("Lucida Console", 12);
  textFont(f);
  textAlign(LEFT, CENTER);

  //laga part
  gPop = new GenrPopulation(this);

  //creates the Cat object
  catPop = new Cat[popSize][chroSize];
  myCat = new Cat[chroSize];
  GenrChromosome genCatNames = new GenrChromosome(this);
  String nameCat;
  for (int i = 0; i < chroSize; i++)
  {
    //we use the CharChromosome to generate random names...
    nameCat = new String(genCatNames.CharChromosome(5));
    myCat[i] = new Cat(nameCat, (int)random(9), round(random(7)));
  }

  frameRate(10);
}

void draw()
{
  background(255);
  
  //creates the population...
  binPop = gPop.BinaryPopulationInt(popSize, chroSize);
  charPop = gPop.CharPopulation(popSize, chroSize);
  intSwapPop = gPop.NumbPopulationSwap(popSize, chroSize);
  dblPop = gPop.NumbPopulation(popSize, chroSize, dblMin, dblMax);
  fltPop = gPop.NumbPopulation(popSize, chroSize, fltMin, fltMax);
  intMinMaxPop = gPop.NumbPopulation(popSize, chroSize, intMin, intMax);
  catPop = gPop.ObjectPopulationSwap(popSize, myCat, percent, inOut);

  title();

  textSize(12);
  fill(0, 0, 255);
  for (int i = 0; i < chroSize; i++)
  {
    myCat[i].Display(15, 430 + (i*20));
  }
  
  //display object population
  int iStep = 0;
  int c = 0;
  for(int i = 0; i < popSize; i++)
  {
    for(int j = 0; j < chroSize; j++)
    {
      nC = (Cat)catPop[i][j]; //from object to Cat class
      switch(i)
      {
        case 0: iStep = 559;
        c = 0;
        break;
        
        case 3: iStep = 667;
        c = 0;
        break;
        
        case 6: iStep = 775;
        c = 0;
        break;
        
        case 9: iStep = 883;
        c = 0;
        break;
      }
      nC.Display(15 + (c * 220), iStep + (j*20));
    }
    c++;
  }
  

  for (int i  = 0; i < popSize; i++)
  {
    for (int j = 0; j < chroSize; j++)
    {
      text(charPop[i][j], 15 + (j * 20), 60 + (i*15));
      text(binPop[i][j], 165 + (j * 20), 60 + (i*15)); 
      text(intSwapPop[i][j], 315 + (j * 20), 60 + (i*15));
      text(intMinMaxPop[i][j], 465 + (j * 20), 60 + (i*15));

      text((float)dblPop[i][j], 9 + (j * 50), 244 + (i*15));
      text(fltPop[i][j], 309 + (j * 50), 244 + (i*15));
    }
  }
}

void title()
{
  fill(88, 0, 0);
  text("Char Population", 14, 46);
  text("Binary Population", 164, 46);
  text("Int Population(swap)", 314, 46);
  text("Int Population(min&max)", 464, 46);

  text("Double Population(converted to float)", 15, 230);
  text("Float Population (1.0 < 2.0)", 315, 230);
  text("Object Chromosome Seed (Cat)", 15, 416);
  text("Object Population: 10 individuals", 15, 545);
  
  textSize(16);
  fill(10);
  text("Generate Populations", 15, 20);
}