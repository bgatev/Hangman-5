namespace HangmanGame.Commands
{
    using System;
    using Interfaces;

    public class PrintCurrentWordCommand : ICommand
    {
        private UserInputHandler handler;

        public PrintCurrentWordCommand(UserInputHandler handler)
        {
            this.handler = handler;
        }

        public void Execute()
        {
            this.handler.CurrentWord.Print();
        }
    }
}