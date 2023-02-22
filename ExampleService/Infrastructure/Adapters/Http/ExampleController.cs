using Common.Application;
using ExampleService.Application.Commands;
using ExampleService.Application.Commands.ChangeNameOfExample;
using ExampleService.Application.Commands.CreateExample;
using ExampleService.Application.Queries;
using ExampleService.Application.Queries.FindExampleById;
using ExampleService.Domain;
using ExampleService.Infrastructure.Adapters.Http.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ExampleService.Infrastructure.Adapters.Http;

[ApiController]
[Route("/examples")]
public class ExampleController
{
    [HttpPost]
    public async Task CreateExample(
        [FromBody] CreateExampleDto dto, 
        [FromServices] ICommandHandler<CreateExampleCommand> handler)
    {
        await handler.Handle(dto.ToCommand());
    }

    [HttpGet]
    public async Task<Example> FindExampleById(
        [FromQuery] FindExampleByIdDto dto,
        [FromServices] IQueryHandler<FindExampleByIdQuery, Example> handler)
    {
        var result = await handler.Handle(dto.ToQuery());

        return result;
    }

    [HttpPatch]
    public async Task ChangeNameOfExample(
        [FromBody] ChangeNameOfExampleDto dto,
        [FromServices] ICommandHandler<ChangeNameOfExampleCommand> handler)
    {
        await handler.Handle(dto.ToCommand());
    }
}