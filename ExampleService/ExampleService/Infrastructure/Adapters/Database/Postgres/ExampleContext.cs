using ExampleService.Domain;
using ExampleService.Domain.Events;
using ExampleService.Infrastructure.Adapters.Database.Postgres.Configurations;
using Microsoft.EntityFrameworkCore;
using Wrappit.Messaging;

namespace ExampleService.Infrastructure.Adapters.Database.Postgres;

public class ExampleContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Example> Examples { get; set; }

    public ExampleContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EventsConfiguration());
        modelBuilder.ApplyConfiguration(new ExampleConfiguration());

        modelBuilder.Entity<ExampleCreatedEvent>();
        modelBuilder.Entity<NameChangedEvent>();

        base.OnModelCreating(modelBuilder);
    }
}