using Xunit;

namespace PasswordStruct.Tests
{
    public class ManyTests
    {
        [Fact]
        public void ForIPatternCharaAndStringabcShouldReturnTrue()
        {
            var a = new Many(new Character('a'));
            IMatch actual = a.Match("abc");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForIPatternCharaAndStringabcShouldReturnStringbc()
        {
            var a = new Many(new Character('a'));
            IMatch actual = a.Match("abc");
            Assert.Equal("bc", actual.RemainingText());
        }

        [Fact]
        public void ForIPatternCharaAndStringaaaabcShouldReturnTrue()
        {
            var a = new Many(new Character('a'));
            IMatch actual = a.Match("aaaabc");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForIPatternCharaAndStringaaaabcShouldReturnStringbc()
        {
            var a = new Many(new Character('a'));
            IMatch actual = a.Match("aaaabc");
            Assert.Equal("bc", actual.RemainingText());
        }

        [Fact]
        public void ForIPatternCharaAndStringbcShouldReturnTrue()
        {
            var a = new Many(new Character('a'));
            IMatch actual = a.Match("bc");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForIPatternCharaAndStringbcShouldReturnStringbc()
        {
            var a = new Many(new Character('a'));
            IMatch actual = a.Match("bc");
            Assert.Equal("bc", actual.RemainingText());
        }

        [Fact]
        public void ForIPatternCharaAndStringEmptyStringShouldReturnTrue()
        {
            var a = new Many(new Character('a'));
            IMatch actual = a.Match(string.Empty);
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForIPatternCharaAndStringEmptyStringShouldReturnStringEmptyString()
        {
            var a = new Many(new Character('a'));
            IMatch actual = a.Match(string.Empty);
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void ForIPatternRange09AndString12345ab123ShouldReturnTrue()
        {
            var digits = new Many(new Range('0', '9'));
            IMatch actual = digits.Match("12345ab123");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForIPatternRange09AndString12345ab123ShouldReturnab123()
        {
            var digits = new Many(new Range('0', '9'));
            IMatch actual = digits.Match("12345ab123");
            Assert.Equal("ab123", actual.RemainingText());
        }

        [Fact]
        public void ForIPatternRange09AndStringabShouldReturnTrue()
        {
            var digits = new Many(new Range('0', '9'));
            IMatch actual = digits.Match("ab");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForIPatternRange09AndStringabShouldReturnab()
        {
            var digits = new Many(new Range('0', '9'));
            IMatch actual = digits.Match("ab");
            Assert.Equal("ab", actual.RemainingText());
        }
    }
}
