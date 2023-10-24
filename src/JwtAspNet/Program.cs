using System.Security.Claims;
using JwtAspNet.Extensions;
using JwtAspNet.IoC;
using JwtAspNet.Models;
using JwtAspNet.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/login", (TokenService tokenService, [FromBody] User user) => tokenService.Create(user));

app.MapGet("/restrito", (ClaimsPrincipal user) => 
  new {
    id = user.Id(),
    name = user.Name(),
    email = user.Email(),
    givenName = user.GivenName(),
    image = user.Image()
  }
).RequireAuthorization();

app.MapGet("/admin", () => "Você tem acesso!").RequireAuthorization("admin");

app.Run();
