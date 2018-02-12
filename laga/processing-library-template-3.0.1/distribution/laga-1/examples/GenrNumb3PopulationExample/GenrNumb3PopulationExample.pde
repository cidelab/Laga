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
  int sizePopCat = 10;
  int sizeChromosome = 20;
  int sizeCatFam = 5;
  float percent = 1;
  boolean includeseed = true;
  
  cat[] catFamily = MakeCatFamily(sizeCatFam);
  cat maceo;
  
  //laga part
  numbPop = new GenrPopulation(this);
  int[][] intPop = numbPop.NumbPopulationSwap(sizePop, sizeChromosome);
  Object[][] catPop = numbPop.ObjectPopulationSwap(sizePopCat, catFamily, percent, includeseed);
  println(catPop[1].length);
  textSize(12);
   for(int i = 0; i < sizePop; i++)
    {
      fill(0);
      text("ind " + i + ": ", 15, 55 + (i*18));
      fill(0, 0, 255);
      for(int j = 0; j < sizeChromosome; j++) 
      {
        text(intPop[i][j], 65 + (j * 20), 55 + (i*18));
      }
    }
    
  for (int i = 0; i < sizeCatFam; i++)
  {
    catFamily[i].Display(15, 265 + (i*20));
    maceo = (cat)catPop[i][0];
    maceo.Display(365, 265 + (i*18));
  }
  
  /*
    for(int i = 0; i < sizePopCat; i++)
    {
      fill(0);
      text("ind " + i + ": ", 15, 265 + (i*18));
      fill(0, 0, 255);
      for(int j = 0; j < sizeCatFam; j++) 
      {
        maceo = (cat)catPop[i][j];
        maceo.Display(65 + (i * 150), 265 + (j*18));
      }
    }
    */
}

cat[] MakeCatFamily(int sizeChr)
{
  cat[] arrCats = new cat[sizeChr];
  
  GenrChromosome catData = new GenrChromosome(this);
  
  String name;
  int age;
  float weight;
  for(int i = 0; i < sizeChr; i++)
  {
    name = new String(catData.CharChromosome(5));
    age = (int)random(9);
    weight = (float)random(7);
    arrCats[i] = new cat(name, age, weight);
  }
  
  return arrCats;
}

void title()
{
  fill(88, 0, 0);
  text("int (1, 10) Population", 14, 40);
  text("double (0, 1) Population", 14, 250);

  textSize(16);
  fill(10);
  text("Generate Swap Populations", 15, 15);
}