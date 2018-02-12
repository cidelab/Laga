class Cat
{
  float weight;
  int age;
  String name;
  
  Cat(String Name, int Age, float Weight)
  {
    name = Name;
    age = Age;
    weight = Weight;
  }

  public void Display(int x, int y)
  {
    text("name: " + name +", " + age + " age, " + weight + " kgs", x, y);
  }
}