namespace PasswordStruct
{
    public class Sequance : IPattern
    {
        readonly IPattern[] patterns;

        public Sequance(params IPattern[] character)
        {
            this.patterns = character;
        }

        public IMatch Match(string password)
        {
            IMatch match = new Match(true, password);
            foreach (var pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());
                if (!match.Succes())
                {
                    return new Match(false, password);
                }
            }

            return match;
        }
    }
}
