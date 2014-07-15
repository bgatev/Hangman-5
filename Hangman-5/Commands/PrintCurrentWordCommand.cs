using Hangman.Interfaces;

namespace HangmanGame.Commands
{
    using System;
    using Interfaces;

    public class PrintCurrentWordCommand : ICommand
    {
        private IUserInputHandler handler;

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