using JwtStore.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddDatabase();
builder.AddJwtAuthentication();
builder.AddMediatR();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();
