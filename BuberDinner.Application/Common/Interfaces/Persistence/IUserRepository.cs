using BuberDinner.Domain.User.Entities;

namespace BuberDinner.Application.Common.Interfaces.Persistence
{
  public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}