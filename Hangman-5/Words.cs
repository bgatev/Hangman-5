namespace HangmanGame
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Adapter pattern for Words
    /// </summary>
    public class Words : Word, IPrintable   //extends Word, without changing Word's Methods
    {
        private static readonly string[] WordsArray = new string[] { "computer", "programmer", "software", "debugger", "compiler", "developer", "algorithm", "array", "method", "variable" };
        
        public Words(string word) : base(word)
        {
        }

        public static string GetRandom()
        {
            Random randomGenerator = new Random();

            int randomIndex = randomGenerator.Next(0, WordsArray.Length);
            string randomWord = WordsArray[randomIndex];

            return randomWord;
        }

        public Words Empty(int wordLength)
        {
            for (int i = 0; i < wordLength; i++)
            {
                this[i] = '_';
            }

            return this;
        }

        public void Print()
        {
            Console.Write("The secret word is:");

            foreach (var letter in this.Chars)
            {
                Console.Write(" {0}", letter);
            }

            Console.WriteLine();
        }
    }
}
