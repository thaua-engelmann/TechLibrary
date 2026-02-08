namespace TechLibrary.Domain.Repositories.Users;
public interface IUsersReadOnlyRepository
{
    public Task<bool> EmailExistsAlready(string email);
}
