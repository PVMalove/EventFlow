﻿using EventFlow.Ticketing.Application.Abstractions.Payments;

namespace EventFlow.Ticketing.Infrastructure.Payments;

internal sealed class PaymentService : IPaymentService
{
    public Task<PaymentResponse> ChargeAsync(decimal amount, string currency)
    {
        return Task.FromResult(new PaymentResponse(Guid.NewGuid(), amount, currency));
    }

    public Task RefundAsync(Guid transactionId, decimal amount)
    {
        return Task.CompletedTask;
    }
}
