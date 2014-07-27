namespace Hangman
{
    using System.Text;
    using Extensions;

    // Extensions Pattern

    /// <summary>
    ///     This class takes a word and keeps it's characters array. Also provides useful methods over that array.
    /// </summary>
    public class Word
    {
        internal readonly char[] Chars;

        public Word(string word = "")
        {
            this.Chars = word.ToCharArray();
        }

        public char this[int number]
        {
            get { return this.Chars[number]; }

            set { this.Chars[number] = value; }
        }

        /// <summary>
        ///     Checks if the user's suggested letter is contained within the secret word.
        /// </summary>
        /// <param name="suggestedLetter"> the letter that the user suggested</param>
        /// <returns></returns>
        public bool IsLetterRevealed(string suggestedLetter)
        {
            this.ThrowIfArgumentIsNull("IsLetterRevealed Current word");

            for (int i = 0; i < this.ToString().Length; i++)
            {
                if (this[i] == suggestedLetter[0])
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Checks if the secret word is fully revealed.
        /// </summary>
        /// <returns></returns>
        public bool IsRevealed()
        {
            this.ThrowIfArgumentIsNull("IsRevealed Current word");

            for (int i = 0; i < this.ToString().Length; i++)
            {
                if (this[i] == '_')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Gets the first unrevealed letter and reveals all such letters in the secret word.
        /// </summary>
        /// <param name="secretWord">the secret word</param>
        /// <returns></returns>
        public char GetHelp(string secretWord)
        {
            char revealedLetter = secretWord[0];

            for (int i = 0; i < this.ToString().Length; i++)
            {
                if (this[i] == '_')
                {
                    revealedLetter = secretWord[i];
                    break;
                }
            }

            for (int i = 0; i < secretWord.Length; i++)
            {
                if (revealedLetter == secretWord[i])
                {
                    this[i] = revealedLetter;
                }
            }

            return revealedLetter;
        }

        /// <summary>
        ///     Reconstructs the whole secret word from it's char array.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            this.ThrowIfArgumentIsNull("Current word");

            var sb = new StringBuilder();

            for (int i = 0; i < this.Chars.Length; i++)
            {
                sb.Append(this.Chars[i]);
            }

            return sb.ToString();
        }
    }
}