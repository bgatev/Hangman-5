namespace HangmanGame.Tests
{
    using HangmanGame;
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UserInputHandlerTest
    {
        private UserInputHandler TestHandler;
        private static readonly string word = "program";

        [TestInitialize]
        public void InitialiseUserInputHandler()
        {
            TestHandler = new UserInputHandler(word);
        }

        [TestMethod]
        public void UserInputHandlerShouldLoadAWordToGuess()
        {
            Assert.AreEqual("_______", TestHandler.CurrentWord.ToString());
        }

        [TestMethod]
        public void UserInputHandlerShouldProcessRightGuesses()
        {
            using (StringWriter writer = new StringWriter())
            {
                StringReader reader = new StringReader("m");
                Console.SetIn(reader);
                Console.SetOut(writer);
                TestHandler.GetUserInput();
                Assert.AreEqual("m", TestHandler.LastInput);
                TestHandler.ProcessUserGuess();
                Assert.AreEqual("Enter your guess or command: Good job! You revealed 1 letter.\r\n", writer.ToString());
            }
        }

        [TestMethod]
        public void UserInputHandlerShouldProcessWrongGuesses()
        {
            using (StringWriter writer = new StringWriter())
            {
                StringReader reader = new StringReader("x");
                Console.SetIn(reader);
                Console.SetOut(writer);
                TestHandler.GetUserInput();
                Assert.AreEqual("x", TestHandler.LastInput);
                TestHandler.ProcessUserGuess();
                Assert.AreEqual<string>("Enter your guess or command: Sorry! There are no unrevealed letters \"x\".\r\n",
                    writer.ToString());
            }
        }

        [TestMethod]
        public void UserInputHandlerShouldNotTakeBadCommands()
        {
            using (StringWriter writer = new StringWriter())
            {
                StringReader reader = new StringReader("topx\ntop");
                using (reader)
                {
                    Console.SetIn(reader);
                    Console.SetOut(writer);
                    TestHandler.GetUserInput();
                    Assert.AreEqual("Enter your guess or command: Incorrect guess or command!\r\nEnter your guess or command: ",
                        writer.ToString());
                }
            }
        }

        [TestMethod]
        public void UserInputShouldRecogniseTheGameIsWon()
        {
            StringReader reader = new StringReader("p\nr\no\ng\nr\na\nm\ntestname");
            Console.SetIn(reader);
            for (int i = 0; i < word.Length; i++)
            {
                TestHandler.GetUserInput();
                TestHandler.ProcessUserGuess();
            }

            bool isGameWon = TestHandler.IsWon();
            Assert.IsTrue(isGameWon);
        }

    }
}
