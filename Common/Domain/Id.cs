namespace Common.Domain;

public abstract class Id : ValueObject
{
    public Guid Value { get; }

    protected Id(Guid value)
    {
        Value = value;
    }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}