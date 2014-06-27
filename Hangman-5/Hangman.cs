namespace Hangman
{
    using System;
    using Extensions;
    using HangmanGame;

    public class Hangman
    {
        

        public static void ProcessUserGuess(string suggestedLetter, string secretWord, Words currentWord, ref int mistakes)
        {
            int revealedLetters = 0;
            bool isLetterRevealed = currentWord.IsLetterRevealed(suggestedLetter);

            if (!isLetterRevealed)
            {
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (suggestedLetter[0] == secretWord[i])
                    {
                        currentWord[i] = suggestedLetter[0];
                        revealedLetters++;
                    }
                }
            }

            if (revealedLetters > 0)
            {
                bool wordIsRevealed = currentWord.IsRevealed();

                if (!wordIsRevealed)
                {
                    Console.WriteLine(MessageFactory.GetMessage("onSuccessLetter".ToEnum<Messages>()).Content(revealedLetters));
                }
            }
            else
            {
                Console.WriteLine(MessageFactory.GetMessage("onRepeatedLetter".ToEnum<Messages>()).Content(suggestedLetter[0]));
                mistakes++;
            }
        }

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