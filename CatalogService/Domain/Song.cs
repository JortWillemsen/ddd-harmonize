using Common.Domain;

namespace LibraryService.Domain;

public class SongEntityId : EntityId
{
    public SongEntityId(Guid value) : base(value) { }
}

public class Song : Entity<SongEntityId>
{
    private string Title { get; set; }
    private int AmountListened { get; set; }
    private Credits Credits { get; set; }
    
    public Song(SongEntityId entityId) : base(entityId)
    {
    }
}
