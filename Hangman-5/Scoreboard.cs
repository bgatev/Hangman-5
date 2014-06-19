namespace HangmanGame
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Singleton Pattern for Scoreboard
    /// </summary>
    public sealed class Scoreboard
    {
        private const int TOPSCORE_MAX_RECORDS = 5;
        private static readonly List<KeyValuePair<int, string>> topScore = new List<KeyValuePair<int, string>>();

        public Scoreboard()
        {
        }

        public static List<KeyValuePair<int, string>> TopScore
        {
            get
            {
                return topScore;
            }
        }

        public static bool IsTopScoreResult(int mistakes)
        {
            if (Scoreboard.TopScore.Count < TOPSCORE_MAX_RECORDS)
            {
                return true;
            }
            else
            {
                int worstResult = Scoreboard.TopScore[TOPSCORE_MAX_RECORDS - 1].Key;

                if (mistakes < worstResult)
                {
                    return true;
                }
            }

            return false;
        }

        public static void AddNewTopscoreRecord(int mistakes)
        {
            if (TopScore.Count == TOPSCORE_MAX_RECORDS)
            {
                TopScore.RemoveAt(TopScore.Count - 1);
            }

            string playerName = GetPlayerName();
            KeyValuePair<int, string> newTopscoreRecord = new KeyValuePair<int, string>(mistakes, playerName);

            TopScore.Add(newTopscoreRecord);
            TopScore.Sort(CompareByKeys);
        }

        private static string GetPlayerName()
        {
            while (true)
            {
                Console.Write("Please enter your name for the top scoreboard: ");
                string playerName = Console.ReadLine();

                if (playerName.Length == 0)
                {
                    Console.WriteLine("You did not enter a name. Please, try again.");
                }
                else if (playerName.Length > 40)
                {
                    Console.WriteLine("The name you entered is too long. Please, enter a name up to 40 characters");
                }
                else
                {
                    return playerName;
                }
            }
        }

        private static int CompareByKeys(KeyValuePair<int, string> pairA, KeyValuePair<int, string> pairB)
        {
            return pairA.Key.CompareTo(pairB.Key);
        }  
    }
}