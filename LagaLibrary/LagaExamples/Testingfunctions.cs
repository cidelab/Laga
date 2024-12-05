﻿using Laga.GeneticAlgorithm;
using Laga.Geometry;
using Laga.Numbers;

namespace LagaExamples
{
    public class Testingfunctions
    {

        public static void Run()
        {
            Console.WriteLine("\n /// - Examples of Laga.Numbers.Functions() - /// \n");

            Console.WriteLine("Three X plus one function (pay attention to the sequence):");
            List<int> lstdata = Function.ThreeXplusOne(100);
            Console.WriteLine(string.Join(", ", lstdata) + "\n");

            Console.WriteLine("Example of Sigmoid function:");
            float[] fltSequence = [0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f];
            
            float[] arrSigmoid = new float[fltSequence.Length];
            for(int i = 0; i < fltSequence.Length; i++)
                arrSigmoid[i] = Function.Sigmoid(fltSequence[i]);

            Console.WriteLine("Sequence: " + string.Join(", ", fltSequence));
            Console.WriteLine("Sigmoid: " + string.Join(", ", arrSigmoid) + "\n");

            Console.WriteLine("\n /// - Press any key to return to the menu - /// ");
        }
    }
}
