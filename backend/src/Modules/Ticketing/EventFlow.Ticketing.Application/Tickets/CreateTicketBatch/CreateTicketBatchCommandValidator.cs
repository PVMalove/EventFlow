﻿using FluentValidation;

namespace EventFlow.Ticketing.Application.Tickets.CreateTicketBatch;

internal sealed class CreateTicketBatchCommandValidator : AbstractValidator<CreateTicketBatchCommand>
{
    public CreateTicketBatchCommandValidator()
    {
        RuleFor(c => c.OrderId).NotEmpty();
    }
}
