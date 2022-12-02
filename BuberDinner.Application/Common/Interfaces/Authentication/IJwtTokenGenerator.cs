using BuberDinner.Domain.User.Entities;

namespace BuberDinner.Application.Common.Interfaces.Authentication
{
  public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}