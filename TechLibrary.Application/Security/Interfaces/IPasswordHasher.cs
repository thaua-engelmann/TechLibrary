namespace TechLibrary.Application.Security.Interfaces;

public interface IPasswordHasher
{
    public string HashPassword(string password);
}
