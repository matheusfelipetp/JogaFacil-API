namespace JogaFacil.Domain.Cryptography
{
    public interface IPasswordEncrypter
    {
        string Encrypt(string password);
        bool Verify(string password, string passwordHase);
    }
}
