using Xunit;

namespace PasswordStruct.Tests
{
    public class ListTests
    {
        [Fact]
        public void ItShouldConsumeAPatternAndACharacterReturningTrue()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            IMatch actual = a.Match("1");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ItShouldConsumeAPatternAndACharacterWithRemainingTextEmpty()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            IMatch actual = a.Match("1,");
            Assert.Equal(",", actual.RemainingText());
        }

        [Fact]
        public void ItShouldConsumeAllThePatternsAndCharactersReturningTrue()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            IMatch actual = a.Match("1,2,3");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ItShouldConsumeAllThePatternsAndCharactersWithRemainingTextEmpty()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            IMatch actual = a.Match("1,2,3");
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void ItShouldConsumeAllThePatternsAndCharactersExceptLastComaReturningTrue()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            IMatch actual = a.Match("1,2,3,");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ItShouldConsumeAllThePatternsAndCharactersReturningAComa()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            IMatch actual = a.Match("1,2,3,");
            Assert.Equal(",", actual.RemainingText());
        }

        [Fact]
        public void ForString1aItShouldConsumeOnlyThe1AndReturnTrue()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            IMatch actual = a.Match("1a");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForString1aItShouldConsumeOnlyThe1AndReturna()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            IMatch actual = a.Match("1a");
            Assert.Equal("a", actual.RemainingText());
        }

        [Fact]
        public void ForEmptyStringItShouldReturnEmptyString()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            IMatch actual = a.Match(string.Empty);
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void ForDigitsSeparatorsNewLineAndTabShouldReturnEmptyString()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequance(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            IMatch actual = list.Match("1; 22  ;\n 333 \t; 22");
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void ForNumberAndNewLineShouldReturnNewLine()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequance(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            IMatch actual = list.Match("1 \n");
            Assert.Equal(" \n", actual.RemainingText());
        }

        [Fact]
        public void ForStringabcShouldReturnabc()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequance(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            IMatch actual = list.Match("abc");
            Assert.Equal("abc", actual.RemainingText());
        }
    }
}
