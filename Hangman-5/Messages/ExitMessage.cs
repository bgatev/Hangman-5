namespace Hangman.Messages
{
    using Interfaces;

    public class ExitMessage : IMessage
    {
        public string Content(params object[] messageParams)
        {
            return string.Format("Goodbye!");
        }
    }
}