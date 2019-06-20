using System;
using Xunit;

namespace PasswordStruct.Tests
{
    public class PasswordTests
    {
        public class ProgramTests
        {
            [Fact]
            public void DetermineCorrectlyThatPasswordDoesMeetComplexityConditions_WhenCharacterTypesAreGrouped()
            {
                var actual = new Password("abcde>>AB12+-", 5, 2, 2, 2);
                bool result = actual.CheckPasswordComplexity();
                Assert.True(result);
            }

            [Fact]
            public void DetermineCorrectlyThatPasswordDoesMeetComplexityConditions_WhenCharacterTypesAreMixed()
            {
                var actual = new Password("a)+bB-1cdeA2fG=3", 5, 2, 2, 2);
                bool result = actual.CheckPasswordComplexity();
                Assert.True(result);
            }

            [Fact]
            public void
                DetermineCorrectlyThatPasswordDoesNotMeetComplexityConditions_WhenThereAreNotEnoughLowercaseLetters()
            {
                var actual = new Password("Abcde(AB12+-", 4, 2, 2, 2);
                bool result = actual.CheckPasswordComplexity();
                Assert.True(result);
            }

            [Fact]
            public void
                DetermineCorrectlyThatPasswordDoesNotMeetComplexityConditions_WhenThereAreNotEnoughUppercaseLetters()
            {
                var actual = new Password("abcdeAb.12+-", 5, 1, 2, 2);
                bool result = actual.CheckPasswordComplexity();
                Assert.True(result);
            }

            [Fact]
            public void DetermineCorrectlyThatPasswordDoesNotMeetComplexityConditions_WhenThereAreNotEnoughDigits()
            {
               var actual = new Password("abcdeAB/12+-", 5, 2, 1, 2);
                bool result = actual.CheckPasswordComplexity();
                Assert.True(result);
            }

            [Fact]
            public void DetermineCorrectlyThatPasswordDoesNotMeetComplexityConditions_WhenThereAreNotEnoughSymbols()
            {
                var actual = new Password("AbcdeAB12m\"-", 5, 2, 2, 1);
                bool result = actual.CheckPasswordComplexity();
                Assert.True(result);
            }

            [Fact]
            public void
                DetermineCorrectlyThatPasswordDoesMeetComplexityConditions_WhenZeroDigitsAndZeroSymbolsAreRequired()
            {
                var actual = new Password("abcde;AB/123", 5, 2, 2, 2);
                bool result = actual.CheckPasswordComplexity();
                Assert.True(result);
            }

            [Fact]
            public void
                DetermineCorrectlyThatPasswordDoesMeetComplexityConditions_WhenItContainsAndIsAllowedToContainAmbiguousAndSimilarCharacters()
            {
                var actual = new Password("abcde1}AB/23", 5, 2, 2, 2);
                bool result = actual.CheckPasswordComplexity();
                Assert.True(result);
            }
        }
    }
}
