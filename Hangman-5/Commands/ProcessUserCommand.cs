namespace Hangman.Commands
{
    using Interfaces;

    public class ProcessUserCommand : ICommand
    {
        private readonly IUserInputHandler handler;

        public ProcessUserCommand(IUserInputHandler handler)
        {
            this.handler = handler;
        }

        public void Execute()
        {
            this.handler.ProcessUserCommand();
        }
    }
}