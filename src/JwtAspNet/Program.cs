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

app.MapGet("/restrito", () => "Você tem acesso!").RequireAuthorization();

app.MapGet("/admin", () => "Você tem acesso!").RequireAuthorization("admin");

app.Run();
