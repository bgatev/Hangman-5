namespace Hangman
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Singleton Pattern for Scoreboard
    /// </summary>
    public sealed class Scoreboard
    {
        private const int TopScoreMaxRecords = 5;
        private static readonly List<KeyValuePair<int, string>> GameTopScore = new List<KeyValuePair<int, string>>();

        public static List<KeyValuePair<int, string>> TopScore
        {
            get { return GameTopScore; }
        }

        public static bool IsTopScoreResult(int mistakes)
        {
            if (TopScore.Count < TopScoreMaxRecords)
            {
                return true;
            }

            int worstResult = TopScore[TopScoreMaxRecords - 1].Key;

            if (mistakes < worstResult)
            {
                return true;
            }

            return false;
        }

        public static void AddNewTopScoreRecord(int mistakes)
        {
            if (TopScore.Count == TopScoreMaxRecords)
            {
                TopScore.RemoveAt(TopScore.Count - 1);
            }

            string playerName = GetPlayerName();
            var newTopscoreRecord = new KeyValuePair<int, string>(mistakes, playerName);

            TopScore.Add(newTopscoreRecord);
            TopScore.Sort(CompareByKeys);
        }

        public static void Print()
        {
            Console.WriteLine("Scoreboard:");

            if (TopScore.Count > 0)
            {
                for (int i = 0; i < TopScore.Count; i++)
                {
                    string name = TopScore[i].Value;
                    int mistakes = TopScore[i].Key;

                    Console.WriteLine("{0}. {1} --> {2} mistakes", i + 1, name, mistakes);
                }
            }
            else
            {
                Console.WriteLine("There are no records in the scoreboard yet.");
            }
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