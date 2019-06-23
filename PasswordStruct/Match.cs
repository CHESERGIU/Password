namespace PasswordStruct
{
    public class Match : IMatch
    {
        private readonly bool succes;
        private readonly string remainingText;

        public Match(bool succes, string remainingText)
        {
            this.succes = succes;
            this.remainingText = remainingText;
        }

        public string RemainingText()
        {
            return remainingText;
        }

        public bool Succes()
        {
            return succes;
        }
    }
}