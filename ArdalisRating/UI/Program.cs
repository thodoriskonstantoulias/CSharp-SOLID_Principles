using System;

namespace ArdalisRating
{
    //We will apply SOLID principles in this project
    //Check initial commit for the code in the start so to be able to follow changes 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ardalis Insurance Rating System Starting...");
            //var logger = new ConsoleLogger();

            //So easy to change services with dependency inversion 
            var logger = new FileLogger();
            var engine = new RatingEngine(new ConsoleLogger(),new FilePolicySource(),new JsonPolicySerializer(), new RaterFactory(logger));
            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }

        }
    }
}
