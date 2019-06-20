using System;

namespace PasswordStruct
{
    public static class Program
    {
        private static void Main()
        {
            var password = Console.ReadLine();
            var minSmallLetter = Convert.ToInt32(Console.ReadLine());
            var minBigLetter = Convert.ToInt32(Console.ReadLine());
            var minNumbers = Convert.ToInt32(Console.ReadLine());
            var minSymbols = Convert.ToInt32(Console.ReadLine());
            var similarChars = bool.Parse(Console.ReadLine());
            var ambiguousChars = bool.Parse(Console.ReadLine());

            var toCheck = new Password(password, minSmallLetter, minBigLetter, minNumbers, minSymbols);
            Console.WriteLine(toCheck.CheckPasswordComplexity());
            Console.ReadKey();
        }
    }
}