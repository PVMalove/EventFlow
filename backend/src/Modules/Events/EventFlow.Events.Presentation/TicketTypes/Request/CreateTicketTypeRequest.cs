namespace EventFlow.Events.Presentation.TicketTypes.Request;

internal sealed class CreateTicketTypeRequest
{
    public Guid EventId { get; init; }

    public string Name { get; init; }

    public decimal Price { get; init; }

    public string Currency { get; init; }

    public decimal Quantity { get; init; }
}