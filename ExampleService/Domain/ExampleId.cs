using Common.Domain;

namespace ExampleService.Domain;

public class ExampleId : Id
{
    public ExampleId(Guid id) : base(id) {}
    public ExampleId() { }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}