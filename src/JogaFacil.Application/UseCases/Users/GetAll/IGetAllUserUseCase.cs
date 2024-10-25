using JogaFacil.Comunication.Requests.Users;
using JogaFacil.Comunication.Responses;

namespace JogaFacil.Application.UseCases.Users.GetAll
{
    public interface IGetAllUserUseCase
    {
        Task<ResponseUserJson> Execute();
    }
}
