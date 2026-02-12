using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechLibrary.Application.Security.Interfaces;
using TechLibrary.Application.Security.Settings;
using TechLibrary.Domain.Repositories;
using TechLibrary.Domain.Repositories.Users;
using TechLibrary.Infrastructure.DataAccess;
using TechLibrary.Infrastructure.Repositories;
using TechLibrary.Infrastructure.Repositories.Users;
using TechLibrary.Infrastructure.Security.Cryptography;
using TechLibrary.Infrastructure.Security.Tokens.Access;

namespace TechLibrary.Infrastructure;

public static class DependencyInjectionExtension
{

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddSecurity(services, configuration);
        AddRepositories(services);
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        services.AddDbContext<TechLibraryDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }

    private static void AddSecurity(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUsersWriteOnlyRepository, UsersWriteOnlyRepository>();
        services.AddScoped<IUsersReadOnlyRepository, UsersReadOnlyRepository>();
    }
}
