using DotnetCute.Middleware;
using ExampleService;
using ExampleService.Application.Commands;
using ExampleService.Application.Commands.ChangeNameOfExample;
using ExampleService.Application.Commands.CreateExample;
using ExampleService.Application.Commands.UpdateNameOfExample;
using ExampleService.Application.Queries;
using ExampleService.Application.Queries.FindExampleById;
using ExampleService.Domain;
using ExampleService.Infrastructure.Adapters.Database.Postgres;
using ExampleService.Infrastructure.Adapters.Database.Postgres.Repositories;
using ExampleService.Infrastructure.Adapters.Messaging.RabbitMq;
using ExampleService.Infrastructure.Ports.Database;
using ExampleService.Infrastructure.Ports.Messaging;
using Microsoft.EntityFrameworkCore;
using Wrappit.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IExampleRepository, ExampleRepository>();

builder.Services.AddTransient<ICommandHandler<CreateExampleCommand>, CreateExampleCommandHandler>();
builder.Services.AddTransient<ICommandHandler<ChangeNameOfExampleCommand>, ChangeNameOfExampleCommandHandler>();

builder.Services.AddTransient<IQueryHandler<FindExampleByIdQuery, Example>, FindExampleByIdQueryHandler>();

builder.Services.AddTransient<IMessagePublisher, RabbitMqPublisher>();
builder.Services.AddTransient<IMessageListener, RabbitMqListener>();

var connectionString = EnvironmentSettings.GetConnectionString();
var options = new DbContextOptionsBuilder<ExampleContext>()
    .UseNpgsql(connectionString,
        p =>
        {
            p.EnableRetryOnFailure(
                5, 
                TimeSpan.FromSeconds(5), 
                new List<string>());
        })
    .Options;

builder.Services.AddTransient(_ => new ExampleContext(options));

builder.Services.AddWrappit();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<ExampleContext>();
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