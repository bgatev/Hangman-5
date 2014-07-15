using Hangman;

namespace HangmanGame
{
    public class Hangman
    {
        private static void Main()
        {
            var newGame = new HangmanRunner();
            newGame.Play();
        }
    }
}