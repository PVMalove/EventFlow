using EventFlow.Common.Application.Messaging;

namespace EventFlow.Ticketing.Application.Payments.RefundPayment;

public sealed record RefundPaymentCommand(Guid PaymentId, decimal Amount) : ICommand;
