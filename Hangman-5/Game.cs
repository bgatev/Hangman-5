namespace HangmanGame
{
    using System;

    public class Game
    {
        public static bool Play()
        {
            string wordToGuess = Words.SelectRandom();
            char[] currentWord = Words.EmptyWord(wordToGuess.Length);
            int mistakes = 0;

            bool gameOver = false;
            bool currentGameOver = false;
            bool hintUsed = false;

            while (!currentGameOver)
            {
                Words.Print(currentWord);

                string command = string.Empty;
                string suggestedLetter = Hangman.GetUserInput(out command);

                if (suggestedLetter != string.Empty)
                {
                    Hangman.ProcessUserGuess(suggestedLetter, wordToGuess, currentWord, ref mistakes);
                }
                else
                {
                    Game.Process(command, wordToGuess, currentWord, out gameOver, out currentGameOver, out hintUsed);
                }

                bool gameIsWon = IsWon(currentWord, hintUsed, mistakes);

                if (gameIsWon)
                {
                    currentGameOver = true;
                }
            }

            return gameOver;
        }

        public static bool IsWon(char[] currentWord, bool helpIsUsed, int mistakes)
        {
            bool wordIsRevealed = Words.IsRevealed(currentWord);

            if (wordIsRevealed)
            {
                if (helpIsUsed)
                {
                    Messages.PrintCheatWin(mistakes);
                    Words.Print(currentWord);
                }
                else
                {
                    Messages.PrintWin(mistakes);
                    Words.Print(currentWord);

                    bool topscoreResult = Scoreboard.IsTopScoreResult(mistakes);

                    if (topscoreResult)
                    {
                        Scoreboard.AddNewTopscoreRecord(mistakes);
                        Messages.PrintScoreBoard();
                    }
                }
            }

            return wordIsRevealed;
        }

        private static void Process(string command, string secretWord, char[] currentWord, out bool endOfAllGames, out bool endOfCurrentGame, out bool helpIsUsed)
        {
            endOfCurrentGame = false;
            endOfAllGames = false;
            helpIsUsed = false;

            switch (command)
            {
                case "top":
                    Messages.PrintScoreBoard();
                    break;
                case "restart":
                    endOfCurrentGame = true;
                    endOfAllGames = false;
                    break;
                case "exit":
                    Messages.PrintExit();
                    endOfCurrentGame = true;
                    endOfAllGames = true;
                    break;
                case "help":
                    char revealedLetter = Words.GetHelp(secretWord, currentWord);
                    Messages.PrintGetHelp(revealedLetter);
                    helpIsUsed = true;
                    break;
                default:
                    break;
            }
        }
    }
}
