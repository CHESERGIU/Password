namespace PasswordStruct
{
    public class Many : IPattern
    {
        readonly IPattern character;

        public Many(IPattern character)
        {
            this.character = character;
        }

        public IMatch Match(string password)
        {
            IMatch match = new Match(true, password);
            while (match.Succes())
            {
                match = this.character.Match(match.RemainingText());
            }

            return new Match(true, match.RemainingText());
        }
    }
}
