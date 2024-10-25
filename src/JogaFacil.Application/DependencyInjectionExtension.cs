using JogaFacil.Application.AutoMapper;
using JogaFacil.Application.UseCases.Login;
using JogaFacil.Application.UseCases.Users.GetAll;
using JogaFacil.Application.UseCases.Users.Register;
using Microsoft.Extensions.DependencyInjection;

namespace JogaFacil.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCase(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddUseCase(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<IGetAllUserUseCase, GetAllUserUseCase>();
            services.AddScoped<ILoginUseCase, LoginUseCase>();
        }
    }
}
