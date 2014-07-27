namespace HangmanGame.Tests
{
    using System;
    using System.IO;
    using Hangman;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WordsTest
    {
        private static readonly string Word = "program";
        private Words testwordToGuess;

        [TestInitialize]
        public void InitialiseUserInputHandler()
        {
            this.testwordToGuess = new Words(Word);
        }

        [TestMethod]
        public void CharactersShouldBeAccessible()
        {
            char expectedChar = Word[3];
            Assert.AreEqual(expectedChar, this.testwordToGuess[3]);
        }

        [TestMethod]
        public void IsLetterRevealedPositive()
        {
            bool isRevealed = this.testwordToGuess.IsLetterRevealed("o");
            Assert.IsTrue(isRevealed);
        }

        [TestMethod]
        public void IsLetterRevealedNegative()
        {
            bool isRevealed = this.testwordToGuess.IsLetterRevealed("x");
            Assert.IsFalse(isRevealed);
        }

        [TestMethod]
        public void GetHelpShouldRevealFirstLetter()
        {
            char revealedLetter = this.testwordToGuess.GetHelp(Word);
            Assert.AreEqual('p', revealedLetter);
        }

        [TestMethod]
        public void EmptyShouldReplaceAllWithUnderscore()
        {
            this.testwordToGuess.Empty(Word.Length);
            string expected = "_______";

            Assert.AreEqual(expected, this.testwordToGuess.ToString());
        }

        [TestMethod]
        public void GetHelpShouldRevealFirstUnrevealedLetter()
        {
            this.testwordToGuess.Empty(Word.Length);
            this.testwordToGuess[0] = 'p';

            char revealedLetter = this.testwordToGuess.GetHelp(Word);

            Assert.AreEqual('r', revealedLetter);
        }

        [TestMethod]
        public void TestPrint()
        {
            this.testwordToGuess.Empty(Word.Length);

            string result;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                this.testwordToGuess.Print();

                result = writer.ToString();
            }

            string expected = "The secret word is: _ _ _ _ _ _ _\r\n";
            Assert.AreEqual(expected, result);
        }
    }
}