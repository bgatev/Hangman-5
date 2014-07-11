namespace HangmanGame.Tests
{
    using HangmanGame;
    using System;
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
        public void UserInputHandlerShouldTakeLetters()
        {
        }
    }
}
