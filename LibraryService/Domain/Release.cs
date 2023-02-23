using Common.Domain;
using Common.Events;

namespace LibraryService.Domain;

public class ReleaseId : Id
{
    private ReleaseId(Guid value) : base(value) { }
}

public class Release : AggregateRoot<ReleaseId>
{
    private ReleaseType Type { get; set; }
    private Artist Artist { get; set; }
    private IEnumerable<Record> Records { get; set; }

    public Release(ReleaseId id) : base(id)
    {
    }

    public Release(ReleaseId id, IEnumerable<Event> events) : base(id, events)
    {
    }

    protected override void When(dynamic evt)
    {
        throw new NotImplementedException();
    }
}