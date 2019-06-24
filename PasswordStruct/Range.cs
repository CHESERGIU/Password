namespace PasswordStruct
{
    public class Range : IPattern
    {
        readonly char start;
        readonly char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string password)
        {
            if (string.IsNullOrEmpty(password) || password[0] < start || password[0] > end)
            {
                return new Match(false, password);
            }

            if (password.Length == 1)
            {
                password = string.Empty;
                return new Match(true, password);
            }

            return new Match(true, password.Substring(1));
        }
    }
}