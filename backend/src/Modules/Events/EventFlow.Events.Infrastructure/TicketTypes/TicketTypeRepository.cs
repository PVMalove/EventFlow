using EventFlow.Events.Domain.TicketTypes;
using EventFlow.Events.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Events.Infrastructure.TicketTypes;

internal sealed class TicketTypeRepository(EventsDbContext context) : ITicketTypeRepository
{
    public async Task<TicketType?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.TicketTypes.SingleOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<bool> ExistsAsync(Guid eventId, CancellationToken cancellationToken = default)
    {
        return await context.TicketTypes.AnyAsync(t => t.EventId == eventId, cancellationToken);
    }

    public void Insert(TicketType ticketType)
    {
        context.TicketTypes.Add(ticketType);
    }
}
