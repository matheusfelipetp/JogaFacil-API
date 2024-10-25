namespace JogaFacil.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        Task<List<Entities.User>> GetAll();
        Task<bool> ExistActiveUserWithEmail(string email);
        Task<Entities.User?> GetUserByEmail(string email);
    }
}
