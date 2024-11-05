namespace LagaExamples
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select an example to run:");
            Console.WriteLine("1. Basic Example 1");
            Console.WriteLine("2. Advanced Example 2");
            Console.WriteLine("3. Rhino Example 3");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TestingRandom.Run();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
