using JogaFacil.Domain.Entities;

namespace JogaFacil.Domain.Token
{
    public interface IJwtTokenGenerator
    {
        string Generate(User user);
    }
}
