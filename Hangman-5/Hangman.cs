namespace HangmanGame
{
    using System;

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
                        Messages.PrintInvalidEntry();
                    }
                }
                else if (inputLine.Length == 0)
                {
                    Messages.PrintInvalidEntry();
                }
                else if ((inputLine == "top") || (inputLine == "restart") || (inputLine == "help") || (inputLine == "exit"))
                {
                    command = inputLine;
                    break;
                }
                else
                {
                    Messages.PrintInvalidEntry();
                }
            }

            return suggestedLetter;
        }

        public static void ProcessUserGuess(string suggestedLetter, string secretWord, char[] currentWord, ref int mistakes)
        {
            int revealedLetters = 0;
            bool isLetterRevealed = Words.IsLetterRevealed(suggestedLetter, currentWord);

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
                bool wordIsRevealed = Words.IsRevealed(currentWord);

                if (!wordIsRevealed)
                {
                    Messages.PrintOnSuccessLetter(revealedLetters);
                }
            }
            else
            {
                Messages.PrintOnRepeatedLetter(suggestedLetter[0]);
                mistakes++;
            }
        }

        private static void Main()
        {
            bool gameOver = false;

            while (!gameOver)
            {
                Messages.PrintWelcome();

                gameOver = Game.Play();
                Console.WriteLine();
            }
        }
    }
}