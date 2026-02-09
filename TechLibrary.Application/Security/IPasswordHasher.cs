namespace TechLibrary.Application.Security;

public interface IPasswordHasher
{
    public string HashPassword(string password);
}
