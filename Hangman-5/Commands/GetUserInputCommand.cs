namespace Hangman.Commands
{
    using Interfaces;

    public class GetUserInputCommand : ICommand
    {
        private readonly IUserInputHandler handler;

        public GetUserInputCommand(IUserInputHandler handler)
        {
            this.handler = handler;
        }

        public void Execute()
        {
            this.handler.GetUserInput();
        }
    }
}