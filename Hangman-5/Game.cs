﻿namespace HangmanGame
{
    using System;

    public class Game
    {
        public bool Play()
        {
            string wordToGuess = Words.GetRandom();
            Words currentWord = new Words(wordToGuess);

            currentWord.Empty(wordToGuess.Length);

            int mistakes = 0;

            bool gameOver = false;
            bool currentGameOver = false;
            bool hintUsed = false;

            while (!currentGameOver)
            {
                currentWord.Print();

                string command = string.Empty;
                string suggestedLetter = Hangman.GetUserInput(out command);

                if (suggestedLetter != string.Empty)
                {
                    Hangman.ProcessUserGuess(suggestedLetter, wordToGuess, currentWord, ref mistakes);
                }
                else
                {
                    this.Process(command, wordToGuess, currentWord, out gameOver, out currentGameOver, out hintUsed);
                }

                bool gameIsWon = this.IsWon(currentWord, hintUsed, mistakes);

                if (gameIsWon)
                {
                    currentGameOver = true;
                }
            }

            return gameOver;
        }

        private bool IsWon(Words currentWord, bool helpIsUsed, int mistakes)
        {
            bool wordIsRevealed = currentWord.IsRevealed();

            if (wordIsRevealed)
            {
                if (helpIsUsed)
                {
                    Console.WriteLine(MessageFactory.GetMessage(4).Content(mistakes));
                    currentWord.Print();
                }
                else
                {
                    Console.WriteLine(MessageFactory.GetMessage(3).Content(mistakes));
                    currentWord.Print();

                    bool topscoreResult = Scoreboard.IsTopScoreResult(mistakes);

                    if (topscoreResult)
                    {
                        Scoreboard.AddNewTopscoreRecord(mistakes);
                        Scoreboard.Print();
                    }
                }
            }

            return wordIsRevealed;
        }

        private void Process(string command, string secretWord, Words currentWord, out bool endOfAllGames, out bool endOfCurrentGame, out bool helpIsUsed)
        {
            endOfCurrentGame = false;
            endOfAllGames = false;
            helpIsUsed = false;

            switch (command)
            {
                case "top":
                    Scoreboard.Print();
                    break;
                case "restart":
                    endOfCurrentGame = true;
                    endOfAllGames = false;
                    break;
                case "exit":
                    Console.WriteLine(MessageFactory.GetMessage(1).Content());
                    endOfCurrentGame = true;
                    endOfAllGames = true;
                    break;
                case "help":
                    char revealedLetter = currentWord.GetHelp(secretWord);
                    Console.WriteLine(MessageFactory.GetMessage(2).Content(revealedLetter));
                    helpIsUsed = true;
                    break;
                default:
                    break;
            }
        }
    }
}