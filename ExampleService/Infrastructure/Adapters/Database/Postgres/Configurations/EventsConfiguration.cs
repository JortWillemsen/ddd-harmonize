using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleService.Infrastructure.Adapters.Database.Postgres.Configurations;

public class EventsConfiguration : IEntityTypeConfiguration<EventEntry>
{
    public void Configure(EntityTypeBuilder<EventEntry> builder)
    {
        builder.ToTable("events");
        builder.HasKey(e => e.Id);
    }
}