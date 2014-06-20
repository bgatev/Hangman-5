namespace HangmanGame
{
    using System;

    public class CheatWinMessage : IMessage
    {
        public string Content(params object[] messageParams)
        {
            return string.Format("You won with {0} mistakes but you have cheated. " + "You are not allowed to enter into the scoreboard.", int.Parse(messageParams[0].ToString()));
        }
    }
}