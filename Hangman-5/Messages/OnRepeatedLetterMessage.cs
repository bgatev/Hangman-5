namespace HangmanGame
{
    using System;

    public class OnRepeatedLetterMessage : IMessage
    {
        public string Content(params object[] messageParams)
        {
            return string.Format("Sorry! There are no unrevealed letters \"{0}\".", char.Parse(messageParams[0].ToString()));
        }
    }
}