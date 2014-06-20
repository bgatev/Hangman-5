﻿namespace HangmanGame
{
    using System;

    public class InvalidEntryMessage : IMessage
    {
        public string Content(params object[] messageParams)
        {
            return string.Format("Incorrect guess or command!");
        }
    }
}