using TechLibrary.Domain.Entities;

namespace TechLibrary.Domain.Repositories.Users;

public interface IUsersWriteOnlyRepository
{
    public Task Add(User user);
}
