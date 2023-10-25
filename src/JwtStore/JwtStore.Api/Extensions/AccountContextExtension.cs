using MediatR;

namespace JwtStore.Api.Extensions
{
  public static class AccountContextExtension
  {
    public static void AddAccountContext(this WebApplicationBuilder builder)
    {
      #region Create

      builder.Services.AddTransient<
          Core.Contexts.AccountContext.UseCases.Create.Contracts.IRepository,
          Infra.Contexts.AccountContext.UseCases.Create.Repository>();

      builder.Services.AddTransient<
          Core.Contexts.AccountContext.UseCases.Create.Contracts.IService,
          Infra.Contexts.AccountContext.UseCases.Create.Service>();

      #endregion
    }

    public static void MapAccountEndpoints(this WebApplication app)
    {
      #region Create

      app.MapPost("api/v1/users", async (
          Core.Contexts.AccountContext.UseCases.Create.Request request,
          IRequestHandler<
              Core.Contexts.AccountContext.UseCases.Create.Request,
              Core.Contexts.AccountContext.UseCases.Create.Response> handler) =>
      {
        var result = await handler.Handle(request, new CancellationToken());
        return result.IsSuccess
            ? Results.Created($"api/v1/users/{result.Data?.Id}", result)
            : Results.Json(result, statusCode: result.Status);
      });

      #endregion
    }
  }
}