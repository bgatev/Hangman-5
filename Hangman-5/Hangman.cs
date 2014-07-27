namespace Hangman
{
    public class Hangman
    {
        /// <summary>
        /// The program entry point
        /// </summary>
        private static void Main()
        {
            var newGame = new HangmanRunner();
            newGame.Play();
        }
    }
}