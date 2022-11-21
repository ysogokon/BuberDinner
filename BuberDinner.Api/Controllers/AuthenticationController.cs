using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using BuberDinner.Domain.Common.Errors;
namespace BuberDinner.Api.Controllers
{
  [Route("auth")]
  public class AuthenticationController : ApiController
  {
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationService)
    {
      _authenticationService = authenticationService;

    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
      ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(
        request.FirstName,
        request.LastName,
        request.Email,
        request.Password);

      return authResult.Match(authResult => Ok(MapAuthResult(authResult)),
        errors => Problem(errors));


      // if (!registerResult.IsError)
      // {
      //   return Ok(MapAuthResult(registerResult.Value));
      // }

      // var firstError = registerResult.Errors[0];

      // return firstError is DuplicateEmailError
      //   ? Problem(statusCode: StatusCodes.Status409Conflict, detail: "Email already exists.")
      //   : (IActionResult)Problem();
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
      ErrorOr<AuthenticationResult> authResult = _authenticationService.Login(request.Email, request.Password);

      // var response = new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);

      // return Ok(response);

      if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
      {
        return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
      }

      return authResult.Match(authResult => Ok(MapAuthResult(authResult)),
        errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
      return new AuthenticationResponse(
        authResult.User.Id,
        authResult.User.FirstName,
        authResult.User.LastName,
        authResult.User.Email,
        authResult.Token);
    }
  }
}