using JogaFacil.Domain.Entities;
using JogaFacil.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace JogaFacil.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository, IUserUpdateOnlyRepository
    {
        private readonly JogaFacilDbContext _dbContext;

        public UserRepository(JogaFacilDbContext dbContext) => _dbContext = dbContext;

        public async Task Add(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Users.AsNoTracking().ToListAsync();
        }

        async Task<User?> IUserReadOnlyRepository.GetById(Guid id)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id ==id);
        }

        async Task<User?> IUserUpdateOnlyRepository.GetById(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public void Update(User user)
        {
            _dbContext.Users.Update(user);
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);

            if (result is null)
                return false;

            _dbContext.Users.Remove(result);

            return true;
        }
    }
}
