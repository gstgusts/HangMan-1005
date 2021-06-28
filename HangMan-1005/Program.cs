using HangmanData;
using System;

namespace HangMan_1005
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            while(true)
            {
                Console.WriteLine($"What is the capital of {game.Country}?");

                Console.WriteLine("---------------------------------------");
                Console.WriteLine(game.CurrentWord);
                Console.WriteLine("---------------------------------------");

                foreach (var letter in game.UsedLetters)
                {
                    Console.Write(letter + ";");
                }

                Console.WriteLine();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Retry count = {game.TryCount}");
                Console.WriteLine("---------------------------------------");

                Console.Write("Please enter a letter: ");
                var userInput = Console.ReadLine();

                var result = game.Guess(userInput[0]);

                switch (result)
                {
                    case GuessResultEnum.AlreadyUsed:
                    case GuessResultEnum.Guessed:
                    case GuessResultEnum.Incorrect:
                        break;
                    case GuessResultEnum.Won:
                        Console.WriteLine($"You guest {game.CurrentWord}");
                        game.Restart();
                        break;
                    case GuessResultEnum.GameOver:
                        Console.WriteLine("Game over");
                        game.Restart();
                        break;
                }
            }
        }
    }
}
