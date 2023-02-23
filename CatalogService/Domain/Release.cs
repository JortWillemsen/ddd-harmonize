using Common.Domain;
using Common.Events;

namespace LibraryService.Domain;

public class ReleaseEntityId : EntityId
{
    private ReleaseEntityId(Guid value) : base(value) { }
}

public class Release : Entity<ReleaseEntityId>
{
    private ReleaseType Type { get; set; }
    private Artist Artist { get; set; }
    private IEnumerable<Record> Records { get; set; }

    public Release(ReleaseEntityId entityId) : base(entityId)
    {
    }
}