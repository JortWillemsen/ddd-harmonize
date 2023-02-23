using Common.Domain;
using ExampleService.Domain;

namespace ExampleService.Infrastructure.Ports.Database;

public interface IExampleRepository
{ 
    public Task<Example> FindByAggregateId(EntityId entityId);
    public Task Update(Example example);
}