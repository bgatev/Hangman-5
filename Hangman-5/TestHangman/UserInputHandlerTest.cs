namespace TestHangman
{
    using System;
    using System.IO;
    using Hangman;
    using HangmanGame;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UserInputHandlerTest
    {
        private static readonly string Word = "program";
        private UserInputHandler testHandler;

        [TestInitialize]
        public void InitialiseUserInputHandler()
        {
            this.testHandler = new UserInputHandler(Word);
        }

        [TestMethod]
        public void UserInputHandlerShouldLoadAWordToGuess()
        {
            Assert.AreEqual("_______", this.testHandler.CurrentWord.ToString());
        }

        [TestMethod]
        public void UserInputHandlerShouldProcessRightGuesses()
        {
            using (var writer = new StringWriter())
            {
                var reader = new StringReader("m");
                Console.SetIn(reader);
                Console.SetOut(writer);
                this.testHandler.GetUserInput();
                Assert.AreEqual("m", this.testHandler.LastInput);
                this.testHandler.ProcessUserGuess();
                Assert.AreEqual("Enter your guess or command: Good job! You revealed 1 letter.\r\n", writer.ToString());
            }
        }

        [TestMethod]
        public void UserInputHandlerShouldProcessWrongGuesses()
        {
            using (var writer = new StringWriter())
            {
                var reader = new StringReader("x");
                Console.SetIn(reader);
                Console.SetOut(writer);
                this.testHandler.GetUserInput();
                Assert.AreEqual("x", this.testHandler.LastInput);
                this.testHandler.ProcessUserGuess();
                Assert.AreEqual(
                                "Enter your guess or command: Sorry! There are no unrevealed letters \"x\".\r\n",
                                writer.ToString());
            }
        }

        [TestMethod]
        public void UserInputHandlerShouldNotTakeBadCommands()
        {
            using (var writer = new StringWriter())
            {
                var reader = new StringReader("topx\ntop");
                using (reader)
                {
                    Console.SetIn(reader);
                    Console.SetOut(writer);
                    this.testHandler.GetUserInput();
                    Assert.AreEqual(
                                    "Enter your guess or command: Incorrect guess or command!\r\nEnter your guess or command: ",
                                    writer.ToString());
                }
            }
        }

        [TestMethod]
        public void UserInputShouldRecogniseTheGameIsWon()
        {
            var reader = new StringReader("p\nr\no\ng\nr\na\nm\ntestname");
            Console.SetIn(reader);
            for (int i = 0; i < Word.Length; i++)
            {
                this.testHandler.GetUserInput();
                this.testHandler.ProcessUserGuess();
            }

            bool isGameWon = this.testHandler.IsWon();
            Assert.IsTrue(isGameWon);
        }
    }
}