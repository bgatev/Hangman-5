namespace Hangman
{
    using System;
    using Commands;
    using Extensions;
    using Interfaces;

    /// <summary>
    ///     Concrete Implementation of the Game Class.
    /// </summary>
    public class HangmanRunner : Game
    {
        private Executor executor;
        private ICommand getInput;
        private IUserInputHandler handler;
        private ICommand printCurrentWord;
        private ICommand processCommand;
        private ICommand processInput;

        /// <summary>
        ///     Method, which loads the required object instances at the starting of the game.
        /// </summary>
        protected override void Initialize()
        {
            Console.WriteLine(MessageFactory.GetMessage("welcome".ToEnum<MessageType>()).Content());

            this.handler = new UserInputHandler(Words.GetRandom());
            this.executor = new Executor();

            this.printCurrentWord = new PrintCurrentWordCommand(this.handler);
            this.getInput = new GetUserInputCommand(this.handler);
            this.processInput = new ProcessUserGuessCommand(this.handler);
            this.processCommand = new ProcessUserCommand(this.handler);
        }

        /// <summary>
        ///     Defines the game update logic, which occurs after every user input.
        /// </summary>
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

        /// <summary>
        ///     Checks if the game is won and returns the proper responce.
        /// </summary>
        /// <returns></returns>
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