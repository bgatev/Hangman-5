namespace Hangman.Commands
{
    using Interfaces;

    public class PrintCurrentWordCommand : ICommand
    {
        private readonly IUserInputHandler handler;

        public PrintCurrentWordCommand(IUserInputHandler handler)
        {
            this.handler = handler;
        }

        public void Execute()
        {
            this.handler.CurrentWord.Print();
        }
    }
}