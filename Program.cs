using System;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MasterMind!");
            Console.WriteLine("Please enter a guess consisting of 4 digits, each between 1 and 6 (eg. 2, 3, 4, 5).");

            Game game = new Game();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter Guess #" + (i+1) + ": ");
                string guess = Console.ReadLine();

                string message = game.CheckAnswer(guess);
                Console.WriteLine(message);

                if (message.ToLower().Contains("success"))
                   break;

                if (i == 9)
                    Console.WriteLine("Sorry, after 10 tries, you have lost.");
            }
        }
    }
}
