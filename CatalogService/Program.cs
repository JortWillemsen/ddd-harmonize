using DotnetCute.Middleware;
using LibraryService;
using LibraryService.Infrastructure.Adapters.Database.Postgres;
using Microsoft.EntityFrameworkCore;
using Wrappit.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = EnvironmentSettings.GetConnectionString();
var options = new DbContextOptionsBuilder<CatalogContext>()
    .UseNpgsql(connectionString,
        p =>
        {
            p.EnableRetryOnFailure(
                5, 
                TimeSpan.FromSeconds(5), 
                new List<string>());
        })
    .Options;

builder.Services.AddTransient(_ => new CatalogContext(options));

builder.Services.AddWrappit();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<CatalogContext>();
dbContext?.Database.Migrate();
dbContext?.Database.EnsureCreated();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<CuteMiddleWare>(new CuteOptions()
{
    ShowStatusCode = true,
    ShowTimeStamp = true,
    ShowPath = true,
    ShowLogs = true,
    ShowStacktrace = false,
});

app.MapControllers();

app.Run();