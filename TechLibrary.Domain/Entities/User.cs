namespace TechLibrary.Domain.Entities;
public class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();  
    public required string Name { get; set; } = string.Empty;
    public required string Email { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
}
