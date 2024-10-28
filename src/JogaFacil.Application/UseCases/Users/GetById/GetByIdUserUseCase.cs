using AutoMapper;
using JogaFacil.Comunication.Responses;
using JogaFacil.Domain.Repositories.User;
using JogaFacil.Exception.ExceptionsBase;
using JogaFacil.Exception.Resources;

namespace JogaFacil.Application.UseCases.Users.GetById
{
    public class GetByIdUserUseCase : IGetByIdUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;

        public GetByIdUserUseCase(IMapper mapper, IUserReadOnlyRepository userReadOnlyRepository)
        {
            _mapper = mapper;
            _userReadOnlyRepository = userReadOnlyRepository;
        }

        public async Task<ResponseUserJson> Execute(Guid id)
        {
            var result = await _userReadOnlyRepository.GetById(id);

            if (result is null)
            {
                throw new NotFoundException(ResourceErrorMessages.USER_NOT_FOUND);
            }

            return _mapper.Map<ResponseUserJson>(result);
        }
    }
}
