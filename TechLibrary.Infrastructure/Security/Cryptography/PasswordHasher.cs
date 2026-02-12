namespace TechLibrary.Infrastructure.Security.Cryptography;

using BCrypt.Net;
using TechLibrary.Application.Security.Interfaces;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password) => BCrypt.HashPassword(password);
    public bool VerifyPassword(string password, string hashedPassword) => BCrypt.Verify(password, hashedPassword);
}
