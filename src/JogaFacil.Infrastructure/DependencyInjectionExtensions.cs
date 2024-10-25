using JogaFacil.Domain.Cryptography;
using JogaFacil.Domain.Repositories;
using JogaFacil.Domain.Repositories.User;
using JogaFacil.Domain.Token;
using JogaFacil.Infrastructure.DataAccess;
using JogaFacil.Infrastructure.DataAccess.Repositories;
using JogaFacil.Infrastructure.Security.Token;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JogaFacil.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
            AddToken(services, configuration);

            services.AddScoped<IPasswordEncrypter, Security.Cryptography.BCrypt>();
        }

        private static void AddToken(IServiceCollection services, IConfiguration configuration)
        {
            var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
            var signinKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

            services.AddScoped<IJwtTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signinKey!));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");

            services.AddDbContext<JogaFacilDbContext>(config => config.UseSqlServer(connectionString));
        }
    }
}
