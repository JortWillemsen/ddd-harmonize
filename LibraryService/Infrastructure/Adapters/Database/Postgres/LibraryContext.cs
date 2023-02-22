using Common.Events;
using LibraryService.Infrastructure.Adapters.Database.Postgres.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Infrastructure.Adapters.Database.Postgres;

public class LibraryContext : DbContext
{
    public DbSet<EventEntry> Events { get; set; }

    public LibraryContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EventsConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}