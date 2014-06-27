using System;
using System.Linq;
using Extensions;
using HangmanGame;

namespace Hangman
{
    public class UserInputHandler
    {
        public string LastCommand { get; set; }

        public string LastInput { get; set; }

        public void GetUserInput()
        {
            string suggestedLetter = string.Empty;
            this.LastCommand = string.Empty;

            while (true)
            {
                Console.Write("Enter your guess or command: ");
                string inputLine = Console.ReadLine().ToLower();

                if (inputLine.Length == 1)
                {
                    bool isLetter = char.IsLetter(inputLine, 0);

                    if (isLetter)
                    {
                        suggestedLetter = inputLine;
                        break;
                    }
                    else
                    {
                        Console.WriteLine(MessageFactory.GetMessage("invalidEntry".ToEnum<Messages>()).Content());
                    }
                }
                else if (inputLine.Length == 0)
                {
                    Console.WriteLine(MessageFactory.GetMessage("invalidEntry".ToEnum<Messages>()).Content());
                }
                else if ((inputLine == "top") || (inputLine == "restart") || (inputLine == "help") || (inputLine == "exit"))
                {
                    this.LastCommand = inputLine;
                    break;
                }
                else
                {
                    Console.WriteLine(MessageFactory.GetMessage("invalidEntry".ToEnum<Messages>()).Content());
                }
            }

            this.LastInput = suggestedLetter;
        }
    }
}
