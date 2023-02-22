namespace Common.Domain;

public abstract class Id : ValueObject
{
    public Guid Value { get; }

    protected Id()
    {
        Value = Guid.NewGuid();
    }

    protected Id(Guid value)
    {
        Value = value;
    }
}