namespace HangmanGame
{
    using System;
    using System.Linq;
    using Extensions;

    public class UserInputHandler
    {
        private int mistakes;

        private string wordToGuess;

        public UserInputHandler(string wordToGuess)
        {
            this.wordToGuess = wordToGuess;
            this.CurrentWord = new Words(this.wordToGuess);
            this.mistakes = 0;
            this.CurrentWord.Empty(this.wordToGuess.Length);
        }

        public bool HelpIsUsed { get; set; }

        public bool EndOfAllGames { get; set; }

        public bool EndOfCurrentGame { get; set; }

        public string LastCommand { get; set; }

        public string LastInput { get; set; }

        public Words CurrentWord { get; set; }

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
                    Console.WriteLine(MessageFactory.GetMessage("onSuccessLetter".ToEnum<Messages>()).Content(revealedLetters));
                }
            }
            else
            {
                Console.WriteLine(MessageFactory.GetMessage("onRepeatedLetter".ToEnum<Messages>()).Content(this.LastInput[0]));
                this.mistakes++;
            }
        }

        public void ProcessUserCommand()
        {
            this.EndOfCurrentGame = false;
            this.EndOfAllGames = false;
            this.HelpIsUsed = false;

            switch (this.LastCommand)
            {
                case "top":
                    Scoreboard.Print();
                    break;
                case "restart":
                    this.EndOfCurrentGame = true;
                    this.EndOfAllGames = false;
                    break;
                case "exit":
                    Console.WriteLine(MessageFactory.GetMessage("exit".ToEnum<Messages>()).Content());
                    this.EndOfCurrentGame = true;
                    this.EndOfAllGames = true;
                    break;
                case "help":
                    char revealedLetter = this.CurrentWord.GetHelp(this.wordToGuess);
                    Console.WriteLine(MessageFactory.GetMessage("getHelp".ToEnum<Messages>()).Content(revealedLetter));
                    this.HelpIsUsed = true;
                    break;
                default:
                    break;
            }
        }

        public bool IsWon()
        {
            bool wordIsRevealed = this.CurrentWord.IsRevealed();

            if (wordIsRevealed)
            {
                if (this.HelpIsUsed)
                {
                    Console.WriteLine(MessageFactory.GetMessage("cheatWin".ToEnum<Messages>()).Content(this.mistakes));
                    this.CurrentWord.Print();
                }
                else
                {
                    Console.WriteLine(MessageFactory.GetMessage("win".ToEnum<Messages>()).Content(this.mistakes));
                    this.CurrentWord.Print();

                    bool topscoreResult = Scoreboard.IsTopScoreResult(this.mistakes);

                    if (topscoreResult)
                    {
                        Scoreboard.AddNewTopscoreRecord(this.mistakes);
                        Scoreboard.Print();
                    }
                }
            }

            return wordIsRevealed;
        }
    }
}