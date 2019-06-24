using Xunit;

namespace PasswordStruct.Tests
{
    public class OptionalTests
    {
        private const string Text = "abc";

        [Fact]
        public void ForCharacterAAndStringAbcShouldReturnTrue()
        {
            IOptional a = new IOptional(new Character('a'));
            IMatch actual = a.Match(Text);
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForCharacteraandStringabcShouldReturnbc()
        {
            var a = new IOptional(new Character('a'));
            IMatch actual = a.Match("abc");
            Assert.Equal("bc", actual.RemainingText());
        }

        [Fact]
        public void ForCharacteraandStringaabcShouldReturnTrue()
        {
            var a = new IOptional(new Character('a'));
            IMatch actual = a.Match("aabc");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForCharacteraandStringaabcShouldReturnabc()
        {
            var a = new IOptional(new Character('a'));
            IMatch actual = a.Match("aabc");
            Assert.Equal("abc", actual.RemainingText());
        }

        [Fact]
        public void ForCharacteraandStringbcShouldReturnTrue()
        {
            var a = new IOptional(new Character('a'));
            IMatch actual = a.Match("bc");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForCharacteraandStringbcShouldReturnbc()
        {
            var a = new IOptional(new Character('a'));
            IMatch actual = a.Match("bc");
            Assert.Equal("bc", actual.RemainingText());
        }

        [Fact]
        public void ForCharacteraandStringEmptyStringShouldReturnTrue()
        {
            var a = new IOptional(new Character('a'));
            IMatch actual = a.Match(string.Empty);
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForCharacteraandStringEmptyStringShouldReturnEmptyString()
        {
            var a = new IOptional(new Character('a'));
            IMatch actual = a.Match(string.Empty);
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void ForCharacteraandStringnullShouldReturnTrue()
        {
            var a = new IOptional(new Character('a'));
            IMatch actual = a.Match(null);
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForCharacteraandStringnullShouldReturnnull()
        {
            var a = new IOptional(new Character('a'));
            IMatch actual = a.Match(null);
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void ForCharacterMinusandString123ShouldReturntrue()
        {
            var sign = new IOptional(new Character('-'));
            IMatch actual = sign.Match("123");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForCharacterMinusandString123ShouldReturn123()
        {
            var a = new IOptional(new Character('-'));
            IMatch actual = a.Match("123");
            Assert.Equal("123", actual.RemainingText());
        }

        [Fact]
        public void ForCharacterMinusandStringMinus123ShouldReturntrue()
        {
            var sign = new IOptional(new Character('-'));
            IMatch actual = sign.Match("-123");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForCharacterMinusandStringMinus123ShouldReturn123()
        {
            var a = new IOptional(new Character('-'));
            IMatch actual = a.Match("-123");
            Assert.Equal("123", actual.RemainingText());
        }
    }
}
