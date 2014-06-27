using Hangman.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman.Commands
{
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