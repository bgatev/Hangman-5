namespace HangmanGame
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Executor
    {
        private readonly IList<ICommand> commands;

        public Executor()
        {
            this.commands = new List<ICommand>();
        }

        public void StoreAndExecute(ICommand command)
        {
            this.commands.Add(command);
            command.Execute();
        }
    }
}