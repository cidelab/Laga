class cat
{
  float weight;
  int age;
  String name;
  
  cat(String Name, int Age, float Weight)
  {
    name = Name;
    age = Age;
    weight = Weight;
  }

  public void Display(int x, int y)
  {
    text("n:" + name +",a:" + age + ",kg:" + weight, x, y);
  }

}