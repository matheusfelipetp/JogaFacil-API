using AutoMapper;
using JogaFacil.Comunication.Requests.Users;
using JogaFacil.Comunication.Responses;
using JogaFacil.Domain.Entities;
using JogaFacil.Domain.Repositories;
using JogaFacil.Domain.Repositories.User;
using JogaFacil.Exception.ExceptionsBase;
using JogaFacil.Exception.Resources;

namespace JogaFacil.Application.UseCases.Users.Update
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unitOfWork;
        private readonly IUserUpdateOnlyRepository _repository;

        public UpdateUserUseCase(IMapper mapper, IUnityOfWork unitOfWork, IUserUpdateOnlyRepository repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task Execute(Guid id, RequestUpdateUserJson request)
        {
            Validate(request);

            var user = await _repository.GetById(id);

            if (user is null)
            {
                throw new NotFoundException(ResourceErrorMessages.USER_NOT_FOUND);
            }

            _mapper.Map(request, user);
            _repository.Update(user);

            await _unitOfWork.Commit();
        }

        private void Validate(RequestUpdateUserJson request)
        {
            var validator = new UpdateUserValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var messages =  result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(messages);
            }
        }
    }
}
    