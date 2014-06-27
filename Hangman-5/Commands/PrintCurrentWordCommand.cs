using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hangman.Interfaces;
using HangmanGame;

namespace Hangman.Commands
{
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