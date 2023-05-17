using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Typograph;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        
        [TestMethod]
        public void ReplaceLetterE_TextWithLetterE_ReturnsTextWithReplacedLetterYo()
        {
            string input = "Привет, как дела?";
            string expectedOutput = "Привёт, как дела?";
            string result = TypographMethods.ReplaceLetterE(input);

            Assert.AreEqual(expectedOutput, result);
        }

        
        [TestMethod]
        public void ReplaceLetterE_TextWithoutLetterE_ReturnsUnchangedText()
        {
            string input = "This text doesn't contain the letter E";
            string expectedOutput = "This text doesn't contain the letter E";
            string result = TypographMethods.ReplaceLetterE(input);

            Assert.AreEqual(expectedOutput, result);
        }

        
        [TestMethod]
        public void ReplaceRussianLetters_ValidText_ReturnsTextWithReplacedLetters()
        {
            string input = "Привет, мир!";
            string expectedOutput = "Псгжеу, нйс!";
            string result = TypographMethods.ReplaceRussianLetters(input);

            Assert.AreEqual(expectedOutput, result);
        }

        
        [TestMethod]
        public void ReplaceRussianLetters_TextWithoutRussianLetters_ReturnsUnchangedText()
        {
            string input = "Hello, world!";
            string expectedOutput = "Hello, world!";
            string result = TypographMethods.ReplaceRussianLetters(input);

            Assert.AreEqual(expectedOutput, result);
        }

        
        [TestMethod]
        public void ReplacingProgrammaticQuotesWithRegularOnes_ReplacesQuotesCorrectly()
        {
            string input = $"This is a \"test\" string with \"quotes\" in it.";
            string output = TypographMethods.ReplacingProgrammaticQuotesWithRegularOnes(input);

            Assert.AreEqual("This is a «test» string with «quotes» in it.", output);
        }

        
        [TestMethod]
        public void ReplacingProgrammaticQuotesWithRegularOnes_DoesNotReplaceSingleQuotes()
        {
            string input = @"This is a 'test' string with 'single' quotes in it.";
            string output = TypographMethods.ReplacingProgrammaticQuotesWithRegularOnes(input);

            Assert.AreEqual(input, output);
        }

       
        [TestMethod]
        public void RemoveHyphenSpacing_TextWithHyphenBetweenLettersAndSpaceAround_ReturnsTextWithHyphenSpacingRemoved()
        {
            string input = "text - with - hyphen";
            string expectedOutput = "text -with- hyphen";
            string result = TypographMethods.RemoveHyphenSpacing(input);

            Assert.AreEqual(expectedOutput, result);
        }

        
        [TestMethod]
        public void RemoveHyphenSpacing_TextWithHyphenAtEnd_ReturnsTextWithHyphenSpacingRemoved()
        {
            string input = "text with hyphen-";
            string expectedOutput = "text with hyphen-";
            string result = TypographMethods.RemoveHyphenSpacing(input);

            Assert.AreEqual(expectedOutput, result);
        }

        
        [TestMethod]
        public void CanNotUseHyphenInTheDigitalRange_ShouldNotChangeText_WhenDigitalRangeIsInvalid()
        {
            string input = "123-45-6";
            string result = TypographMethods.CanNotUseHyphenInTheDigitalRange(input);

            Assert.AreEqual(input, result);
        }

        
        [TestMethod]
        public void CanNotUseHyphenInTheDigitalRange_ReplacesCorrectRange()
        {
            string text = "123-4567";
            string expected = "123—4567";
            string result = TypographMethods.CanNotUseHyphenInTheDigitalRange(text);

            Assert.AreEqual(expected, result);
        }

        
        [TestMethod]
        public void CanNotUseHyphenInTheDigitalRange_DoesNotModifyStringWithoutRanges()
        {
            string text = "1234567";
            string expected = "1234567";
            string result = TypographMethods.CanNotUseHyphenInTheDigitalRange(text);

            Assert.AreEqual(expected, result);
        }

        
        [TestMethod]
        public void CanNotUseHyphenInTheDigitalRange_ReplacesMultipleRanges()
        {
            string text = "123-4567 890-1234";
            string expected = "123—4567 890—1234";
            string result = TypographMethods.CanNotUseHyphenInTheDigitalRange(text);

            Assert.AreEqual(expected, result);
        }

        
        [TestMethod]
        public void CanNotUseHyphenInTheDigitalRange_DoesNotReplaceRangeWithLeadingZero()
        {
            string text = "0123-4567";
            string expected = "0123—4567";
            string result = TypographMethods.CanNotUseHyphenInTheDigitalRange(text);

            Assert.AreEqual(expected, result);
        }

        
        [TestMethod]
        public void ReplaceDimensionsSymbol_InvalidFormat()
        {
            string input = "высота x длинна";
            string expectedOutput = "высота × длинна";
            string result = TypographMethods.ReplaceDimensionsSymbol(input);

            Assert.AreNotEqual(expectedOutput, result);
        }

        
        [TestMethod]
        public void ReplaceDimensionsSymbol_ValidFormat_ReturnsTextWithReplacedSymbol()
        {
            string input = "ширина x высота x длинна";
            string expectedOutput = "ширина × высота × длинна";
            string result = TypographMethods.ReplaceDimensionsSymbol(input);

            Assert.AreEqual(expectedOutput, result);
        }
    }
}
