using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hangman.Interfaces;
using HangmanGame;

namespace Hangman.Commands
{
    public class PrintCurrentWordCommand:ICommand
    {
        private Words word;

        public PrintCurrentWordCommand(Words word)
        {
            this.word = word;
        }
        public void Execute()
        {
            this.word.Print();
        }
    }
}
