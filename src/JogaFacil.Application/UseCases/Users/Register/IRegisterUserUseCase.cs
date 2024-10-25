using JogaFacil.Comunication.Requests.Users;
using JogaFacil.Comunication.Responses;

namespace JogaFacil.Application.UseCases.Users.Register
{
    public interface IRegisterUserUseCase
    {
        Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request);
    }
}
