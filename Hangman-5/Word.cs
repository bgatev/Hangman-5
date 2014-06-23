namespace HangmanGame
{
    using System.Text;
    using Extensions;   //Entensions Pattern
    
    public class Word
    {
        internal char[] Chars;

        public Word(string word = "")
        {
            this.Chars = word.ToCharArray();
        }

        public char this[int number]
        {
            get
            {
                return Chars[number];
            }

            set
            {
                Chars[number] = value;
            }
        }

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

        public override string ToString()
        {
            this.ThrowIfArgumentIsNull("Current word");

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.Chars.Length; i++)
            {
                sb.Append(this.Chars[i]);    
            }

            return sb.ToString();
        }
    }
}
