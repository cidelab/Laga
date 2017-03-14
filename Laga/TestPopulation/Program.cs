using System;
using System.Collections.Generic;
using System.Text;
using Laga;

namespace TestPopulation
{
    class Program
    {
        static void Main(string[] args)
        {
            //we are using chromosome data to initialize our cat population...
            GenrChromosome chrCatadata = new GenrChromosome(10);
            int[] arrAges = chrCatadata.NumberChromosome(1, 11);
            double[] arrWeights = chrCatadata.NumberChromosome(0.10, 5.00);

            cat[] ChromosomeCat = new cat[10]; // To store the cats...

            GenrChromosome chrCatNames = new GenrChromosome(5); //we wont a 5 char cats names...
            Char[] arrText;

            for(int i = 0; i < 10; i++)
            {
                cat myCat = new cat();
                arrText = chrCatNames.CharChromosome(97, 122);

                myCat.Name = new string(arrText); // name of the cat...
                myCat.Year = arrAges[i];
                myCat.Weight = arrWeights[i];

                ChromosomeCat[i] = myCat;
            }

            GenrPopulation pop = new GenrPopulation(10);
            object[][] CatPopulation = pop.ObjectPopulationSwap(ChromosomeCat, 0.5f, true);

            pop.SizePop = 7;
            int[][] IntPopulation = pop.NumPopulationSwap(12, 17);

            int increment = 0;
            int count;
            foreach(object[] catChromosome  in CatPopulation)
            {
                Console.WriteLine("In Chromosome {0}", increment);
                count = 0;
                foreach (object objCat in catChromosome)
                {
                    cat theCat = (cat)objCat;
                    Console.WriteLine("pos:{0} -> cat Name :{1} - cat Weight :{2} - cat Years :{3}", count, theCat.Name, Math.Round(theCat.Weight, 2), theCat.Year);
                    count++;
                }
                increment++;
                //
            }

            Console.ReadKey();
            
        }
    }
}
