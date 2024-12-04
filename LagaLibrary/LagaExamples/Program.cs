namespace LagaExamples
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select an example to run:\n");
            Console.WriteLine("1. Random value Examples");
            Console.WriteLine("2. Chromosome Examples");
            Console.WriteLine("3. Combinatorial Problem");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TestingRandom.Run();
                    break;
                case "2":
                    TestingChromosomes.Run();
                    break;
                case "3":
                    CombineProblem.Run();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
