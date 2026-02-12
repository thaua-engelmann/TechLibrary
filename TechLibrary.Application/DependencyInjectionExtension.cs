using Microsoft.Extensions.DependencyInjection;
using TechLibrary.Application.UseCases.Auth.Login;
using TechLibrary.Application.UseCases.Users.Create;

namespace TechLibrary.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        services.AddScoped<ILoginUseCase, LoginUseCase>();
    }
}
