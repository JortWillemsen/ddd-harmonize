namespace ExampleService.Application.Queries.FindExampleById;

public class FindExampleByIdQuery : IQuery
{
    public Guid Id { get; set; }
}