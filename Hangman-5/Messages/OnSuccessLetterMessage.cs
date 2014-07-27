namespace Hangman.Messages
{
    using Interfaces;

    public class OnSuccessLetterMessage : IMessage
    {
        public string Content(params object[] messageParams)
        {
            if (int.Parse(messageParams[0].ToString()) == 1)
            {
                return string.Format("Good job! You revealed {0} letter.", int.Parse(messageParams[0].ToString()));
            }
            else
            {
                return string.Format("Good job! You revealed {0} letters.", int.Parse(messageParams[0].ToString()));
            }
        }
    }
}