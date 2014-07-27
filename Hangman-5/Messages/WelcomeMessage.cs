namespace Hangman.Messages
{
    using System;
    using Interfaces;

    public class WelcomeMessage : IMessage
    {
        public string Content(params object[] messageParams)
        {
            return string.Format("Welcome to “Hangman” game. Please try to guess my secret word.{0}Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat and 'exit' to quit the game.", Environment.NewLine);
        }
    }
}
