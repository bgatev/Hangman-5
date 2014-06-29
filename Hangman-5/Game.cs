namespace HangmanGame
{
    using System;
    using Commands;
    using Extensions;
    using Interfaces;

    public class Game
    {
        public bool Play()
        {
            UserInputHandler inputHandler = new UserInputHandler(Words.GetRandom());
            Executor executor = new Executor();

            ICommand printCurrentWord = new PrintCurrentWordCommand(inputHandler);
            ICommand getInput = new GetUserInputCommand(inputHandler);
            ICommand processInput = new ProcessUserGuessCommand(inputHandler);
            ICommand processCommand = new ProcessUserCommand(inputHandler);

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
    }
}