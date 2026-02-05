namespace TechLibrary.Domain.Entities;
public class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();  
    public string Name { get; set; } = string.Empty;
}
