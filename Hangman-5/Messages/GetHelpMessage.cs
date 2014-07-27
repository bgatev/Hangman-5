namespace Hangman.Messages
{
    using Interfaces;

    public class GetHelpMessage : IMessage
    {
        public string Content(params object[] messageParams)
        {
            return string.Format("OK, I reveal for you the next letter '{0}'.", char.Parse(messageParams[0].ToString()));
        }
    }
}