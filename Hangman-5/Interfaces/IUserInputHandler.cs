using HangmanGame;

namespace Hangman.Interfaces
{
    public interface IUserInputHandler
    {
        bool EndOfAllGames { get; }
        bool EndOfCurrentGame { get;}
        string LastInput { get; }

        Words CurrentWord { get; }

        void GetUserInput();
        void ProcessUserGuess();
        void ProcessUserCommand();

        bool IsWon();
    }
}