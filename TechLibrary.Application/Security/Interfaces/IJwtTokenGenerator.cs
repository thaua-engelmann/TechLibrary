using TechLibrary.Domain.Entities;

namespace TechLibrary.Application.Security.Interfaces;
public interface IJwtTokenGenerator
{
    public string Generate(User user);
}
