using Hangman.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman.Commands
{
    public class GetUserInputCommand:ICommand
    {
        private UserInputHandler userInput;

        public GetUserInputCommand(UserInputHandler userInput)
        {
            this.userInput = userInput;
        }

        public void Execute()
        {
            this.userInput.GetUserInput();
        }
    }
}
