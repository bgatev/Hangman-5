namespace Hangman
{
    using System;
    using Extensions;
    using HangmanGame;

    public class Hangman
    {
        private static void Main()
        {
            bool gameOver = false;

            while (!gameOver)
            {
                Console.WriteLine(MessageFactory.GetMessage("welcome".ToEnum<Messages>()).Content());

                Game newGame = new Game();

                gameOver = newGame.Play();
                Console.WriteLine();
            }
        }
    }
}