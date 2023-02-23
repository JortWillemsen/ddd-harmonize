using Common.Domain;
using Common.Events;
using Common.Events.CatalogService;

namespace LibraryService.Domain;

public class ArtistId : EntityId
{
    public ArtistId(Guid value) : base(value)
    {
    }
}

public class Artist : AggregateRoot<ArtistId>
{
    private string Name { get; set; }
    private IEnumerable<Release> Oeuvre { get; set; }

    public Artist(ArtistId id, string name) : base(id)
    {
        RaiseEvent(new ArtistRegistered(id.Value, name));
    }

    public Artist(ArtistId id, IEnumerable<Event> events) : base(id, events) { }
    
    protected override void When(dynamic evt)
    {
        Handle(evt);
    }

    private void Handle(ArtistRegistered evt)
    {
        Id = new ArtistId(evt.AggregateId);
        Name = evt.Name;
        Oeuvre = new List<Release>();
    }
}
