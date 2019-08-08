using System;
using ShakespeareGA.GAclasses;

namespace ShakespeareGA
{
    class Program
    {
        #region Main

        static void Main(string[] args)
        {
            Console.Title = "C# genetic algorithm demo";

            while (true)
            {
                //Display start prompt.
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\"C# genetic algorithm demo\" is ready. Please press enter to start...");
                Console.ReadLine();

                //Display output heading.
                Console.WriteLine(
                    "Generation | " + 
                    ("Best phrase").PadRight(18, ' ') + " | " + 
                    "Accuracy");
                Console.WriteLine(
                    ("-").PadRight(11, '-') + "+" +
                    ("-").PadRight(20, '-') + "+" +
                    ("-").PadRight(10, '-'));

                //GeneticAlgorithm initialization and evolution.
                string targetPhrase = "To be or not to be";
                int populationSize = 500;
                Random random = new Random();

                GeneticAlgorithm ShakespeareGA = 
                    new GeneticAlgorithm(populationSize, targetPhrase, random);

                while (ShakespeareGA.BestIndividual.WrittenPhrase != targetPhrase)
                {
                    ShakespeareGA.EvolvePopulation();
                    UpdateDisplay(ShakespeareGA, targetPhrase.Length);
                }

                //Display exit prompt.
                Console.WriteLine("\nExit?[Y/N]");

                if (Console.ReadLine().ToLower() == "y")
                    break;
            }
        }

        #endregion

        #region Functions

        //Updates the console with information about the state of the given GeneticAlgorithm.
        static void UpdateDisplay(GeneticAlgorithm shakespeareGA, int maxFitness)
        {
            float generationAccuracy = 
                ((float)shakespeareGA.BestIndividual.Fitness / maxFitness) * 100;

            if (generationAccuracy >= 0 && generationAccuracy <= 40)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (generationAccuracy >= 40 && generationAccuracy <= 70)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else if (generationAccuracy >= 70 && generationAccuracy <= 99)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(
                " " + shakespeareGA.Generation.ToString().PadRight(9, '.') + " | " +
                shakespeareGA.BestIndividual.WrittenPhrase + " | " +
                generationAccuracy.ToString() + "%");

            Console.ForegroundColor = ConsoleColor.White;
        }

        #endregion
    }
}