namespace SharedKernel.Domain;

public abstract class DomainEvent
{
    public DateTime Timestamp { get; } = DateTime.UtcNow;
}
