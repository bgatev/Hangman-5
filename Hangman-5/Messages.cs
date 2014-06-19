namespace HangmanGame
{
    using System;

    public class Messages
    {
        public Messages()
        {
        }

        public static void PrintWelcome()
        {
            Console.WriteLine("Welcome to “Hangman” game. Please try to guess my secret word.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game, " + "'help' to cheat and 'exit' to quit the game.");
        }

        public static void PrintExit()
        {
            Console.WriteLine("Goodbye!");
        }

        public static void PrintGetHelp(char revealedLetter)
        {
            Console.WriteLine("OK, I reveal for you the next letter '{0}'.", revealedLetter);
        }

        public static void PrintOnSuccessLetter(int revealedLetters)
        {
            if (revealedLetters == 1)
            {
                Console.WriteLine("Good job! You revealed {0} letter.", revealedLetters);
            }
            else
            {
                Console.WriteLine("Good job! You revealed {0} letters.", revealedLetters);
            }
        }

        public static void PrintOnRepeatedLetter(char revealedLetter)
        {
            Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\".", revealedLetter);
        }

        public static void PrintInvalidEntry()
        {
            Console.WriteLine("Incorrect guess or command!");
        }

        public static void PrintWin(int mistakes)
        {
            Console.WriteLine("You won with {0} mistakes.", mistakes);
        }

        public static void PrintCheatWin(int mistakes)
        {
            Console.WriteLine("You won with {0} mistakes but you have cheated. " + "You are not allowed to enter into the scoreboard.", mistakes);
        }

        public static void PrintScoreBoard()
        {
            Console.WriteLine("Scoreboard:");

            if (Scoreboard.TopScore.Count > 0)
            {
                for (int i = 0; i < Scoreboard.TopScore.Count; i++)
                {
                    string name = Scoreboard.TopScore[i].Value;
                    int mistakes = Scoreboard.TopScore[i].Key;

                    Console.WriteLine("{0}. {1} --> {2} mistakes", i + 1, name, mistakes);
                }
            }
            else
            {
                Console.WriteLine("There are no records in the scoreboard yet.");
            }
        }
    }
}
