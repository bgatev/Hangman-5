using Hangman.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman.Commands
{
    public class GetUserInputCommand : ICommand
    {
        private readonly UserInputHandler handler;

        public GetUserInputCommand(UserInputHandler handler)
        {
            this.handler = handler;
        }

        public void Execute()
        {
            this.handler.GetUserInput();
        }
    }
}