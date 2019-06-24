using System;
using Xunit;

namespace PasswordStruct.Tests
{
    public class RangeTests
    {
        [Fact]
        public void ForabcShouldReturnTrueFromRangeaTof()
        {
            var digits = new Range('a', 'f');
            const string password = "abc";
            IMatch actual = digits.Match(password);
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForabcShouldReturnbcFromRangeaTof()
        {
            var digits = new Range('a', 'f');
            const string password = "abc";
            IMatch actual = digits.Match(password);
            Assert.Equal("bc", actual.RemainingText());
        }

        [Fact]
        public void ForabcShouldReturnFalseFromRangebTof()
        {
            var digits = new Range('b', 'f');
            const string password = "abc";
            IMatch actual = digits.Match(password);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForabcShouldReturnabcFromRangebTof()
        {
            var digits = new Range('b', 'f');
            const string password = "abc";
            IMatch actual = digits.Match(password);
            Assert.Equal("abc", actual.RemainingText());
        }

        [Fact]
        public void ForEmptyconststringShouldReturnFalse()
        {
            var digits = new Range('a', 'f');
            const string password = "";
            IMatch actual = digits.Match(password);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForEmptyconststringShouldReturnEmptyconst()
        {
            var digits = new Range('a', 'f');
            const string password = "";
            IMatch actual = digits.Match(password);
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void ForNullShouldReturnFalse()
        {
            var digits = new Range('a', 'f');
            const string password = null;
            IMatch actual = digits.Match(password);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForNullShouldReturnNull()
        {
            var digits = new Range('a', 'f');
            const string password = null;
            IMatch actual = digits.Match(password);
            Assert.Null(actual.RemainingText());
        }
    }
}
