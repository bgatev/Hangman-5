namespace HangmanGame
{
    using System;

    public class ExitMessage : IMessage
    {
        public string Content(params object[] messageParams)
        {
            return string.Format("Goodbye!");
        }
    }
}