namespace EventFlow.Events.Presentation.TicketTypes.Request;

internal sealed class ChangeTicketTypePriceRequest
{
    public decimal Price { get; init; }
}