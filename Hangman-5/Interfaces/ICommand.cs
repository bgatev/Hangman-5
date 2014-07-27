namespace Hangman.Interfaces
{
    /// <summary>
    /// The Command Pattern interface. Obligates the commands classes to define Execute method.
    /// </summary>
    public interface ICommand
    {
        void Execute();
    }
}