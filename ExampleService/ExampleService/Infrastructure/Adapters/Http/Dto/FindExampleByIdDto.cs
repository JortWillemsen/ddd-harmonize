using ExampleService.Application.Queries.FindExampleById;

namespace ExampleService.Infrastructure.Adapters.Http.Dto;

public class FindExampleByIdDto
{
    public Guid Id { get; set; }
}

public static class FindExampleByIdExtensions
{
    public static FindExampleByIdQuery ToQuery(this FindExampleByIdDto dto)
    {
        return new FindExampleByIdQuery() { Id = dto.Id };
    }
}