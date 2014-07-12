namespace HangmanGame.Tests
{
    using HangmanGame;
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;

    [TestClass]
    public class ScoreboardTest
    {
        [TestMethod]
        public void ScoreboardShouldAddTopScores()
        {
            string testName = "Testname";
            StringReader reader = new StringReader(testName);
            using (reader)
            {
                Console.SetIn(reader);
                Scoreboard.AddNewTopscoreRecord(1);
            }

            int numberOfRecords = Scoreboard.TopScore.Count;
            string topName = Scoreboard.TopScore[0].Value;
            Assert.AreEqual(1, numberOfRecords);
            Assert.AreEqual(testName, topName);

        }

        public void ScoreboardShouldRecogniseTopScore()
        {
            string testName = "Testname";
            StringReader reader = new StringReader(testName);
            for (int i = 0; i < 5; i++)
            {
                using (reader)
                {
                    Console.SetIn(reader);
                    Scoreboard.AddNewTopscoreRecord(4);
                }

                string newTestName = "Topname";
                reader = new StringReader(newTestName);
                using (reader)
                {
                    Console.SetIn(reader);
                    Scoreboard.AddNewTopscoreRecord(2);
                }

                string topName = Scoreboard.TopScore[0].Value;
                Assert.AreEqual(newTestName, topName);
            }
        }
    }
}