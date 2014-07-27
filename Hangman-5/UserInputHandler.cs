namespace Hangman
{
    using System;
    using Extensions;
    using Interfaces;

    /// <summary>
    ///     Handler class which manages the user input and is used by the game commands
    /// </summary>
    public class UserInputHandler : IUserInputHandler
    {
        private readonly string wordToGuess;

        private bool helpIsUsed;
        private string lastCommand;
        private int mistakes;

        /// <summary>
        /// </summary>
        /// <param name="wordToGuess">the word that the user must guess</param>
        public UserInputHandler(string wordToGuess)
        {
            this.wordToGuess = wordToGuess;
            this.CurrentWord = new Words(this.wordToGuess);
            this.mistakes = 0;
            this.CurrentWord.Empty(this.wordToGuess.Length);
        }

        public string LastInput { get; private set; }

        public Words CurrentWord { get; private set; }

        /// <summary>
        ///     Gets the user guess or command from the console and sets the internal class fields to  the appropriate values.
        /// </summary>
        public void GetUserInput()
        {
            string suggestedLetter = string.Empty;
            this.lastCommand = string.Empty;

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

                    Console.WriteLine(MessageFactory.GetMessage("invalidEntry".ToEnum<MessageType>()).Content());
                }
                else if (inputLine.Length == 0)
                {
                    Console.WriteLine(MessageFactory.GetMessage("invalidEntry".ToEnum<MessageType>()).Content());
                }
                else if ((inputLine == "top") || (inputLine == "restart") || (inputLine == "help") ||
                         (inputLine == "exit"))
                {
                    this.lastCommand = inputLine;
                    break;
                }
                else
                {
                    Console.WriteLine(MessageFactory.GetMessage("invalidEntry".ToEnum<MessageType>()).Content());
                }
            }

            this.LastInput = suggestedLetter;
        }

        /// <summary>
        ///     Handles the user guess command.
        /// </summary>
        public void ProcessUserGuess()
        {
            int revealedLetters = 0;
            bool isLetterRevealed = this.CurrentWord.IsLetterRevealed(this.LastInput);

            if (!isLetterRevealed)
            {
                for (int i = 0; i < this.wordToGuess.Length; i++)
                {
                    if (this.LastInput[0] == this.wordToGuess[i])
                    {
                        this.CurrentWord[i] = this.LastInput[0];
                        revealedLetters++;
                    }
                }
            }

            if (revealedLetters > 0)
            {
                bool wordIsRevealed = this.CurrentWord.IsRevealed();

                if (!wordIsRevealed)
                {
                    Console.WriteLine(
                                      MessageFactory.GetMessage("onSuccessLetter".ToEnum<MessageType>())
                                                    .Content(revealedLetters));
                }
            }
            else
            {
                Console.WriteLine(
                                  MessageFactory.GetMessage("onRepeatedLetter".ToEnum<MessageType>())
                                                .Content(this.LastInput[0]));
                this.mistakes++;
            }
        }

        /// <summary>
        ///     Handles the user game command.
        /// </summary>
        public void ProcessUserCommand()
        {
            this.helpIsUsed = false;

            switch (this.lastCommand)
            {
                case "top":
                    Scoreboard.Print();
                    break;
                case "restart":
                    break;
                case "exit":
                    Console.WriteLine(MessageFactory.GetMessage("exit".ToEnum<MessageType>()).Content());
                    break;
                case "help":
                    char revealedLetter = this.CurrentWord.GetHelp(this.wordToGuess);
                    Console.WriteLine(MessageFactory.GetMessage("getHelp".ToEnum<MessageType>()).Content(revealedLetter));
                    this.helpIsUsed = true;
                    break;
            }
        }

        /// <summary>
        ///     Checks if the word is guessed.
        /// </summary>
        /// <returns></returns>
        public bool IsWon()
        {
            bool wordIsRevealed = this.CurrentWord.IsRevealed();

            if (wordIsRevealed)
            {
                if (this.helpIsUsed)
                {
                    Console.WriteLine(MessageFactory.GetMessage("cheatWin".ToEnum<MessageType>()).Content(this.mistakes));
                    this.CurrentWord.Print();
                }
                else
                {
                    Console.WriteLine(MessageFactory.GetMessage("win".ToEnum<MessageType>()).Content(this.mistakes));
                    this.CurrentWord.Print();

                    bool topscoreResult = Scoreboard.IsTopScoreResult(this.mistakes);

                    if (topscoreResult)
                    {
                        Scoreboard.AddNewTopScoreRecord(this.mistakes);
                        Scoreboard.Print();
                    }
                }
            }

            return wordIsRevealed;
        }
    }
}