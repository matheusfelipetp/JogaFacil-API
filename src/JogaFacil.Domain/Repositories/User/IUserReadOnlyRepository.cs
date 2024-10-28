namespace JogaFacil.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        Task<List<Entities.User>> GetAll();
        Task<Entities.User?> GetById(Guid id);
        Task<bool> ExistActiveUserWithEmail(string email);
        Task<Entities.User?> GetUserByEmail(string email);
    }
}
