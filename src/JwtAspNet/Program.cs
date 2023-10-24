using JwtAspNet.IoC;
using JwtAspNet.Models;
using JwtAspNet.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", (TokenService tokenService, [FromBody] User user) => tokenService.Create(user));

app.Run();
