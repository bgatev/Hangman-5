namespace Hangman
{
    using System;
    using Extensions;
    using Interfaces;
    using Commands;
    using HangmanGame;

    public class Game
    {
        public bool Play()
        {
            UserInputHandler inputHandler = new UserInputHandler(Words.GetRandom());
            Executor executor = new Executor();
            //string wordToGuess = Words.GetRandom();
            //Words currentWord = new Words(wordToGuess);

            ICommand printCurrentWord = new PrintCurrentWordCommand(inputHandler);
            ICommand getInput = new GetUserInputCommand(inputHandler);
            ICommand processInput = new ProcessUserGuessCommand(inputHandler);
            ICommand processCommand = new ProcessUserCommand(inputHandler);
            //currentWord.Empty(wordToGuess.Length);

            int mistakes = 0;

            //bool gameOver = false;
            //bool currentGameOver = false;
            //bool hintUsed = false;

            while (!inputHandler.EndOfCurrentGame)
            {
                executor.StoreAndExecute(printCurrentWord);
                executor.StoreAndExecute(getInput);

                if (inputHandler.LastInput != string.Empty)
                {
                    executor.StoreAndExecute(processInput);
                }
                else
                {
                    //this.Process(inputHandler.LastCommand, wordToGuess, currentWord, out gameOver, out currentGameOver, out hintUsed);
                    executor.StoreAndExecute(processCommand);
                }

                bool gameIsWon = inputHandler.IsWon();

                if (gameIsWon)
                {
                    inputHandler.EndOfCurrentGame = true;
                }
            }

            return inputHandler.EndOfAllGames;
        }
        //    switch (command)
        //    {
        //        case "top":
        //            Scoreboard.Print();
        //            break;
        //        case "restart":
        //            endOfCurrentGame = true;
        //            endOfAllGames = false;
        //            break;
        //        case "exit":
        //            Console.WriteLine(MessageFactory.GetMessage("exit".ToEnum<Messages>()).Content());
        //            endOfCurrentGame = true;
        //            endOfAllGames = true;
        //            break;
        //        case "help":
        //            char revealedLetter = currentWord.GetHelp(secretWord);
        //            Console.WriteLine(MessageFactory.GetMessage("getHelp".ToEnum<Messages>()).Content(revealedLetter));
        //            helpIsUsed = true;
        //            break;
        //        default:
        //            break;
        //    }
        //}
        //private void Process(string command, string secretWord, Words currentWord, out bool endOfAllGames, out bool endOfCurrentGame, out bool helpIsUsed)
        //{
        //    endOfCurrentGame = false;
        //    endOfAllGames = false;
        //    helpIsUsed = false;
        //    return wordIsRevealed;
        //}
        //            if (topscoreResult)
        //            {
        //                Scoreboard.AddNewTopscoreRecord(mistakes);
        //                Scoreboard.Print();
        //            }
        //        }
        //    }
        //            bool topscoreResult = Scoreboard.IsTopScoreResult(mistakes);
        //    if (wordIsRevealed)
        //    {
        //        if (inputHandler.HelpIsUsed)
        //        {
        //            Console.WriteLine(MessageFactory.GetMessage("cheatWin".ToEnum<Messages>()).Content(mistakes));
        //            currentWord.Print();
        //        }
        //        else
        //        {
        //            Console.WriteLine(MessageFactory.GetMessage("win".ToEnum<Messages>()).Content(mistakes));
        //            currentWord.Print();
        //private bool IsWon()
        //{
        //    bool wordIsRevealed = currentWord.IsRevealed();
    }
}