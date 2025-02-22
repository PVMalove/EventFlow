namespace EventFlow.Events.Presentation.Events.Request;

internal sealed class RescheduleEventRequest
{
    public DateTime StartsAtUtc { get; init; }

    public DateTime? EndsAtUtc { get; init; }
}