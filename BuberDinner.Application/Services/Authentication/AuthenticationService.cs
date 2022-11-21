using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using BuberDinner.Application.Common.Errors;
using FluentResults;
using ErrorOr;
using BuberDinner.Domain.Common.Errors;

namespace BuberDinner.Application.Services.Authentication
{
  public class AuthenticationService : IAuthenticationService
  {
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
      _userRepository = userRepository;
      _jwtTokenGenerator = jwtTokenGenerator;

    }
    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
      if (_userRepository.GetUserByEmail(email) is not null)
      {
        return Errors.User.DuplicateEmail;
        //return new AuthenticationResult(false, "User already exists");
        //throw new Exception("User with given email already exists.");
        //throw new DuplicateEmailException();
        //return Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });
      }

      var user = new User { FirstName = firstName, LastName = lastName, Email = email, Password = password };

      _userRepository.Add(user);

      var token = _jwtTokenGenerator.GenerateToken(user);

      return new AuthenticationResult(user, token);
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
      if (_userRepository.GetUserByEmail(email) is not User user)
      {
        return Errors.Authentication.InvalidCredentials;
      }

      if (user.Password != password)
      {
        return new[] { Errors.Authentication.InvalidCredentials };
      }

      var token = _jwtTokenGenerator.GenerateToken(user);

      return new AuthenticationResult(user, token);
    }
  }
}
