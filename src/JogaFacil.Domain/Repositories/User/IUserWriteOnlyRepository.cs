namespace JogaFacil.Domain.Repositories.User
{
    public interface IUserWriteOnlyRepository
    {
        Task Add(Entities.User user);
        Task<bool> Delete(Guid id);
    }
}
