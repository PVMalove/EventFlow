﻿using EventFlow.Common.Domain.Abstractions;

namespace EventFlow.Ticketing.Domain.Payments;

public sealed class PaymentPartiallyRefundedDomainEvent(Guid paymentId, Guid transactionId, decimal refundAmount)
    : DomainEvent
{
    public Guid PaymentId { get; init; } = paymentId;

    public Guid TransactionId { get; init; } = transactionId;

    public decimal RefundAmount { get; init; } = refundAmount;
}
