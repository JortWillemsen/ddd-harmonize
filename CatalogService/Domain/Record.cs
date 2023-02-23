using Common.Domain;

namespace LibraryService.Domain;

public class Record : ValueObject
{
    public int Order { get; set; }
    public Song Song { get; set; }
    
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }
}