import laga.*;

GenrPopulation gPop; //initialize the population...
Mutation mut; //initialize the mutation.

//to store the populations.
float[][] fltPop;
float[][] fltMutatedPop;

Slider[] sliders;

//define, size and range population
int popSize = 5;
int chroLength = 10;
float fltMin = 0.00;
float fltMax = 5.00;
float nMin, nMax;

PFont font;

void setup() {
  size(600,400);
  
  gPop = new GenrPopulation(this);
  fltPop = gPop.NumbPopulation(popSize, chroLength, fltMin, fltMax);
  
  mut = new Mutation(this, 0.01);
  
  font = createFont("Ubuntu",12);
  textFont(font);
  textAlign(LEFT, CENTER);

sliders = new Slider[2];
//                      x,  y  , len,rad, remap min and max 
sliders[0] = new Slider(15, 300, 100, 10, 0.0, 1.00);
sliders[1] = new Slider(15, 350, 100, 10, 0.1, 7.00);
  
  frameRate(10);
}

void draw() {
  background(255);
  
  //slider part.
    sliders[0].update();
    sliders[0].display();
    sliders[1].update();
    sliders[1].display();
    
    nMin = -sliders[1].param;
    nMax = sliders[1].param;
 
  fltMutatedPop = mut.NumbMutation(fltPop, nMin, nMax, sliders[0].param);
  
  title();
  
    for (int i  = 0; i < popSize; i++)
  {
    for (int j = 0; j < chroLength; j++)
    {
      text(fltPop[i][j], 15 + (j * 50), 70 + (i*15));
      text(fltMutatedPop[i][j], 15 + (j * 50), 190 + (i*15));
    }
  }
}

void mouseReleased()
{
  sliders[0].releaseEvent();
  sliders[1].releaseEvent();
}

void title()
{
  fill(0, 0, 255);
  text("MUTATION", 15, 15);
  text("Float Population (0.0 < 1.0)", 15, 50);
  text("Mutated population", 15, 170);  
  text("change the mutation percent in the population", 15, 280);
  text("Number mutation range:    " + str(nMin) +",     " + str(nMax), 15, 330); 
}