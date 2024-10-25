using AutoMapper;
using JogaFacil.Comunication.Requests.Users;
using JogaFacil.Comunication.Responses;
using JogaFacil.Domain.Repositories.User;

namespace JogaFacil.Application.UseCases.Users.GetAll
{
    public class GetAllUserUseCase : IGetAllUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;

        public GetAllUserUseCase(
            IMapper mapper,
            IUserReadOnlyRepository userReadOnlyRepository
            )
        {
            _mapper = mapper;
            _userReadOnlyRepository = userReadOnlyRepository;
        }

        public async Task<ResponseUserJson> Execute()
        {
            var result = await _userReadOnlyRepository.GetAll();

            return new ResponseUserJson()
            {
                Users = _mapper.Map<List<ResponseShortUserJson>>(result)
            };
        }
    }
}
