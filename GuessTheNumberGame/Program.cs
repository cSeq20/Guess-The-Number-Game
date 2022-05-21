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
            var numberGame = new GuessNumberGame();
            numberGame.PlayGame();
        }
    }
}
