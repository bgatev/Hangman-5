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
        public void UserInputHandlerShouldTakeGuesses()
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


    }
}
