namespace PasswordStruct
{
    public class PasswordText
    {
        readonly string prefix;

        public PasswordText(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string password)
        {
            if (string.IsNullOrEmpty(this.prefix))
            {
                return password == null
                    ? new Match(false, password)
                    : new Match(true, password);
            }

            if (string.IsNullOrEmpty(password) || password.Length < this.prefix.Length)
            {
                return new Match(false, password);
            }

            bool textPrefix = password.StartsWith(this.prefix);

            return textPrefix
                ? new Match(true, password.Substring(this.prefix.Length))
                : new Match(false, password);
        }
    }
}
