namespace Hangman
{
    using System;
    using Interfaces;

    /// <summary>
    /// Adapter pattern for Words
    /// </summary>
    public class Words : Word, IPrintable   // extends Word, without changing Word's Methods
    {
        private static readonly string[] WordsArray = new string[] { "computer", "programmer", "software", "debugger", "compiler", "developer", "algorithm", "array", "method", "variable" };
        
        public Words(string word) : base(word)
        {
        }

        /// <summary>
        /// Selects randomly the secret word for the current game among the predefined secret words array.
        /// </summary>
        /// <returns></returns>
        public static string GetRandom()
        {
            Random randomGenerator = new Random();

            int randomIndex = randomGenerator.Next(0, WordsArray.Length);
            string randomWord = WordsArray[randomIndex];

            return randomWord;
        }

        /// <summary>
        /// Replaces the word's letters with underscores and thus making the word "secret".
        /// </summary>
        /// <param name="wordLength"></param>
        /// <returns></returns>
        public Words Empty(int wordLength)
        {
            for (int i = 0; i < wordLength; i++)
            {
                this[i] = '_';
            }

            return this;
        }

        /// <summary>
        /// Prints the secret word.
        /// </summary>
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
