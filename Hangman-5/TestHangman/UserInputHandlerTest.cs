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

        [TestInitialize]
        public void InitialiseUserInputHandler()
        {
            TestHandler = new UserInputHandler("program");
        }

        [TestMethod]
        public void UserInputHandlerShouldLoadAWordToGuess()
        {
            Assert.AreEqual("_______", TestHandler.CurrentWord);
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
                Assert.AreEqual<string>("Good job! You revealed 1 letter.", writer.ToString());
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
                Assert.AreEqual<string>("Sorry! There are no unrevealed letters \"x\".", writer.ToString());
            }
        }

        [TestMethod]
        public void UserInputHandlerShouldNotTakeBadCommands()
        {
            using (StringWriter writer = new StringWriter())
            {
                StringReader reader = new StringReader("topx");
                Console.SetIn(reader);
                Console.SetOut(writer);
                TestHandler.GetUserInput();
                Assert.AreEqual<string>("Incorrect guess or command!", writer.ToString());
            }
        }

        [TestMethod]
        public void UserInputShouldRecogniseTheGameIsWon()
        {
            StringReader reader = new StringReader("p\nr\no\ng\nr\na\nm");
            Console.SetIn(reader);
            TestHandler.GetUserInput();
            bool isGameWon = TestHandler.IsWon();
            Assert.IsTrue(isGameWon);
        }

    }
}
