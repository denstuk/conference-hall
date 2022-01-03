using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ConferenceHall.API.Domain.Auth.Interfaces;
using ConferenceHall.API.Domain.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace ConferenceHall.API.Domain.Auth;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;
    
    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string Generate(Guid id)
    {
        Claim[] claims = { new (ClaimTypes.NameIdentifier, id.ToString()) };
        JwtSecurityToken token = new JwtSecurityToken
        (
            issuer: _configuration.GetValue<string>("TOKEN_ISSUER"),
            audience: _configuration.GetValue<string>("TOKEN_AUDIENCE"),
            claims: claims,
            expires: DateTime.UtcNow.AddDays(60),
            notBefore: DateTime.Now,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetValue<string>("TOKEN_SECRET"))),
                    SecurityAlgorithms.HmacSha256)
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public bool Validate(string token)
    {
        var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetValue<string>("TOKEN_SECRET")));
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _configuration.GetValue<string>("TOKEN_ISSUER"),
                ValidAudience = _configuration.GetValue<string>("TOKEN_AUDIENCE"),
                IssuerSigningKey = mySecurityKey
            }, out SecurityToken _);
        }
        catch
        {
            return false;
        }
        return true;
    }
}