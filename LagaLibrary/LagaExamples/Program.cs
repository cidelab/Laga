using System;

namespace LagaExamples
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Press Escape (Esc) to exit the loop.");

            while (true)
            {
                Console.Clear();
                ConsoleKeyInfo input = UI();
                    if (input.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Exiting...");
                        break;
                    }

                // Add a pause or prompt for continuation if desired
                Console.ReadKey(intercept: true);
            }
        }

        private static ConsoleKeyInfo UI()
        {
            Console.WriteLine("Select an example to run:\n");
            Console.WriteLine("1. Random value Examples");
            Console.WriteLine("2. Chromosome Examples");
            Console.WriteLine("3. Math Functions");
            Console.WriteLine("4. Population Examples");
            Console.Write("Enter your choice: ");

            ConsoleKeyInfo myKey = Console.ReadKey(true);
            switch (myKey.KeyChar)
            {
                case '1':
                    TestingRandom.Run();
                    break;
                case '2':
                    TestingChromosomes.Run();
                    break;
                case '3':
                    Testingfunctions.Run();
                    break;
                case '4':
                    TestingPopulation.Run();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            return myKey;
        }
    }
}
