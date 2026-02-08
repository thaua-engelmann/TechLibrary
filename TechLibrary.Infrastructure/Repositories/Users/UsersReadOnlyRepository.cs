using Microsoft.EntityFrameworkCore;
using TechLibrary.Domain.Repositories.Users;
using TechLibrary.Infrastructure.DataAccess;

namespace TechLibrary.Infrastructure.Repositories.Users;

internal class UsersReadOnlyRepository(TechLibraryDbContext dbContext) : IUsersReadOnlyRepository
{
    public async Task<bool> EmailExistsAlready(string email) => 
        await dbContext.Users.AnyAsync(u => u.Email == email);

}
