using Hangman.Interfaces;

namespace HangmanGame.Commands
{
    using System;
    using Interfaces;

    public class ProcessUserGuessCommand : ICommand
    {
        private IUserInputHandler handler;

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