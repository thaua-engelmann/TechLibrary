using TechLibrary.Domain.Commom;

namespace TechLibrary.Domain.Entities;
public class User : Entity
{
    public required string Name { get; set; } = string.Empty;
    public required string Email { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
}
