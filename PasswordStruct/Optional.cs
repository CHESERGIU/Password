namespace PasswordStruct
{
    public class IOptional : System.IEquatable<IOptional>
    {
        readonly IPattern character;

        public IOptional(IPattern pattern)
        {
            this.character = pattern;
        }

        public IMatch Match(string password)
        {
            IMatch match = new Match(true, password);
            match = this.character.Match(match.RemainingText());

            return new Match(true, match.RemainingText());
        }

        public bool Equals(IOptional other)
        {
            return true;
        }
    }
}
