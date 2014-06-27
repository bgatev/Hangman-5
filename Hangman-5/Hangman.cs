namespace Hangman
{
    using System;
    using Extensions;
    using HangmanGame;

    public class Hangman
    {
        public static string GetUserInput(out string command)
        {
            string suggestedLetter = string.Empty;
            command = string.Empty;

            while (true)
            {
                Console.Write("Enter your guess or command: ");
                string inputLine = Console.ReadLine().ToLower();
  
                if (inputLine.Length == 1)
                {
                    bool isLetter = char.IsLetter(inputLine, 0);

                    if (isLetter)
                    {
                        suggestedLetter = inputLine;
                        break;
                    }
                    else
                    {
                        Console.WriteLine(MessageFactory.GetMessage("invalidEntry".ToEnum<Messages>()).Content());
                    }
                }
                else if (inputLine.Length == 0)
                {
                    Console.WriteLine(MessageFactory.GetMessage("invalidEntry".ToEnum<Messages>()).Content());
                }
                else if ((inputLine == "top") || (inputLine == "restart") || (inputLine == "help") || (inputLine == "exit"))
                {
                    command = inputLine;
                    break;
                }
                else
                {
                    Console.WriteLine(MessageFactory.GetMessage("invalidEntry".ToEnum<Messages>()).Content());
                }
            }

            return suggestedLetter;
        }

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