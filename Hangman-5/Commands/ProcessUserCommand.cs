using Hangman.Interfaces;

namespace HangmanGame.Commands
{
    using System;
    using Interfaces;

    public class ProcessUserCommand : ICommand
    {
        private IUserInputHandler handler;

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