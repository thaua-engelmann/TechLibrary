namespace TechLibrary.Infrastructure.Security.Cryptography;
using BCrypt.Net;

public class BCryptAlgorithm
{
    public string HashPassword(string password) => BCrypt.HashPassword(password);
}
