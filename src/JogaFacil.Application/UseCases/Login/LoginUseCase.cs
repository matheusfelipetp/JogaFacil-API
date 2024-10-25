using JogaFacil.Comunication.Requests.Login;
using JogaFacil.Comunication.Responses;
using JogaFacil.Domain.Cryptography;
using JogaFacil.Domain.Repositories.User;
using JogaFacil.Domain.Token;
using JogaFacil.Exception.ExceptionsBase;

namespace JogaFacil.Application.UseCases.Login
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IUserReadOnlyRepository _repository;
        private readonly IPasswordEncrypter _passwordEncripter;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public LoginUseCase(
            IUserReadOnlyRepository repository,
            IPasswordEncrypter passwordEncripter,
            IJwtTokenGenerator tokenGenerator
            )
        {
            _passwordEncripter = passwordEncripter;
            _repository = repository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResponseRegisterUserJson> Execute(RequestLoginJson request)
        {
            var user = await _repository.GetUserByEmail(request.Email);

            if (user is null)
            {
                throw new InvalidLoginException();
            }

            var passwordMatch = _passwordEncripter.Verify(request.Password, user.Password);

            if (!passwordMatch)
            {
                throw new InvalidLoginException();
            }

            return new ResponseRegisterUserJson
            {
                Name = user.Name,
                Token = _tokenGenerator.Generate(user)
            };
        }
    }
}
