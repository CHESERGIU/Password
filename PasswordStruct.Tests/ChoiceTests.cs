using Xunit;

namespace PasswordStruct.Tests
{
    public class ChoiceTests
    {
        [Fact]
        public void ShouldReturnTrueForDigit0()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));
            IMatch actual = digit.Match("024");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ShouldReturnTheRestOfThetextForTrueForDigit0()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));
            IMatch actual = digit.Match("024");
            Assert.Equal("24", actual.RemainingText());
        }

        [Fact]
        public void ShouldReturnTrueForRange1To9()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));
            IMatch actual = digit.Match("12");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ShouldReturnRemainingTextForTrueForRange1To9()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));
            IMatch actual = digit.Match("12");
            Assert.Equal("2", actual.RemainingText());
        }

        [Fact]
        public void ShouldReturnTrueForA9Hex()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            var hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')));

            IMatch actual = hex.Match("A9");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ShouldReturnRestOfTextForTrueFor269Hex()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            var hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')));

            IMatch actual = hex.Match("269");
            Assert.Equal("69", actual.RemainingText());
        }

        [Fact]
        public void ShouldReturnFalseForg8Hex()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            var hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')));

            IMatch actual = hex.Match("g8");
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ShouldReturnRemainingTextForFalseForg8Hex()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            var hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')));

            IMatch actual = hex.Match("g8");
            Assert.Equal("g8", actual.RemainingText());
        }

        [Fact]
        public void ShouldReturnFalseForEmptyStringHex()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            var hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')));

            IMatch actual = hex.Match(string.Empty);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ShouldReturnEmptyStringForFalseForEmptyStringHex()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            var hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')));

            IMatch actual = hex.Match(string.Empty);
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void ShouldReturnFalseForNullHex()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            var hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')));

            IMatch actual = hex.Match(null);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ShouldReturnNullForNullHex()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            var hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')));

            IMatch actual = hex.Match(null);
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void ShouldReturnEmptyStringForTrueFor8Hex()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            var hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')));

            IMatch actual = hex.Match("8");
            Assert.Equal(string.Empty, actual.RemainingText());
        }
    }
}
