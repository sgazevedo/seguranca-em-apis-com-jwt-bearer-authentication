using JwtAspNet.Models;
using JwtAspNet.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<TokenService>();

var app = builder.Build();

app.MapGet("/", (TokenService tokenService, [FromBody] User user) => tokenService.Create(user));

app.Run();
