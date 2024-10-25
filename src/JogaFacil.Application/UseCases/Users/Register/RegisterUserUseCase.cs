using AutoMapper;
using FluentValidation.Results;
using JogaFacil.Comunication.Requests.Users;
using JogaFacil.Comunication.Responses;
using JogaFacil.Domain.Cryptography;
using JogaFacil.Domain.Entities;
using JogaFacil.Domain.Repositories;
using JogaFacil.Domain.Repositories.User;
using JogaFacil.Domain.Token;
using JogaFacil.Exception.ExceptionsBase;
using JogaFacil.Exception.Resources;

namespace JogaFacil.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPasswordEncrypter _passwordEncripter;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public RegisterUserUseCase(
            IMapper mapper,
            IPasswordEncrypter passwordEncripter,
            IUserReadOnlyRepository userReadOnlyRepository,
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IUnityOfWork unityOfWork,
            IJwtTokenGenerator tokenGenerator
            )
        {
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
            _userReadOnlyRepository = userReadOnlyRepository;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _unityOfWork = unityOfWork;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
        {
            await Validate(request);

            var user = _mapper.Map<User>(request);

            user.Password = _passwordEncripter.Encrypt(request.Password);
            user.Id = Guid.NewGuid();

            await _userWriteOnlyRepository.Add(user);
            await _unityOfWork.Commit();

            return new ResponseRegisterUserJson()
            {
                Name = request.Name,
                Token = _tokenGenerator.Generate(user)
            };
        }

        private async Task Validate(RequestRegisterUserJson request)
        {
            var result = new RegisterUserValidator().Validate(request);

            var emailExists = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

            if (emailExists)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_EXISTS));
            }

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
