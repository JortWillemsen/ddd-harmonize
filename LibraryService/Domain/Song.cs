using Common.Domain;

namespace LibraryService.Domain;

public class SongId : Id
{
    public SongId(Guid value) : base(value) { }
}

public class Song : Entity<SongId>
{
    private string Title { get; set; }
    private int AmountListened { get; set; }
    private Credits Credits { get; set; }
    
    public Song(SongId id) : base(id)
    {
    }
}
