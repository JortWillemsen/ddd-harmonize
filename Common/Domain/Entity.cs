namespace Common.Domain;

/// <summary>
/// Thanks to @EdwinVW on Github for this implementation
/// https://github.com/EdwinVW/pitstop/blob/main/src/WorkshopManagementAPI/Domain/Core/Entity.cs
/// </summary>
public abstract class Entity<TId> where TId : EntityId
{
    protected TId Id { get; set; }

    protected Entity(TId id)
    {
        Id = id;
    }
}