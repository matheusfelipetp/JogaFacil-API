
using JogaFacil.Domain.Repositories;
using JogaFacil.Domain.Repositories.User;
using JogaFacil.Exception.ExceptionsBase;
using JogaFacil.Exception.Resources;

namespace JogaFacil.Application.UseCases.Users.Delete
{
    public class DeleteUserUseCase : IDeleteUserUseCase
    {
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUnityOfWork _unityOfWork;

        public DeleteUserUseCase(IUserWriteOnlyRepository userWriteOnlyRepository, IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
            _userWriteOnlyRepository = userWriteOnlyRepository;
        }

        public async Task Execute(Guid id)
        {
            var result = await _userWriteOnlyRepository.Delete(id);

            if (!result)
            {
                throw new NotFoundException(ResourceErrorMessages.USER_NOT_FOUND);
            }

            await _unityOfWork.Commit();
        }
    }
}
