using Xunit;

namespace PasswordStruct.Tests
{
    public class TextTests
    {
        [Fact]
        public void ConstructorTrueAndTextTrueShouldReturnTrue()
        {
            var isTrue = new PasswordText("true");
            IMatch actual = isTrue.Match("true");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForConstructorTrueAndTextTrueShouldReturnEmptyString()
        {
            var isTrue = new PasswordText("true");
            IMatch actual = isTrue.Match("true");
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void ForConstructorTrueAndTextTruexShouldReturnTrue()
        {
            var isTrue = new PasswordText("true");
            IMatch actual = isTrue.Match("truex");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForConstructorTrueAndTextTruexShouldReturnx()
        {
            var isTrue = new PasswordText("true");
            IMatch actual = isTrue.Match("truex");
            Assert.Equal("x", actual.RemainingText());
        }

        [Fact]
        public void ForConstructorTrueAndTextFalseShouldReturnFalse()
        {
            var isTrue = new PasswordText("true");
            IMatch actual = isTrue.Match("false");
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForConstructorTrueAndTextFalseShouldReturnTextfalse()
        {
            var isTrue = new PasswordText("true");
            IMatch actual = isTrue.Match("false");
            Assert.Equal("false", actual.RemainingText());
        }

        [Fact]
        public void ForConstructorTrueAndTextEmptyStringShouldReturnFalse()
        {
            var isTrue = new PasswordText("true");
            IMatch actual = isTrue.Match("");
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForConstructorTrueAndTextEmptyStringShouldReturnEmptyString()
        {
            var isTrue = new PasswordText("true");
            IMatch actual = isTrue.Match(string.Empty);
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void ForConstructorTrueAndTextNullShouldReturnFalse()
        {
            var isTrue = new PasswordText("true");
            IMatch actual = isTrue.Match(null);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForConstructorTrueAndTextNUllShouldReturnnull()
        {
            var isTrue = new PasswordText("true");
            IMatch actual = isTrue.Match(null);
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void ForConstructorFalseAndTextFalseShouldReturnTrue()
        {
            var isFalse = new PasswordText("false");
            IMatch actual = isFalse.Match("false");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForConstructorTextFalseShouldReturnTrue()
        {
            var isFalse = new PasswordText("false");
            IMatch actual = isFalse.Match("False");
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForConstructorFalseAndTextFalseShouldReturnTextEmprtyString()
        {
            var isFalse = new PasswordText("false");
            IMatch actual = isFalse.Match("false");
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void ForConstructorFalseAndTextFalsexShouldReturnTrue()
        {
            var isFalse = new PasswordText("false");
            IMatch actual = isFalse.Match("falsex");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForConstructorFalseAndTextFalsexShouldReturnTextx()
        {
            var isFalse = new PasswordText("false");
            IMatch actual = isFalse.Match("falsex");
            Assert.Equal("x", actual.RemainingText());
        }

        [Fact]
        public void ForConstructorFalseAndTextTrueShouldReturnFalse()
        {
            var isFalse = new PasswordText("false");
            IMatch actual = isFalse.Match("true");
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForConstructorFalseAndTextTrueShouldReturnTexttrue()
        {
            var isFalse = new PasswordText("false");
            IMatch actual = isFalse.Match("true");
            Assert.Equal("true", actual.RemainingText());
        }

        [Fact]
        public void ForConstructorFalseAndTextEmptyStringShouldReturnFalse()
        {
            var isFalse = new PasswordText("false");
            IMatch actual = isFalse.Match(string.Empty);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForConstructorFalseAndTextEmptyStringShouldReturnEmptyString()
        {
            var isFalse = new PasswordText("false");
            IMatch actual = isFalse.Match(string.Empty);
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void ForConstructorFalseAndTextNullShouldReturnFalse()
        {
            var isFalse = new PasswordText("false");
            IMatch actual = isFalse.Match(null);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForConstructorFalseAndTextNullShouldReturnNull()
        {
            var isFalse = new PasswordText("false");
            IMatch actual = isFalse.Match(null);
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void ForConstructorEmptyStringAndTextTrueShouldReturnTrue()
        {
            var isFalse = new PasswordText(string.Empty);
            IMatch actual = isFalse.Match("true");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForConstructorEmptyStringAndTextTrueShouldReturnTextTrue()
        {
            var isFalse = new PasswordText(string.Empty);
            IMatch actual = isFalse.Match("true");
            Assert.Equal("true", actual.RemainingText());
        }

        [Fact]
        public void ForConstructorEmptyStringAndTextNullShouldReturnFalse()
        {
            var isFalse = new PasswordText(string.Empty);
            IMatch actual = isFalse.Match(null);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForConstructorEmptyStringAndTextNullShouldReturnnull()
        {
            var isFalse = new PasswordText(string.Empty);
            IMatch actual = isFalse.Match(null);
            Assert.Null(actual.RemainingText());
        }
    }
}
