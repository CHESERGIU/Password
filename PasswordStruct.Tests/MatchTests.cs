using Xunit;

namespace PasswordStruct.Tests
{
    public class MatchTests
    {
        [Fact]
        public void SuccesShouldReturnTrue()
        {
            Match match = new Match(true, "abc");
            bool actual = match.Succes();
            Assert.True(actual);
        }

        [Fact]
        public void SuccesShouldReturnFalse()
        {
            Match match = new Match(false, "abc");
            bool actual = match.Succes();
            Assert.False(actual);
        }

        [Fact]
        public void SuccesShouldReturnRemainingTextabc()
        {
            Match match = new Match(false, "abc");
            string actual = match.RemainingText();
            Assert.Equal("abc", actual);
        }
    }
}
