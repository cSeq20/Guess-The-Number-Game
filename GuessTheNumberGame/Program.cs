using System;
using System.Globalization;

namespace GuessTheNumberGame
{
    /// <summary>
    /// Small console app to play a guess the number game
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Choose a random number between 0 and 20
            var theNumber = new Random().Next(20);                       
            var keepPlaying = true;

            // Print the game greeting and instructions
            Console.WriteLine("Let's Play 'Guess the Number'!");
            Console.WriteLine("I'm thinking of a number between 0 and 20.");
            Console.WriteLine("Enter your guess, or -1 to give up.");

            // Keep track of the number of guesses and the current user guess
            var guessesCount = 0;
            int guessNum;

            // play the game atleast once
            do
            {
                guessesCount++;
                Console.WriteLine("What's your guess?");
                string guess = Console.ReadLine();
                
                if (int.TryParse(guess, NumberStyles.Number, null, out guessNum))
                {
                    keepPlaying = guessNum == -1 || guessNum == theNumber ? false : true;
                    var guessAgainText = "Nope, " + (guessNum > theNumber ? "lower " : "higher ") + "than that.";
                    var outputText = guessNum == theNumber && guessNum != -1 ? $"You got it in {guessesCount} guesses"                        
                        : !keepPlaying ? $"Oh well I was thinking of {theNumber}"
                        : guessAgainText;
                   
                    Console.WriteLine(outputText);
                }
                else
                {
                    Console.WriteLine("Hmmm, that doesn't look like a number. Try again.");
                }
            }
            while (keepPlaying);
        }
    }
}
