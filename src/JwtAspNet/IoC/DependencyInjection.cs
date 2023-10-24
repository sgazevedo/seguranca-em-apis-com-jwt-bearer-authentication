using JwtAspNet.Services;

namespace JwtAspNet.IoC
{
  public static class DependencyInjection
  {
    public static void AddDependencies(this IServiceCollection services)
    {
      services.AddSecurity();
      services.AddServices();
    }

    public static void AddSecurity(this IServiceCollection services)
    {
      services.AddAuthentication();
      services.AddAuthorization();
    }

    public static void AddServices(this IServiceCollection services)
    {
      services.AddTransient<TokenService>();
    }
  }
}