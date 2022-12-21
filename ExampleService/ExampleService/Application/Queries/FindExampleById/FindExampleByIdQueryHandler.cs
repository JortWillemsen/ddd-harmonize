using ExampleService.Domain;
using ExampleService.Infrastructure.Ports.Database;

namespace ExampleService.Application.Queries.FindExampleById;

public class FindExampleByIdQueryHandler : IQueryHandler<FindExampleByIdQuery, Example>
{
    private readonly IExampleRepository _repository;

    public FindExampleByIdQueryHandler(IExampleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Example> Handle(FindExampleByIdQuery query)
    {
        return await _repository.FindByIdSourced(query.Id);
    }
}