using JogaFacil.Domain.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace JogaFacil.Infrastructure.Security.Cryptography
{
    public class BCrypt : IPasswordEncrypter
    {
        public string Encrypt(string password)
        {
            string passwordHase = BC.HashPassword(password);
            return passwordHase;
        }

        public bool Verify(string password, string passwordHase)
        {
            return BC.Verify(password, passwordHase);
        }
    }
}
