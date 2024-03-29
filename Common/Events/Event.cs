﻿using Common.Domain;
using Wrappit.Messaging;

namespace Common.Events;

public abstract class Event : DomainEvent
{
    public Event(Guid aggregateId)
    {
        AggregateId = aggregateId;
        Id = Guid.NewGuid();
        Timestamp = DateTime.UtcNow;
    }
    
    public Guid Id { get; set; }
    public Guid AggregateId { get; set; }
    
    public DateTime Timestamp { get; set; }
}