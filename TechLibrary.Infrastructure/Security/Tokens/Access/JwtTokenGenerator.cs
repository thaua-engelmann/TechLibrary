using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TechLibrary.Application.Security.Interfaces;
using TechLibrary.Application.Security.Settings;
using TechLibrary.Domain.Entities;

namespace TechLibrary.Infrastructure.Security.Tokens.Access;

internal class JwtTokenGenerator(IOptions<JwtSettings> settings) : IJwtTokenGenerator
{
    private readonly JwtSettings _settings = settings.Value;

    public string Generate(User user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes),
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(GetSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }

    private SymmetricSecurityKey GetSecurityKey()
    {
        var signingKey = _settings.SigningKey;
        var symetricKey = Encoding.UTF8.GetBytes(signingKey);

        return new SymmetricSecurityKey(symetricKey);
    }
}
