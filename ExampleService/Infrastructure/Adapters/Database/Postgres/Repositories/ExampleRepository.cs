using Common.Infrastructure.Database;
using DotnetCute.Exceptions.Http.Client;
using ExampleService.Domain;
using ExampleService.Infrastructure.Ports.Database;
using Microsoft.EntityFrameworkCore;

namespace ExampleService.Infrastructure.Adapters.Database.Postgres.Repositories;

public class ExampleRepository : BaseRepository, IExampleRepository
{
    private readonly ExampleContext _context;

    public ExampleRepository(ExampleContext context)
    {
        _context = context;
    }

    public async Task<Example> FindByAggregateId(Guid id)
    {
        var events = await _context.Events
            .Where(e => e.AggregateId == id)
            .OrderBy(e => e.Timestamp)
            .ToListAsync();

        if (events.Count == 0)
            throw new NotFoundException(nameof(Example));
        
        var result = new Example(DeserializeEvents(events));

        return result;
    }

    public async Task Update(Example example)
    {
        var events = example.Events;

        // Because we know we only have the new events we don't need to check if the entity exists!
        // We can just simply add the new events to the database.
        foreach (var evt in events)
        {
            await _context.Events.AddAsync(SerializeEvent(evt));
        }

        await _context.SaveChangesAsync();
    }
}