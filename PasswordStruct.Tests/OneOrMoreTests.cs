using Xunit;

namespace PasswordStruct.Tests
{
    public class OneOrMoreTests
    {
        [Fact]
        public void ShouldConsumeTheFirstCharacterFromString()
        {
            var a = new OneOrMore(new Character('a'));
            IMatch actual = a.Match("abc");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ShouldConsumeTheFirstCharacterFromStringWithRemainingTestbc()
        {
            var a = new OneOrMore(new Character('a'));
            IMatch actual = a.Match("abc");
            Assert.Equal("bc", actual.RemainingText());
        }

        [Fact]
        public void ShouldConsumeMoreCharactersFromString()
        {
            var a = new OneOrMore(new Character('a'));
            IMatch actual = a.Match("aaabc");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ShouldConsumeMoreCharactersFromStringWithRemainingTestbc()
        {
            var a = new OneOrMore(new Character('a'));
            IMatch actual = a.Match("aaabc");
            Assert.Equal("bc", actual.RemainingText());
        }

        [Fact]
        public void ShouldReturnFalseWhenNoCharacterIsConsumed()
        {
            var a = new OneOrMore(new Character('a'));
            IMatch actual = a.Match("bc");
            Assert.False(actual.Succes());
        }

        [Fact]
        public void WhenNoCharacterIsConsumedShouldReturnInitialText()
        {
            var a = new OneOrMore(new Character('a'));
            IMatch actual = a.Match("bc");
            Assert.Equal("bc", actual.RemainingText());
        }
    }
}
