using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
  builder.Services
  .AddPresentation()
  .AddApplication()
  .AddInfrastructure(builder.Configuration);

  // builder.Services.AddControllers(
  //     // (second approach for error handling - exeption filter attrubute)
  //     options => options.Filters.Add<ErrorHandlingFilterAttribute>()
  //   );

}

var app = builder.Build();
{
  //app.UseMiddleware<ErrorHandlingMiddleware>(); (first approach for error handling - mddleware)
  app.UseExceptionHandler("/error");
  // app.Map("/error", (HttpContext httpContext) =>
  // {
  //   Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
  //   return Results.Problem();
  // });

  app.UseHttpsRedirection();
  app.MapControllers();
  app.Run();
}
