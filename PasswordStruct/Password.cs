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
            return HasLower() && HasUpper() && HasDigit() && HasSymbols() && HasSimilarChar() && HasAmbiguousChars();
        }

        public bool HasSymbols()
        {
            int symbol = 0;
            for (int i = 0; i < password.Length; i++)
            {
                char c = password[i];
                foreach (char chr in symbolChar)
                {
                    if (chr == c)
                    {
                        symbol++;
                    }
                }
            }

            return symbol >= minSymbols;
        }

        public bool HasLower()
        {
            int lowerCaseLetters = 0;
            for (int i = 0; i < password.Length; i++)
            {
                char c = password[i];
                if (char.IsLower(c))
                {
                    lowerCaseLetters++;
                }
            }

            return lowerCaseLetters >= minSmallLetter;
        }

        public bool HasUpper()
        {
            int upperCaseLetters = 0;
            for (int i = 0; i < password.Length; i++)
            {
                char c = password[i];
                if (char.IsUpper(c))
                {
                    upperCaseLetters++;
                }
            }

            return upperCaseLetters >= minBigLetter;
        }

        public bool HasDigit()
        {
            int digit = 0;
            for (int i = 0; i < password.Length; i++)
            {
                char c = password[i];
                if (char.IsDigit(c))
                {
                    digit++;
                }
            }

            return digit >= minNumbers;
        }

        public bool HasSimilarChar()
        {
            for (int i = 0; i < password.Length; i++)
            {
                char c = password[i];
                foreach (char chr in similarChar)
                {
                    if (chr == c)
                    {
                        return true;
                    }
                        
                }
            }
            return false;
        }

        public bool HasAmbiguousChars()
        {
            for (int i = 0; i < password.Length; i++)
            {
                char c = password[i];
                foreach (char chr in ambiguousChar)
                {
                    if (chr == c)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}