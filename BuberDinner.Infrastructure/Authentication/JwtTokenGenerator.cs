using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure.Authentication
{
  public class JwtTokenGenerator : IJwtTokenGenerator
  {
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;
    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
      _jwtSettings = jwtOptions.Value;
      _dateTimeProvider = dateTimeProvider;
    }
    public string GenerateToken(User user)
    {
      var signingCredentials = new SigningCredentials(
          new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
          SecurityAlgorithms.HmacSha256);

      var claims = new[]
      {
        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.GivenName, user.FirstName),
        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.FamilyName, user.LastName),
        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
      };

      var securityToken = new JwtSecurityToken
      (
        issuer: _jwtSettings.Issuer,
        audience: _jwtSettings.Audience,
        expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
        claims: claims,
        signingCredentials: signingCredentials
        );

      return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
  }
}