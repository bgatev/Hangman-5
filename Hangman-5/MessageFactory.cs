namespace HangmanGame
{
    using System;

    public static class MessageFactory
    {
        /// <summary>
        /// Factory method pattern for Messages
        /// </summary>
        public static IMessage GetMessage(Messages messageId)
        {
            switch (messageId)
            {
                case Messages.welcome:
                    return new WelcomeMessage();
                case Messages.exit:
                    return new ExitMessage();
                case Messages.getHelp:
                    return new GetHelpMessage();
                case Messages.win:
                    return new WinMessage();
                case Messages.cheatWin:
                    return new CheatWinMessage();
                case Messages.onSuccessLetter:
                    return new OnSuccessLetterMessage();
                case Messages.onRepeatedLetter:
                    return new OnRepeatedLetterMessage();
                case Messages.invalidEntry:
                    return new InvalidEntryMessage();
                default:
                    return null;
            }
        }
    }
}
