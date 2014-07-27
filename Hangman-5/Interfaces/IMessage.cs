namespace Hangman.Interfaces
{
    public interface IMessage
    {
        string Content(params object[] messageParams);
    }
}
