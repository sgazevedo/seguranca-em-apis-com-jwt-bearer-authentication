using System.Text;
using JwtAspNet.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(x =>
      {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.PrivateKey)),
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });

      services.AddAuthorization(x => 
      { 
        x.AddPolicy("Admin", p => p.RequireRole("admin")); 
      });
    }

    public static void AddServices(this IServiceCollection services)
    {
      services.AddTransient<TokenService>();
    }
  }
}