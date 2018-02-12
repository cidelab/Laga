class intSlider
{

  int x, y;
  int boxy;
  int stretch;
  int locX;
  int size;
  boolean over;
  boolean press;
  boolean locked = false;
  boolean otherslocked = false;
  int min, max;
  public int param;
  Slider[] others;

  intSlider(int ix, int iy, int leng, int rad, int minMap, int maxMap) 
  {
    x = ix;
    y = iy;
    size = rad;
    min = minMap;
    max = maxMap;
    stretch = leng;
    locX = stretch + x;
    boxy = y - size/2;
    param = Remap(locX, x, x+(stretch*2), min, max);
  }

  void update() 
  {
    boxy = y - size/2;
    if(locked == false)
    {
       overEvent();
      pressEvent();
    }
    
      if (press) {
      locX = mouseX;
      if(mouseX <= x) 
    {
      mouseX = x;
    }
      if(mouseX >= x + stretch*2) 
    {
    mouseX = (x + stretch*2);
    }
      param = Remap(locX, x, x+(stretch*2), min, max);
    }
  }
  
    void pressEvent() {
    if (over && mousePressed || locked) {
      press = true;
      locked = true;
    } else {
      press = false;
    }
  }
  
  void overEvent() {
    if (overRect(locX, boxy, size, size)) {
      over = true;
    } else {
      over = false;
    }
  }
  
  boolean overRect(int x, int y, int width, int height) {
  if (mouseX >= x && mouseX <= x+width && 
      mouseY >= y && mouseY <= y+height) {
    return true;
  } else {
    return false;
  }
}

  int Remap(int xPos, int a1, int a2, int b1, int b2)
  {
    return b1 + (xPos - a1)*(b2-b1)/ (a2-a1);
  }
    

  void releaseEvent() {
    locked = false;
    
  }

  void display() {
    line(x, y, x + (stretch*2), y);
    fill(255);
    stroke(0);

    if (over || press) 
    {
      fill(#21A5EA);
    }
    ellipse(locX, boxy+(size*0.5), size, size);
    
    fill(60);
    text(param, locX, boxy+size*(1.5));
  }
}