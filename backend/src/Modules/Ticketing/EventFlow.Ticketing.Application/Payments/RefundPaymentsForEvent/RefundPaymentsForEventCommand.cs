using EventFlow.Common.Application.Messaging;

namespace EventFlow.Ticketing.Application.Payments.RefundPaymentsForEvent;

public sealed record RefundPaymentsForEventCommand(Guid EventId) : ICommand;
