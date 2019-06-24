using Xunit;

namespace PasswordStruct.Tests
{
    public class SequanceTests
    {
        [Fact]
        public void ForabcdForabShouldReturnTrue()
        {
            var ab = new Sequance(
                new Character('a'),
                new Character('b'));

            IMatch actual = ab.Match("abcd");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForabcdForabShouldReturncdForTrue()
        {
            var ab = new Sequance(
                new Character('a'),
                new Character('b'));

            IMatch actual = ab.Match("abcd");
            Assert.Equal("cd", actual.RemainingText());
        }

        [Fact]
        public void FordefForabShouldReturnFalse()
        {
            var ab = new Sequance(
                new Character('a'),
                new Character('b'));

            IMatch actual = ab.Match("def");
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForStringdefForabShouldReturndefWhenFalse()
        {
            var ab = new Sequance(
                new Character('a'),
                new Character('b'));

            IMatch actual = ab.Match("def");
            Assert.Equal("def", actual.RemainingText());
        }

        [Fact]
        public void ForEmptyStringShouldReturnFalse()
        {
            var ab = new Sequance(
                new Character('a'),
                new Character('b'));

            IMatch actual = ab.Match("");
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForEmptyStringShouldReturnEmptyString()
        {
            var ab = new Sequance(
                new Character('a'),
                new Character('b'));

            IMatch actual = ab.Match("");
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void ForNullShouldReturnfalse()
        {
            var ab = new Sequance(
                new Character('a'),
                new Character('b'));

            IMatch actual = ab.Match(null);
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForNullShouldReturnNull()
        {
            var ab = new Sequance(
                new Character('a'),
                new Character('b'));

            IMatch actual = ab.Match(null);
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void Foru1234ShouldReturnEmptyString()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F'));

            var hexSeq = new Sequance(
                new Character('u'),
                new Sequance(
                    hex,
                    hex,
                    hex,
                    hex));

            IMatch actual = hexSeq.Match("u1234");
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void ForuabcdefShouldReturnef()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F'));

            var hexSeq = new Sequance(
                new Character('u'),
                new Sequance(
                    hex,
                    hex,
                    hex,
                    hex));

            IMatch actual = hexSeq.Match("uabcdef");
            Assert.Equal("ef", actual.RemainingText());
        }

        [Fact]
        public void ForuabcdefShouldReturntrue()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F'));

            var hexSeq = new Sequance(
                new Character('u'),
                new Sequance(
                    hex,
                    hex,
                    hex,
                    hex));

            IMatch actual = hexSeq.Match("uabcdef");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForuB005abShouldReturntrue()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F'));

            var hexSeq = new Sequance(
                new Character('u'),
                new Sequance(
                    hex,
                    hex,
                    hex,
                    hex));

            IMatch actual = hexSeq.Match("uB005 ab");
            Assert.True(actual.Succes());
        }

        [Fact]
        public void ForuB005abShouldReturnab()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F'));

            var hexSeq = new Sequance(
                new Character('u'),
                new Sequance(
                    hex,
                    hex,
                    hex,
                    hex));

            IMatch actual = hexSeq.Match("uB005 ab");
            Assert.Equal(" ab", actual.RemainingText());
        }

        [Fact]
        public void ForabcShouldReturnfalse()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F'));

            var hexSeq = new Sequance(
                new Character('u'),
                new Sequance(
                    hex,
                    hex,
                    hex,
                    hex));

            IMatch actual = hexSeq.Match("abc");
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForabcShouldReturnabc()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F'));

            var hexSeq = new Sequance(
                new Character('u'),
                new Sequance(
                    hex,
                    hex,
                    hex,
                    hex));

            IMatch actual = hexSeq.Match("abc");
            Assert.Equal("abc", actual.RemainingText());
        }

        [Fact]
        public void ForNullHexShouldReturnNull()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F'));

            var hexSeq = new Sequance(
                new Character('u'),
                new Sequance(
                    hex,
                    hex,
                    hex,
                    hex));

            IMatch actual = hexSeq.Match(null);
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void ForaxStringabcCharactershoudReturnFalse()
        {
            var ab = new Sequance(
            new Character('a'),
            new Character('b'));

            var abc = new Sequance(
            ab,
            new Character('c'));

            IMatch actual = abc.Match("ax");
            Assert.False(actual.Succes());
        }

        [Fact]
        public void ForaxStringabcCharactershoudReturnFalseAndax()
        {
            var ab = new Sequance(
            new Character('a'),
            new Character('b'));

            var abc = new Sequance(
            ab,
            new Character('c'));

            IMatch actual = abc.Match("ax");
            Assert.Equal("ax", actual.RemainingText());
        }
    }
}
