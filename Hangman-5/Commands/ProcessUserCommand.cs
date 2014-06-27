using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hangman.Interfaces;

namespace Hangman.Commands
{
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