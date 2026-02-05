using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TechLibrary.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace TechLibrary.Infrastructure;

public static class DependencyInjectionExtension
{

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        services.AddDbContext<TechLibraryDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
}
