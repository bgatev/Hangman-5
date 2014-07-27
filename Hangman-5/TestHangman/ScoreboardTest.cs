namespace HangmanGame.Tests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ScoreboardTest
    {
        [TestMethod]
        public void ScoreboardShouldAddTopScores()
        {
            string testName = "Testname";
            var reader = new StringReader(testName);
            using (reader)
            {
                Console.SetIn(reader);
                Scoreboard.AddNewTopScoreRecord(1);
            }

            int numberOfRecords = Scoreboard.TopScore.Count;
            string topName = Scoreboard.TopScore[0].Value;
            Assert.AreEqual(1, numberOfRecords);
            Assert.AreEqual(testName, topName);
        }

        public void ScoreboardShouldRecogniseTopScore()
        {
            string testName = "Testname";
            var reader = new StringReader(testName);
            for (int i = 0; i < 5; i++)
            {
                using (reader)
                {
                    Console.SetIn(reader);
                    Scoreboard.AddNewTopScoreRecord(4);
                }

                string newTestName = "Topname";
                reader = new StringReader(newTestName);
                using (reader)
                {
                    Console.SetIn(reader);
                    Scoreboard.AddNewTopScoreRecord(2);
                }

                string topName = Scoreboard.TopScore[0].Value;
                Assert.AreEqual(newTestName, topName);
            }
        }

        public void ScoreboardShouldNotAddNonTopScores()
        {
            string testName = "Testname";
            var reader = new StringReader(testName);
            for (int i = 0; i < 5; i++)
            {
                using (reader)
                {
                    Console.SetIn(reader);
                    Scoreboard.AddNewTopScoreRecord(2);
                }

                string newTestName = "Topname";
                reader = new StringReader(newTestName);
                using (reader)
                {
                    Console.SetIn(reader);
                    Scoreboard.AddNewTopScoreRecord(4);
                }

                // not finished
            }
        }
    }
}