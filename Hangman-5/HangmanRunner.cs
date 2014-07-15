using System;
using Extensions;
using Hangman.Interfaces;
using HangmanGame;
using HangmanGame.Commands;
using HangmanGame.Interfaces;

namespace Hangman
{
    /// <summary>
    /// Concrete Implementation of the Game Class.
    /// </summary>
    public class HangmanRunner : Game
    {
        private Executor executor;
        private bool gameOver;
        private ICommand getInput;
        private IUserInputHandler handler;
        private ICommand printCurrentWord;
        private ICommand processCommand;
        private ICommand processInput;

        protected override void Initialize()
        {
            Console.WriteLine(MessageFactory.GetMessage("welcome".ToEnum<Messages>()).Content());

            this.handler = new UserInputHandler(Words.GetRandom());
            this.executor = new Executor();
            this.gameOver = false;

            this.printCurrentWord = new PrintCurrentWordCommand(this.handler);
            this.getInput = new GetUserInputCommand(this.handler);
            this.processInput = new ProcessUserGuessCommand(this.handler);
            this.processCommand = new ProcessUserCommand(this.handler);
        }

        protected override void Update()
        {
            this.executor.StoreAndExecute(this.printCurrentWord);
            this.executor.StoreAndExecute(this.getInput);

            if (this.handler.LastInput != string.Empty)
            {
                this.executor.StoreAndExecute(this.processInput);
            }
            else
            {
                this.executor.StoreAndExecute(this.processCommand);
            }
        }

        protected override bool IsWon()
        {
            if (this.handler.IsWon())
            {
                Console.WriteLine();
                return true;
            }

            return false;
        }
    }
}