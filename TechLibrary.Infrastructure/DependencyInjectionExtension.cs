using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TechLibrary.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using TechLibrary.Domain.Repositories.Users;
using TechLibrary.Infrastructure.Repositories.Users;
using TechLibrary.Domain.Repositories;
using TechLibrary.Infrastructure.Repositories;
using TechLibrary.Application.Security;
using TechLibrary.Infrastructure.Security.Cryptography;

namespace TechLibrary.Infrastructure;

public static class DependencyInjectionExtension
{

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        services.AddDbContext<TechLibraryDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IUsersWriteOnlyRepository, UsersWriteOnlyRepository>();
        services.AddScoped<IUsersReadOnlyRepository, UsersReadOnlyRepository>();
    } 
}
