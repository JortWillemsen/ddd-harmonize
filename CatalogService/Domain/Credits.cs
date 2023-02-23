using Common.Domain;

namespace LibraryService.Domain;

public class Credits : ValueObject
{
    private Artist ProducedBy { get; set; }
    private Artist WrittenBy { get; set; }
    private Artist PerformedBy { get; set; }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return ProducedBy;
        yield return WrittenBy;
        yield return PerformedBy;
    }
}