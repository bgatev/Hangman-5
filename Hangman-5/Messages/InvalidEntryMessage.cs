namespace Hangman.Messages
{
    using Interfaces;

    public class InvalidEntryMessage : IMessage
    {
        public string Content(params object[] messageParams)
        {
            return string.Format("Incorrect guess or command!");
        }
    }
}