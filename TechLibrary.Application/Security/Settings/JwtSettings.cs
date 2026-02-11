namespace TechLibrary.Application.Security.Settings;
public class JwtSettings
{
    public string SigningKey { get; set; } = string.Empty;
    public int ExpirationMinutes { get; set; }
}
