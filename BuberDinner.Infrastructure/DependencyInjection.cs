using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Persistence;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager config)
    {
      services.AddAuth(config);
      services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
      services.AddScoped<IUserRepository, UserRepository>();

      return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager config)
    {
      services.Configure<JwtSettings>(config.GetSection(JwtSettings.SectionName));
      services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

      return services;
    }
  }
}