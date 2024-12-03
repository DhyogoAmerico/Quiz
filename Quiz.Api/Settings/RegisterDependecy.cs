using Quiz.Domain.Repository;
using Quiz.Domain.Service;
using Quiz.Infra.Repository;
using Quiz.Service.Service;

namespace Quiz.Api.Settings;

public static class RegisterDependecy
{
    public static void RegisterRepositorys(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
    }

    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<ITokenService, TokenService>();
    }
}
