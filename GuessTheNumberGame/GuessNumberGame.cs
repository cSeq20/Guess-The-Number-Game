using System;
using System.Globalization;

namespace GuessTheNumberGame
{
    public class GuessNumberGame
    {
        private const int DEFAULTRANDOMLIMIT = 20;
        private int _randomNumber;
        private int _customLimit;
        private bool _keepPlaying { get; set; }
        
        public GuessNumberGame()
        {
            _randomNumber = new Random().Next(DEFAULTRANDOMLIMIT);
            _keepPlaying = true;
            _customLimit = DEFAULTRANDOMLIMIT;
        }

        public void PlayGame()
        {
            var guessesCount = 0;
            InitializeGreeting();

            do
            {
                guessesCount++;
                Console.WriteLine("What's your guess?");
                string guess = Console.ReadLine();

                if (int.TryParse(guess, NumberStyles.Number, null, out var guessNum))
                {
                    Console.WriteLine(DetermineGuessResponse(guessNum, guessesCount));
                }
                else
                {
                    Console.WriteLine("Hmmm, that doesn't look like a number. Try again.");
                }
            }
            while (_keepPlaying);
        }

        private void InitializeGreeting()
        {
            Console.WriteLine("Let's Play 'Guess the Number'!");
            ChangeLimit();
            Console.WriteLine($"I'm thinking of a number between 0 and {_customLimit}.");
            Console.WriteLine("Enter your guess, or -1 to give up.");
        }

        private void ChangeLimit()
        {
            Console.WriteLine($"Would you like to change the range limit from {_customLimit}? Y/N");
            var answer = Console.ReadLine();

            do
            {
                if (answer.ToUpper() == "Y")
                {
                    Console.WriteLine("Enter a number to change the range limit");
                    string numLimitEntered = Console.ReadLine();
                    if (int.TryParse(numLimitEntered, NumberStyles.Number, null, out _customLimit))
                    {
                        _randomNumber = new Random().Next(_customLimit);
                    }
                    else
                    {
                        Console.WriteLine("Hmmm, that doesn't look like a number. Try again.");
                    }
                }
            }
            while (answer.ToUpper() != "Y" && answer.ToUpper() != "N");
        }

        private string DetermineGuessResponse(int guessNum, int guessCount)
        {
            _keepPlaying = guessNum == -1 || guessNum == _randomNumber ? false : true;
            var guessAgainText = $"Nope, {(guessNum > _randomNumber ? "lower" : "higher")} than that.";
            return guessNum == _randomNumber && guessNum != -1 ? $"You got it in {guessCount} guesses"
                        : !_keepPlaying ? $"Oh well I was thinking of {_randomNumber}"
                        : guessAgainText;
        }
    }
}