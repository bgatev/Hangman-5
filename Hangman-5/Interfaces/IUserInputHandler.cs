namespace Hangman.Interfaces
{
    /// <summary>
    ///     Defines the required methods for a User input handler class.
    /// </summary>
    public interface IUserInputHandler
    {
        string LastInput { get; }

        Words CurrentWord { get; }

        void GetUserInput();

        void ProcessUserGuess();

        void ProcessUserCommand();

        bool IsWon();
    }
}