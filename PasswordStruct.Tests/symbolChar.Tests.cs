using Xunit;

namespace PasswordStruct.Tests
{
    public class SymbolCharTests
    {
        [Fact]
        public void ForPasswordShouldReturnTrue()
        {
            var character = new SymbolChar('a');
            IMatch actual = character.Match("abode>>AB12+-");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForPasswordShouldReturnRemainingInput()
        {
            var character = new SymbolChar('a');
            const string password = "abode>>AB12+-";
            IMatch actual = character.Match(password);
            Assert.Equal("bode>>AB12+-", actual.RemainingText());
        }

        [Fact]
        public void ForPasswordShouldReturnFalse()
        {
            var character = new SymbolChar('b');
            const string password = "abode>>AB12+-";
            IMatch actual = character.Match(password);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForPasswordShouldReturnInput()
        {
            var character = new SymbolChar('b');
            const string password = "abode>>AB12+-";
            IMatch actual = character.Match(password);
            Assert.Equal("abode>>AB12+-", actual.RemainingText());
        }

        [Fact]
        public void ForEmptyStringShouldReturnFalse()
        {
            var character = new SymbolChar('f');
            const string password = "";
            IMatch actual = character.Match(password);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForEmptyStringShouldReturnEmptyString()
        {
            var character = new SymbolChar('f');
            const string password = "";
            IMatch actual = character.Match(password);
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void ForNullShouldReturnFalse()
        {
            var character = new SymbolChar('f');
            const string password = null;
            IMatch actual = character.Match(password);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForNullShouldReturnNull()
        {
            var character = new SymbolChar('f');
            const string password = null;
            IMatch actual = character.Match(password);
            Assert.Null(actual.RemainingText());
        }
    }
}