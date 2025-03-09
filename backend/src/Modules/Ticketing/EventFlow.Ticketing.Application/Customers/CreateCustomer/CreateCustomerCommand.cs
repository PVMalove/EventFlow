﻿using EventFlow.Common.Application.Messaging;

namespace EventFlow.Ticketing.Application.Customers.CreateCustomer;

public sealed record CreateCustomerCommand(Guid CustomerId, string Email, string FirstName, string LastName)
    : ICommand;
