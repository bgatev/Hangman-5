namespace Hangman.Commands
{
    using Interfaces;

    public class ProcessUserGuessCommand : ICommand
    {
        private readonly IUserInputHandler handler;

        public ProcessUserGuessCommand(IUserInputHandler handler)
        {
            this.handler = handler;
        }

        public void Execute()
        {
            this.handler.ProcessUserGuess();
        }
    }
}