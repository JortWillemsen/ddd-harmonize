using Common.Domain;

namespace LibraryService.Domain;

public class ArtistId : Id
{
    public ArtistId(Guid value) : base(value)
    {
    }
}

public class Artist : Entity<ArtistId>
{
    private string Name { get; set; }
    private IEnumerable<Release> Oeuvre { get; set; }
    
    public Artist(ArtistId id) : base(id)
    {
    }
}
