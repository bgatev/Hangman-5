namespace HangmanGame
{
    using System;

    public interface IMessage
    {
        string Content(params object[] messageParams);
    }
}
