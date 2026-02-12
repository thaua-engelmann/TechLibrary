using Microsoft.EntityFrameworkCore;
using TechLibrary.Domain.Entities;
using TechLibrary.Domain.Repositories.Users;
using TechLibrary.Infrastructure.DataAccess;

namespace TechLibrary.Infrastructure.Repositories.Users;

internal class UsersReadOnlyRepository(TechLibraryDbContext dbContext) : IUsersReadOnlyRepository
{
    public async Task<bool> EmailExistsAlready(string email) => 
        await dbContext.Users.AnyAsync(u => u.Email == email);

    public async Task<User?> GetByEmail(string email) =>
        await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);

}
