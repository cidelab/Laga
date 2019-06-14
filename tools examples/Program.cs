using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laga.GeneticAlgorithm;
using Laga.IO;

namespace tools_examples
{
    class Program
    {
        static void Main(string[] args)
        {
            //making random data...
            List<List<string>> lstString = new List<List<string>>();
            int jagged;
            Random rnd = new Random(DateTime.Now.Day);
            for(int i = 0; i < 20; i++)
            {
                List<string> lstJagged = new List<string>();
                jagged = rnd.Next(10, 50);
                for(int j = 0; j < jagged; j++)
                    lstJagged.Add(LagaTools.RandomChar(50, 90).ToString());

                lstString.Add(lstJagged);
            }
            //stop making random data...

            IOExcelWrite iOExcelWrite = new IOExcelWrite(true);
            iOExcelWrite.IOWrite_NewExcelSheet(1, "testing");
            iOExcelWrite.IOWriteMatrix(lstString, 1, 1, true);
            iOExcelWrite.SaveCloseExcelApp(@"C:\Users\delab\Documents\test.xlsx");
            
            Console.ReadLine();
      
        }
    }
}
