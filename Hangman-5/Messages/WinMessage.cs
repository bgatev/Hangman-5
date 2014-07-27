namespace Hangman.Messages
{
    using Interfaces;

    public class WinMessage : IMessage
    {
        public string Content(params object[] messageParams)
        {
            return string.Format("You won with {0} mistakes.", int.Parse(messageParams[0].ToString()));
        }
    }
}