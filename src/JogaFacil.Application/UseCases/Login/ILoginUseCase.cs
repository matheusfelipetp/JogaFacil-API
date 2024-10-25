using JogaFacil.Comunication.Requests.Login;
using JogaFacil.Comunication.Responses;

namespace JogaFacil.Application.UseCases.Login
{
    public interface ILoginUseCase
    {
        Task<ResponseRegisterUserJson> Execute(RequestLoginJson request);
    }
}
