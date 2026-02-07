using TechLibrary.Domain.Entities;
using TechLibrary.Domain.Repositories.Users;
using TechLibrary.Infrastructure.DataAccess;

namespace TechLibrary.Infrastructure.Repositories.Users;

public class UsersWriteOnlyRepository(TechLibraryDbContext dbContext) : IUsersWriteOnlyRepository
{
    public async Task Add(User user)
    {
        await dbContext.Users.AddAsync(user);

    }

}
