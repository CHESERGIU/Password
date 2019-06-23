namespace PasswordStruct
{
    public class SymbolChar
    {
        public static readonly string SymbolCharValue = "!@#static $%^&*()-_=+`~,./?><;:\\'\\[{}]";

        readonly char character;

        public SymbolChar(char character)
        {
            this.character = character;
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
