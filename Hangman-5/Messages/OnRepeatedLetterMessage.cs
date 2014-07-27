namespace Hangman.Messages
{
    using Interfaces;

    public class OnRepeatedLetterMessage : IMessage
    {
        public string Content(params object[] messageParams)
        {
            return string.Format("Sorry! There are no unrevealed letters \"{0}\".", char.Parse(messageParams[0].ToString()));
        }
    }
}