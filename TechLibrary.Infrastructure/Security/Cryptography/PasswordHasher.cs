namespace TechLibrary.Infrastructure.Security.Cryptography;
using BCrypt.Net;
using TechLibrary.Application.Security;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password) => BCrypt.HashPassword(password);
}
