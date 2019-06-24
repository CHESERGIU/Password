namespace PasswordStruct
{
    public interface IPattern
    {
        IMatch Match(string password);
    }
}