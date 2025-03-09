using EventFlow.Ticketing.Domain.Events;

namespace EventFlow.Ticketing.Domain.Tickets;

public interface ITicketRepository
{
    Task<IEnumerable<Ticket>> GetForEventAsync(Event @event, CancellationToken cancellationToken = default);

    void InsertRange(IEnumerable<Ticket> tickets);
}