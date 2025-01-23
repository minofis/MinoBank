namespace MinoBank.Core.Interfaces.Auth
{
    public interface IPasswordHasher
    {
        string Generate(string password);
        bool Verify(string hashedPassword, string password);
    }
}