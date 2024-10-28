using JogaFacil.Comunication.Requests.Users;
using JogaFacil.Comunication.Responses;

namespace JogaFacil.Application.UseCases.Users.Update
{
    public interface IUpdateUserUseCase
    {
        Task Execute(Guid id, RequestUpdateUserJson request);
    }
}
