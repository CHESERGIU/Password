namespace PasswordStruct
{
    public class Any : IPattern
    {
        readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return new Match(false, password);
            }

            int indexOfFirstCharText = accepted.IndexOf(password[0]);

            return indexOfFirstCharText >= 0 ?
               new Match(true, password.Substring(1)) : new Match(false, password);
        }
    }
}
