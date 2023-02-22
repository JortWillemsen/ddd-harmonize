using Common.Events;
using ExampleService.Domain;
using ExampleService.Infrastructure.Adapters.Database.Postgres.Configurations;
using Microsoft.EntityFrameworkCore;
using Wrappit.Messaging;

namespace ExampleService.Infrastructure.Adapters.Database.Postgres;

public class ExampleContext : DbContext
{
    public DbSet<EventEntry> Events { get; set; }

    public ExampleContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EventsConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}