namespace SharedKernel.Event;

public abstract record IntegrationEvent : IIntegrationEvent
{
    public Guid Id { get; set; }
    public DateTime Timestamp { get; set; }

    public IntegrationEvent()
    {
        Id = Guid.NewGuid();
        Timestamp = DateTime.Now;
    }
}
