using System.Linq;

namespace PasswordStruct
{
    public class Password
    {
        private readonly string symbolChar = "!@#$%^&*()-_=+`~,./?><;:\\'\\[{}]";
        private readonly char[] similarChar = { 'l', '1', 'I', 'o', '0', 'O' };
        private readonly char[] ambiguousChar = { '{', '}', '[', ']', '(', ')', '/', '\'', '"', '~', ';', '.', '<', '>' };
        private readonly string password;
        private readonly int minSmallLetter;
        private readonly int minBigLetter;
        private readonly int minNumbers;
        private readonly int minSymbols;

        public Password()
        {
        }

        public Password(string password, int minSmallLetter, int minBigLetter, int minNumbers, int minSymbols)
        {
            this.password = password;
            this.minSmallLetter = minSmallLetter;
            this.minBigLetter = minBigLetter;
            this.minNumbers = minNumbers;
            this.minSymbols = minSymbols;
        }

        public bool CheckPasswordComplexity()
        {
            return HasLower() && HasUpper() && HasDigit() && HasSymbols();
        }

        public bool HasSymbols()
        {
            int symbol = (from c in password from chr in symbolChar where chr == c select c).Count();

            return symbol >= minSymbols;
        }

        public bool HasLower()
        {
            int lowerCaseLetters = password.Count(char.IsLower);

            return lowerCaseLetters >= minSmallLetter;
        }

        public bool HasUpper()
        {
            int upperCaseLetters = password.Count(char.IsUpper);

            return upperCaseLetters >= minBigLetter;
        }

        public bool HasDigit()
        {
            int digit = password.Count(char.IsDigit);

            return digit >= minNumbers;
        }

        public bool HasSimilarChar()
        {
            return (from c in password from chr in similarChar where chr == c select c).Any();
        }

        public bool HasAmbiguousChars()
        {
            return (from c in password from chr in ambiguousChar where chr == c select c).Any();
        }
    }
}