namespace HangmanGame.Commands
{
    using System;
    using Interfaces;

    public class ProcessUserCommand : ICommand
    {
        private UserInputHandler handler;

        public ProcessUserCommand(UserInputHandler handler)
        {
            this.handler = handler;
        }

        public void Execute()
        {
            this.handler.ProcessUserCommand();
        }
    }
}