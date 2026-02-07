using TechLibrary.Domain.Repositories;
using TechLibrary.Infrastructure.DataAccess;

namespace TechLibrary.Infrastructure.Repositories;

public class UnitOfWork(TechLibraryDbContext dbContext) : IUnitOfWork
{
    public async Task Commit()
    {
        await dbContext.SaveChangesAsync();
    }

}
