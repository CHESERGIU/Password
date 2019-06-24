namespace PasswordStruct
{
    public class OneOrMore : IPattern
    {
        private readonly Sequance sequance;

        public OneOrMore(IPattern character)
        {
             this.sequance = new Sequance(character, new Many(character));
        }

        public IMatch Match(string password)
        {
            return sequance.Match(password);
        }
    }
}
