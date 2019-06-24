namespace PasswordStruct
{
    public class Choice : IPattern
    {
        readonly IPattern[] patterns;

        public Choice(params IPattern[] character)
        {
            this.patterns = character;
        }

        public IMatch Match(string password)
        {
            foreach (var pattern in this.patterns)
            {
                IMatch match = pattern.Match(password);
                if (match.Succes())
                {
                    return match;
                }
            }

            return new Match(false, password);
        }
    }
}
