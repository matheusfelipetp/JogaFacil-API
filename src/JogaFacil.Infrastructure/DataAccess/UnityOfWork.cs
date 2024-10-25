using JogaFacil.Domain.Repositories;

namespace JogaFacil.Infrastructure.DataAccess
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly JogaFacilDbContext _dbContext;

        public UnityOfWork(JogaFacilDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
