namespace Hangman
{
    using Interfaces;
    using Messages;

    public static class MessageFactory
    {
        /// <summary>
        ///     Factory method pattern for Messages
        /// </summary>
        public static IMessage GetMessage(MessageType messageId)
        {
            switch (messageId)
            {
                case MessageType.welcome:
                    return new WelcomeMessage();
                case MessageType.exit:
                    return new ExitMessage();
                case MessageType.getHelp:
                    return new GetHelpMessage();
                case MessageType.win:
                    return new WinMessage();
                case MessageType.cheatWin:
                    return new CheatWinMessage();
                case MessageType.onSuccessLetter:
                    return new OnSuccessLetterMessage();
                case MessageType.onRepeatedLetter:
                    return new OnRepeatedLetterMessage();
                case MessageType.invalidEntry:
                    return new InvalidEntryMessage();
                default:
                    return null;
            }
        }
    }
}