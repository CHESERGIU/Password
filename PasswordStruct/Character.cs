namespace PasswordStruct
{
    public class Character : IPattern
    {
        readonly char character;

        public Character(char pattern)
        {
            this.character = pattern;
        }

        public IMatch Match(string password)
        {
            if (string.IsNullOrEmpty(password)
                || password[0] != character)
            {
                return (IMatch)new Match(false, password);
            }

            return new Match(true, password.Substring(1));
        }
    }
}