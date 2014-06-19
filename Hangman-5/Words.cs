namespace HangmanGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Words
    {
        private static readonly string[] WordsArray = new string[] { "computer", "programmer", "software", "debugger", "compiler", "developer", "algorithm", "array", "method", "variable" };

        public Words()
        {
        }

        public static string SelectRandom()
        {
            Random randomGenerator = new Random();

            int randomIndex = randomGenerator.Next(0, WordsArray.Length);
            string randomWord = WordsArray[randomIndex];

            return randomWord;
        }

        public static char[] EmptyWord(int wordLength)
        {
            char[] emptyWord = new char[wordLength];

            for (int i = 0; i < wordLength; i++)
            {
                emptyWord[i] = '_';
            }

            return emptyWord;
        }

        public static bool IsLetterRevealed(string suggestedLetter, char[] currentWord)
        {
            for (int i = 0; i < currentWord.Length; i++)
            {
                if (currentWord[i] == suggestedLetter[0])
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsRevealed(char[] currentWord)
        {
            for (int index = 0; index < currentWord.Length; index++)
            {
                if (currentWord[index] == '_')
                {
                    return false;
                }
            }

            return true;
        }

        public static char GetHelp(string secretWord, char[] currentWord)
        {
            char revealedLetter = secretWord[0];

            for (int i = 0; i < currentWord.Length; i++)
            {
                if (currentWord[i] == '_')
                {
                    revealedLetter = secretWord[i];
                    break;
                }
            }

            for (int i = 0; i < secretWord.Length; i++)
            {
                if (revealedLetter == secretWord[i])
                {
                    currentWord[i] = revealedLetter;
                }
            }

            return revealedLetter;
        }

        public static void Print(char[] currentWord)
        {
            Console.Write("The secret word is:");

            foreach (var letter in currentWord)
            {
                Console.Write(" {0}", letter);
            }

            Console.WriteLine();
        }
    }
}
