using System;

namespace PasswordStruct
{
    public class List : IPattern
    {
        readonly IPattern character;
        readonly IPattern separator;

        public List(IPattern pattern, IPattern separator)
        {
            this.character = pattern;
            this.separator = separator;
        }

        public IMatch Match(string password)
        {
            IMatch characterMatch = this.character.Match(password);
            IMatch separatorMatch;
            while (characterMatch.Succes())
            {
                separatorMatch = this.separator.Match(characterMatch.RemainingText());
                if (string.IsNullOrEmpty(separatorMatch.RemainingText()))
                {
                    return characterMatch;
                }

                characterMatch = this.character.Match(separatorMatch.RemainingText());
            }

            return new Match(true, characterMatch.RemainingText());
        }
    }
}