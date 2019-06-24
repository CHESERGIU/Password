namespace PasswordStruct.Tests
{
    using Xunit;

    public class CharacterTests
    {
        [Fact]
        public void ForABCShouldReturnTrue()
        {
            var character = new Character('a');
            const string password = "abode>>AB12+-";
            IMatch actual = character.Match(password);
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForABCShouldReturnbc()
        {
            var character = new Character('a');
            const string password = "abode>>AB12+-";
            IMatch actual = character.Match(password);
            Assert.Equal("bode>>AB12+-", actual.RemainingText());
        }

        [Fact]
        public void ForABCShouldReturnFalse()
        {
            var character = new Character('b');
            const string password = "abode>>AB12+-";
            IMatch actual = character.Match(password);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForABCShouldReturnabc()
        {
            var character = new Character('b');
            const string password = "abode>>AB12+-";
            IMatch actual = character.Match(password);
            Assert.Equal("abode>>AB12+-", actual.RemainingText());
        }

        [Fact]
        public void ForEmptyStringShouldReturnFalse()
        {
            var character = new Character('f');
            const string password = "";
            IMatch actual = character.Match(password);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForEmptyStringShouldReturnEmptyString()
        {
            var character = new Character('f');
            const string password = "";
            IMatch actual = character.Match(password);
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void ForNullShouldReturnFalse()
        {
            var character = new Character('f');
            const string password = null;
            IMatch actual = character.Match(password);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForNullShouldReturnNull()
        {
            var character = new Character('f');
            const string password = null;
            IMatch actual = character.Match(password);
            Assert.Null(actual.RemainingText());
        }
    }
}
