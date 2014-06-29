namespace HangmanGame.Commands
{
    using System;
    using Interfaces;

    public class ProcessUserGuessCommand : ICommand
    {
        private UserInputHandler handler;

        public ProcessUserGuessCommand(UserInputHandler handler)
        {
            this.handler = handler;
        }

        public void Execute()
        {
            this.handler.ProcessUserGuess();
        }
    }
}