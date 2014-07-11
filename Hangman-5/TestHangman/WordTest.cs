namespace HangmanGame.Tests
{
    using HangmanGame;
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WordTest
    {
        Word testwordToGuess;
        Word testword;
        string word;
        [TestInitialize]
        public void InitialiseUserInputHandler()
        {
            word = "program";
            testwordToGuess = new Word(word);
            testword = new Words(word);
            
        }

        [TestMethod]
        public void WordCharactersShouldBeAccessible()
        {
            Assert.AreEqual('g', testword[3]);   
        }

        [TestMethod]
        public void WordShouldCheckIfALetterIsRevealed()
        {
            bool isRevealed = testword.IsLetterRevealed("o");
            Assert.IsTrue(isRevealed);
            isRevealed = testword.IsLetterRevealed("x");
            Assert.IsFalse(isRevealed);
        }

        [TestMethod]
        public void WordGetHelpShouldRevealALetter()
        {
            char revealedLetter = testword.GetHelp(word);
            Assert.AreEqual<char>('p', revealedLetter);
        }


    }
}
