using PasswordCheck;
using System;
using Xunit;

namespace PasswordStruct.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void DetermineCorrectlyThatPasswordDoesMeetComplexityConditions_WhenCharacterTypesAreGrouped()
        {
            Program.Password passwordToCheck = default(Program.Password);
            passwordToCheck.password = "abcdeAB12 + -";
            passwordToCheck.minSmallLetter = 5;
            passwordToCheck.minBigLetter = 2;
            passwordToCheck.minNumbers = 2;
            passwordToCheck.minSymbols = 2;
            bool similarChars = true;
            bool ambiguousChars = true;
            char[] symbolChar = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '`', '~', ',', '.', '/', '?', '>', '<', ';', ':', '"', '\'', '\\', '[', '{', '}', ']' };
            char[] similarChar = { 'l', '1', 'I', 'o', '0', 'O' };
            char[] ambiguousChar = { '{', '}', '[', ']', '(', ')', '/', '\'', '"', '~', ';', '.', '<', '>' };


            Assert.True( Program.CheckPasswordComplexity(similarChars, ambiguousChars, passwordToCheck, symbolChar, similarChar, ambiguousChar));
        }
        [Fact]
        public void DetermineCorrectlyThatPasswordDoesMeetComplexityConditions_WhenCharacterTypesAreMixed()
        {
            Program.Password passwordToCheck = default(Program.Password);
            passwordToCheck.password = "a+bB-1cdeA2fG=3";
            passwordToCheck.minSmallLetter = 5;
            passwordToCheck.minBigLetter = 2;
            passwordToCheck.minNumbers = 2;
            passwordToCheck.minSymbols = 2;
            bool similarChars = true;
            bool ambiguousChars = true;

            char[] symbolChar = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '`', '~', ',', '.', '/', '?', '>', '<', ';', ':', '"', '\'', '\\', '[', '{', '}', ']' };
            char[] similarChar = { 'l', '1', 'I', 'o', '0', 'O' };
            char[] ambiguousChar = { '{', '}', '[', ']', '(', ')', '/', '\'', '"', '~', ';', '.', '<', '>' };

            Assert.True(Program.CheckPasswordComplexity(similarChars, ambiguousChars, passwordToCheck, symbolChar, similarChar, ambiguousChar));
        }
        [Fact]
        public void DetermineCorrectlyThatPasswordDoesNotMeetComplexityConditions_WhenThereAreNotEnoughLowercaseLetters()
        {
            Program.Password passwordToCheck = default(Program.Password);
            passwordToCheck.password = "AbcdeAB12+-";
            passwordToCheck.minSmallLetter = 5;
            passwordToCheck.minBigLetter = 2;
            passwordToCheck.minNumbers = 2;
            passwordToCheck.minSymbols = 2;
            bool similarChars = true;
            bool ambiguousChars = true;

            char[] symbolChar = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '`', '~', ',', '.', '/', '?', '>', '<', ';', ':', '"', '\'', '\\', '[', '{', '}', ']' };
            char[] similarChar = { 'l', '1', 'I', 'o', '0', 'O' };
            char[] ambiguousChar = { '{', '}', '[', ']', '(', ')', '/', '\'', '"', '~', ';', '.', '<', '>' };

            Assert.False(Program.CheckPasswordComplexity(similarChars, ambiguousChars, passwordToCheck, symbolChar, similarChar, ambiguousChar));
        }
        [Fact]
        public void DetermineCorrectlyThatPasswordDoesNotMeetComplexityConditions_WhenThereAreNotEnoughUppercaseLetters()
        {
            Program.Password passwordToCheck = default(Program.Password);
            passwordToCheck.password = "abcdeAb12+-";
            passwordToCheck.minSmallLetter = 5;
            passwordToCheck.minBigLetter = 2;
            passwordToCheck.minNumbers = 2;
            passwordToCheck.minSymbols = 2;
            bool similarChars = true;
            bool ambiguousChars = true;

            char[] symbolChar = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '`', '~', ',', '.', '/', '?', '>', '<', ';', ':', '"', '\'', '\\', '[', '{', '}', ']' };
            char[] similarChar = { 'l', '1', 'I', 'o', '0', 'O' };
            char[] ambiguousChar = { '{', '}', '[', ']', '(', ')', '/', '\'', '"', '~', ';', '.', '<', '>' };

            Assert.False(Program.CheckPasswordComplexity(similarChars, ambiguousChars, passwordToCheck, symbolChar, similarChar, ambiguousChar));
        }
        [Fact]
        public void DetermineCorrectlyThatPasswordDoesNotMeetComplexityConditions_WhenThereAreNotEnoughDigits()
        {
            Program.Password passwordToCheck = default(Program.Password);
            passwordToCheck.password = "abcdeAB2+-";
            passwordToCheck.minSmallLetter = 5;
            passwordToCheck.minBigLetter = 2;
            passwordToCheck.minNumbers = 2;
            passwordToCheck.minSymbols = 2;
            bool similarChars = true;
            bool ambiguousChars = true;

            char[] symbolChar = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '`', '~', ',', '.', '/', '?', '>', '<', ';', ':', '"', '\'', '\\', '[', '{', '}', ']' };
            char[] similarChar = { 'l', '1', 'I', 'o', '0', 'O' };
            char[] ambiguousChar = { '{', '}', '[', ']', '(', ')', '/', '\'', '"', '~', ';', '.', '<', '>' };

            Assert.False(Program.CheckPasswordComplexity(similarChars, ambiguousChars, passwordToCheck, symbolChar, similarChar, ambiguousChar));
        }
        [Fact]
        public void DetermineCorrectlyThatPasswordDoesNotMeetComplexityConditions_WhenThereAreNotEnoughSymbols()
        {
            Program.Password passwordToCheck = default(Program.Password);
            passwordToCheck.password = "AbcdeAB12m-";
            passwordToCheck.minSmallLetter = 5;
            passwordToCheck.minBigLetter = 2;
            passwordToCheck.minNumbers = 2;
            passwordToCheck.minSymbols = 2;
            bool similarChars = true;
            bool ambiguousChars = true;

            char[] symbolChar = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '`', '~', ',', '.', '/', '?', '>', '<', ';', ':', '"', '\'', '\\', '[', '{', '}', ']' };
            char[] similarChar = { 'l', '1', 'I', 'o', '0', 'O' };
            char[] ambiguousChar = { '{', '}', '[', ']', '(', ')', '/', '\'', '"', '~', ';', '.', '<', '>' };

            Assert.False(Program.CheckPasswordComplexity(similarChars, ambiguousChars, passwordToCheck, symbolChar, similarChar, ambiguousChar));
        }
        [Fact]
        public void DetermineCorrectlyThatPasswordDoesMeetComplexityConditions_WhenZeroDigitsAndZeroSymbolsAreRequired()
        {
            Program.Password passwordToCheck = default(Program.Password);
            passwordToCheck.password = "AbcdeABFGmJ";
            passwordToCheck.minSmallLetter = 5;
            passwordToCheck.minBigLetter = 2;
            passwordToCheck.minNumbers = 0;
            passwordToCheck.minSymbols = 0;
            bool similarChars = true;
            bool ambiguousChars = true;

            char[] symbolChar = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '`', '~', ',', '.', '/', '?', '>', '<', ';', ':', '"', '\'', '\\', '[', '{', '}', ']' };
            char[] similarChar = { 'l', '1', 'I', 'o', '0', 'O' };
            char[] ambiguousChar = { '{', '}', '[', ']', '(', ')', '/', '\'', '"', '~', ';', '.', '<', '>' };

            Assert.True(Program.CheckPasswordComplexity(similarChars, ambiguousChars, passwordToCheck, symbolChar, similarChar, ambiguousChar));
        }
        [Fact]
        public void DetermineCorrectlyThatPasswordDoesMeetComplexityConditions_WhenItContainsAndIsAllowedToContainAmbiguousAndSimilarCharacters()
        {
            Program.Password passwordToCheck = default(Program.Password);
            passwordToCheck.password = "abcde1}AB/23";
            passwordToCheck.minSmallLetter = 5;
            passwordToCheck.minBigLetter = 2;
            passwordToCheck.minNumbers = 2;
            passwordToCheck.minSymbols = 2;
            bool similarChars = true;
            bool ambiguousChars = true;

            char[] symbolChar = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '`', '~', ',', '.', '/', '?', '>', '<', ';', ':', '"', '\'', '\\', '[', '{', '}', ']' };
            char[] similarChar = { 'l', '1', 'I', 'o', '0', 'O' };
            char[] ambiguousChar = { '{', '}', '[', ']', '(', ')', '/', '\'', '"', '~', ';', '.', '<', '>' };

            Assert.True(Program.CheckPasswordComplexity(similarChars, ambiguousChars, passwordToCheck, symbolChar, similarChar, ambiguousChar));
        }
    }
}
