namespace EventFlow.Events.Domain.Abstractions;

public abstract class Entity
{
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;
    
    private readonly List<IDomainEvent> _domainEvents = new();

    protected Entity() { }
    
    public void ClearDomainEvents() => _domainEvents.Clear();
    
    protected void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}