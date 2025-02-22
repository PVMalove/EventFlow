namespace EventFlow.Events.Presentation.Events.Request;

internal sealed class CreateEventRequest
{
    public Guid CategoryId { get; init; }

    public string Title { get; init; }

    public string Description { get; init; }

    public string Location { get; init; }

    public DateTime StartsAtUtc { get; init; }

    public DateTime? EndsAtUtc { get; init; }
}