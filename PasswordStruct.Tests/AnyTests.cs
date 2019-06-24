namespace PasswordStruct.Tests
{
    using Xunit;

    public class AnyTests
    {
        [Fact]
        public void ForStringShouldReturnTrue()
        {
            Any password = new Any("abode>>AB12+-");
            IMatch actual = password.Match("ab");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForStringShouldReturnRemainingText()
        {
            var password = new Any("abode>>AB12+-");
            IMatch actual = password.Match("b");
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void ForStringShouldReturnTrueEqual()
        {
            var password = new Any("abode>>AB12+-");
            IMatch actual = password.Match("ab");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForStringInputShouldReturnRemainingPassword()
        {
            var password = new Any("abode>>AB12+-");
            IMatch actual = password.Match("ab");
            Assert.Equal("b", actual.RemainingText());
        }

        [Fact]
        public void ForStringShouldReturnFalse()
        {
            var password = new Any("abode>>AB12+-");
            IMatch actual = password.Match("c");
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForStringShouldReturnChar()
        {
            var password = new Any("abode>>AB12+-");
            IMatch actual = password.Match("a");
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void ForEmptyStringShouldReturnEmptyString()
        {
            var password = new Any("abode>>AB12+-");
            IMatch actual = password.Match(string.Empty);
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void ForEmptyStringShouldReturnFalse()
        {
            var password = new Any("");
            IMatch actual = password.Match(string.Empty);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void WhenConstructorStringMinusAndPlusAndStringPlus3ShouldReturnTrue()
        {
            var sign = new Any("-+");
            IMatch actual = sign.Match("+3");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void WhenConstructorStringMinusAndPlusAndStringPlus3ShouldReturn3()
        {
            var sign = new Any("-+");
            IMatch actual = sign.Match("+3");
            Assert.Equal("3", actual.RemainingText());
        }

        [Fact]
        public void WhenConstructorStringMinusAndPlusAndStringMinus2ShouldReturnTrue()
        {
            var sign = new Any("-+");
            IMatch actual = sign.Match("-2");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void WhenConstructorStringMinusAndPlusAndStringMinus2ShouldReturn2()
        {
            var sign = new Any("-+");
            IMatch actual = sign.Match("-2");
            Assert.Equal("2", actual.RemainingText());
        }

        [Fact]
        public void WhenConstructorStringMinusAndPlusAndString2ShouldReturnFalse()
        {
            var sign = new Any("-+");
            IMatch actual = sign.Match("2");
            Assert.False(actual.Succes());
        }

        [Fact]
        public void WhenConstructorStringMinusAndPlusAndString2ShouldReturn2()
        {
            var sign = new Any("-+");
            IMatch actual = sign.Match("2");
            Assert.Equal("2", actual.RemainingText());
        }

        [Fact]
        public void WhenConstructorStringMinusAndPlusAndStringNullShouldReturnFalse()
        {
            var sign = new Any("-+");
            IMatch actual = sign.Match(null);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void WhenConstructorStringMinusAndPlusAndStringNullShouldReturnNull()
        {
            var sign = new Any("-+");
            IMatch actual = sign.Match(null);
            Assert.Null(actual.RemainingText());
        }
    }
}
