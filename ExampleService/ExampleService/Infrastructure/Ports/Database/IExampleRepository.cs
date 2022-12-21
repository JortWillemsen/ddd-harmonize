using ExampleService.Domain;

namespace ExampleService.Infrastructure.Ports.Database;

public interface IExampleRepository
{
    public Task<Example> FindById(Guid id);
    public Task<Example> FindByIdSourced(Guid id);
    public Task Update(Example example);
}