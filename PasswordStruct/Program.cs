using System;

namespace PasswordCheck
{
    public static class Program
    {        
        public struct Password
        {
            public string password;
            public int minSmallLetter;
            public int minBigLetter;
            public int minNumbers;
            public int minSymbols;


            public Password(string password, int minSmallLetter, int minBigLetter, int minNumbers, int minSymbols)
            {
                this.password = password;
                this.minSmallLetter = minSmallLetter;
                this.minBigLetter = minBigLetter;
                this.minNumbers = minNumbers;
                this.minSymbols = minSymbols;
            }
        }
        static void Main(string[] args)
        {
            string input;
            int minSmallLetter, minBigLetter, minNumbers, minSymbols;
            bool similarChars, ambiguousChars;
            ReadInput(out input, out minSmallLetter, out minBigLetter, out minNumbers, out minSymbols, out similarChars, out ambiguousChars);

            Password passwordToCheck;
            passwordToCheck.password = input;
            passwordToCheck.minSmallLetter = minSmallLetter;
            passwordToCheck.minBigLetter = minBigLetter;
            passwordToCheck.minNumbers = minNumbers;
            passwordToCheck.minSymbols = minSymbols;
            char[] symbolChar = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '`', '~', ',', '.', '/', '?', '>', '<', ';', ':', '"', '\'', '\\', '[', '{', '}', ']' };
            char[] similarChar = { 'l', '1', 'I', 'o', '0', 'O' };
            char[] ambiguousChar = { '{', '}', '[', ']', '(', ')', '/', '\'', '"', '~', ';', '.', '<', '>' };
            object value = CheckPasswordComplexity(similarChars, ambiguousChars, passwordToCheck, symbolChar, similarChar, ambiguousChar);
            Print(value);

        }

        public static bool CheckPasswordComplexity(bool similarChars, bool ambiguousChars, Password passwordToCheck, char[] symbolChar, char[] similarChar, char[] ambiguousChar)
        {
            if ((HasLower(passwordToCheck) == true) && (HasUpper(passwordToCheck) == true) && (HasDigit(passwordToCheck) == true) && (HasSymbols(passwordToCheck, symbolChar) == true) && (HasSimilarChar(passwordToCheck, similarChar, similarChars) == true) && (HasAmbiguousChars(passwordToCheck, ambiguousChar, ambiguousChars) == true))
                return true;
            else
                return false;
        }
        public static void Print(object value)
        {
            Console.WriteLine(value);            
            Console.ReadKey();
        }

        public static bool HasSymbols(Password passwordToCheck, char[] symbolChar)
        {
            int symbol = 0;
            for (int i = 0; i < passwordToCheck.password.Length; i++)
            {
                char c = passwordToCheck.password[i];
                foreach (char chr in symbolChar)
                {
                    if (chr == c) 
                        symbol++;
                }                   
            }
            if (symbol >= passwordToCheck.minSymbols)
                return true;
            return false;
        }
        public static bool HasLower(Password passwordToCheck)
        {
            int lowerCaseLetters = 0;
            for (int i = 0; i < passwordToCheck.password.Length; i++)
            {
                char c = passwordToCheck.password[i];
                if (char.IsLower(c))
                    lowerCaseLetters++;
            }
            if (lowerCaseLetters >= passwordToCheck.minSmallLetter)
                return true;
            return false;
        }
        public static bool HasUpper(Password passwordToCheck)
        {
            int upperCaseLetters = 0;
            for (int i = 0; i < passwordToCheck.password.Length; i++)
            {
                char c = passwordToCheck.password[i];
                if (char.IsUpper(c))
                    upperCaseLetters++;
            }
            if (upperCaseLetters >= passwordToCheck.minBigLetter)
                return true;
            return false;
        }
        public static bool HasDigit(Password passwordToCheck)
        {
            int Digit = 0;
            for (int i = 0; i < passwordToCheck.password.Length; i++)
            {
                char c = passwordToCheck.password[i];
                if (char.IsDigit(c))
                    Digit++;
            }
            if (Digit >= passwordToCheck.minNumbers)
                return true;
            return false;
        }
        public static bool HasSimilarChar(Password passwordToCheck, char[] similarChar, bool similarChars)
        {
            for (int i = 0; i < passwordToCheck.password.Length; i++)
            {
                char c = passwordToCheck.password[i];
                foreach (char chr in similarChar)
                {
                    if ((chr == c) && (similarChars == false))
                        return false;
                    if ((chr == c) && (similarChars == true))
                        return true;
                }
            }
            return true;
        }
        public static bool HasAmbiguousChars(Password passwordToCheck, char[] ambiguousChar, bool ambiguousChars)
        {
            for (int i = 0; i < passwordToCheck.password.Length; i++)
            {
                char c = passwordToCheck.password[i];
                foreach (char chr in ambiguousChar)
                {
                    if ((chr == c) && (ambiguousChars == false))
                        return false;
                    if ((chr == c) && (ambiguousChars == true))
                        return true;
                }
            }
            return true;
        }

        private static void ReadInput(out string input, out int minSmallLetter, out int minBigLetter, out int minNumbers, out int minSymbols, out bool similarChars, out bool ambiguousChars)
        {
            input = Console.ReadLine();
            minSmallLetter = Convert.ToInt32(Console.ReadLine());
            minBigLetter = Convert.ToInt32(Console.ReadLine());
            minNumbers = Convert.ToInt32(Console.ReadLine());
            minSymbols = Convert.ToInt32(Console.ReadLine());
            similarChars = bool.Parse(Console.ReadLine());
            ambiguousChars = bool.Parse(Console.ReadLine());
        }
    }
}
