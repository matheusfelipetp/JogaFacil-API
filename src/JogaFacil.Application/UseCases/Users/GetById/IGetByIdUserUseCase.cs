using JogaFacil.Comunication.Responses;

namespace JogaFacil.Application.UseCases.Users.GetById
{
    public interface IGetByIdUserUseCase
    {
        Task<ResponseUserJson> Execute(Guid id);
    }
}
