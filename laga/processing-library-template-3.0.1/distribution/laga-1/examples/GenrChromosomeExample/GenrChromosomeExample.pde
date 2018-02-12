import laga.*;

/*
show how to initialize and implement the GenrChromosome class.
laga supports (for now) 6 different types of chromosomes but only one way
to build them.
*/

GenrChromosome gChro;

int len = 10;

double dblMin = 0.01;
double dblMax = 3.99;

float fltMin = 1.0;
float fltMax = 2.0;

int intMin = 0;
int intMax = 10;

int[] binChr;
char[] charChr;
double[] dblChr;
float[] fltChr;
int[] intMinMaxChr;
int[] intSwapChr;

PFont f;

void setup()
{
  size(640, 300);
  f = createFont("Ubuntu", 12);
  textFont(f);
  textAlign(LEFT, CENTER);
  
  gChro = new GenrChromosome(this);
  frameRate(10);
}

void draw()
{
  background(255);
  binChr = gChro.BinaryChromosome(len);
  charChr = gChro.CharChromosome(len);
  dblChr = gChro.NumberChromosome(len, dblMin, dblMax);
  fltChr = gChro.NumberChromosome(len, fltMin, fltMax);
  intMinMaxChr = gChro.NumberChromosome(len, intMin, intMax);
  intSwapChr = gChro.NumberChromosomeSwap(len);
  
  title();

  for(int i = 0; i < len; i++)
  {
    text(charChr[i], 15 + (i * 30), 60);
    text(binChr[i], 15 + (i * 30), 100);
    text(intMinMaxChr[i], 15 + (i * 30), 140);
    text((float)dblChr[i], 9 + (i * 50), 180);
    text(fltChr[i], 9 + (i * 50), 220);
    text(intSwapChr[i], 15 + (i * 30), 260);
  }

}

void title()
{
  fill(88, 0,0);
  text("Char Chromosome: abc_d", 15, 46);
  text("Binary Chromosome: 10101", 15, 86);
  text("Integer Chromosome: between min->0 and max->10", 15, 126);
  text("Double Chromosome(converted to display in float type): between min->0.01 and max->3.99", 15, 166);
  text("Float Chromosome: between min->1.0 and max->2.0", 15, 206);
  text("Integer Chromosome: None duplicate integers in the list", 15, 246);
  
  fill(10);
  text("GENERATE CHROMOSOMES", 15, 15);
}