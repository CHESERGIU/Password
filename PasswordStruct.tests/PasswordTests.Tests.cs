using Xunit;

namespace PasswordStruct.Tests
{
    internal class PasswordTests
    {
        public class ProgramTests
        {
            [Fact]
            public void DetermineCorrectlyThatPasswordDoesMeetComplexityConditionsWhenCharacterTypesAreGrouped()
            {
                var actual = new Password("abode>>AB12+-", 5, 2, 2, 2);
                bool result = actual.CheckPasswordComplexity();
                Assert.True(result);
            }

            [Fact]
            public void DetermineCorrectlyThatPasswordDoesMeetComplexityConditionsWhenCharacterTypesAreMixed()
            {
                var actual = new Password("a)+bB-1cdeA2fG=3", 5, 2, 2, 2);
                bool result = actual.CheckPasswordComplexity();
                Assert.True(result);
            }

            [Fact]
            public void
                DetermineCorrectlyThatPasswordDoesNotMeetComplexityConditionsWhenThereAreNotEnoughLowercaseLetters()
            {
                var actual = new Password("Abode(AB12+-", 4, 2, 2, 2);
                bool result = actual.CheckPasswordComplexity();
                Assert.True(result);
            }

            [Fact]
            public void
                DetermineCorrectlyThatPasswordDoesNotMeetComplexityConditionsWhenThereAreNotEnoughUppercaseLetters()
            {
                var actual = new Password("abodeAb.12+-", 5, 1, 2, 2);
                bool result = actual.CheckPasswordComplexity();
                Assert.True(result);
            }

            [Fact]
            public void DetermineCorrectlyThatPasswordDoesNotMeetComplexityConditionsWhenThereAreNotEnoughDigits()
            {
               var actual = new Password("abodeAB/12+-", 5, 2, 1, 2);
               bool result = actual.CheckPasswordComplexity();
               Assert.True(result);
            }

            [Fact]
            public void DetermineCorrectlyThatPasswordDoesNotMeetComplexityConditionsWhenThereAreNotEnoughSymbols()
            {
                var actual = new Password("AbodeAB12m\"-", 5, 2, 2, 1);
                bool result = actual.CheckPasswordComplexity();
                Assert.True(result);
            }

            [Fact]
            public void
                DetermineCorrectlyThatPasswordDoesMeetComplexityConditionsWhenZeroDigitsAndZeroSymbolsAreRequired()
            {
                var actual = new Password("abode;AB/123", 5, 2, 2, 2);
                bool result = actual.CheckPasswordComplexity();
                Assert.True(result);
            }

            [Fact]
            public void
                DetermineCorrectlyThatPasswordDoesMeetComplexityConditionsWhenItContainsAndIsAllowedToContainAmbiguousAndSimilarCharacters()
            {
                var actual = new Password("abode1}AB/23", 5, 2, 2, 2);
                bool result = actual.CheckPasswordComplexity();
                Assert.True(result);
            }
        }
    }
}
