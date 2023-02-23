namespace Common.Events.CatalogService;

public class ArtistRegistered : Event
{
    public string Name { get; }
    
    public ArtistRegistered(Guid aggregateId, string name) : base(aggregateId)
    {
        Name = name;
    }
}