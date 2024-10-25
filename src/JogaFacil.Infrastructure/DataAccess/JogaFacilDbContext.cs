using JogaFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JogaFacil.Infrastructure.DataAccess
{
    public class JogaFacilDbContext : DbContext
    {
        public JogaFacilDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
    }
}
