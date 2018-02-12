import laga.*;

GenrPopulation gPop; //initialize the population...
Crossover cs;

//to store the populations.
char[][] intPop;
char[][] intCrossoverPop;

//define, size and range population
int popSize = 6;
int chroLength = 10;

PFont f;

//sliders to Control the parameters...
Slider slyPercent;
intSlider slyCut;

void setup() {
  size(600,400);

  gPop = new GenrPopulation(this);
  intPop = gPop.CharPopulation(popSize, chroLength);

  f = createFont("Ubuntu",12);
  textFont(f);
  textAlign(LEFT, CENTER);
  
  slyPercent = new Slider(15, 300, 100, 10, 0.0, 1.00);
  slyCut = new intSlider(15, 350, 100, 10, 1, chroLength);
  
  cs = new Crossover(this);
  
  frameRate(10);
}

void draw() {
  background(255);
  
  slyPercent.update();
  slyPercent.display();
  slyCut.update();
  slyCut.display();
  
  intCrossoverPop = cs.SinglePointCrossover(intPop, slyPercent.param, slyCut.param);

    title();
    for (int i  = 0; i < popSize; i++)
  {
    for (int j = 0; j < chroLength; j++)
    {
      text(intPop[i][j], 15 + (j * 50), 70 + (i*15));
    }
  }
  
      for (int i  = 0; i < intCrossoverPop.length; i++)
  {
    for (int j = 0; j < chroLength; j++)
    {
      text(intCrossoverPop[i][j], 15 + (j * 50), 190 + (i*15));
    }
  }

}

void mouseReleased(){
slyPercent.releaseEvent();
slyCut.releaseEvent();
}

void title()
{
  fill(0, 0, 255);
  text("CROSSOVER", 15, 15);
  text("int Population", 15, 50);
  text("Crossover population", 15, 170);  
  text("change the crossover percent in the population", 15, 280);
  text("change the point crossover location", 15, 330); 
}