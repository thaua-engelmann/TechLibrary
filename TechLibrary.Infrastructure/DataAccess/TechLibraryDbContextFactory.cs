using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TechLibrary.Infrastructure.DataAccess;

internal class TechLibraryDbContextFactory : IDesignTimeDbContextFactory<TechLibraryDbContext>
{

    public TechLibraryDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddUserSecrets("0fa677c5-0043-405b-a333-ae06c577202a")
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString("Connection");
        var optionsBuilder = new DbContextOptionsBuilder<TechLibraryDbContext>();

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new TechLibraryDbContext(optionsBuilder.Options);
    }

}
