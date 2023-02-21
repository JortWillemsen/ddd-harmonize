using ExampleService.Domain;

namespace ExampleService.Infrastructure.Ports.Database;

public interface IExampleRepository
{ 
    public Task<Example> FindByAggregateId(Guid id);
    public Task Update(Example example);
}