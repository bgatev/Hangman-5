namespace HangmanGame.Commands
{
    using System;
    using Interfaces;

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