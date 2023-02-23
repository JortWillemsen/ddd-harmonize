namespace Common.Domain;

public abstract class EntityId : ValueObject
{
    public Guid Value { get; }

    protected EntityId(Guid value)
    {
        Value = value;
    }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}