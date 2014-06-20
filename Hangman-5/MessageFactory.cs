namespace HangmanGame
{
    using System;

    public static class MessageFactory
    {
        /// <summary>
        /// Factory method pattern for Messages
        /// </summary>
        public static IMessage GetMessage(int messageId)
        {
            switch (messageId)
            {
                case 0:
                    return new WelcomeMessage();
                case 1:
                    return new ExitMessage();
                case 2:
                    return new GetHelpMessage();
                case 3:
                    return new WinMessage();
                case 4:
                    return new CheatWinMessage();
                case 5:
                    return new OnSuccessLetterMessage();
                case 6:
                    return new OnRepeatedLetterMessage();
                case 7:
                    return new InvalidEntryMessage();
                case 8:
                    return new GetHelpMessage();
                default:
                    return null;
            }
        }
    }
}
