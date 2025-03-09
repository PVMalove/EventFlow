using EventFlow.Common.Application.Messaging;

namespace EventFlow.Ticketing.Application.Customers.GetCustomer;

public sealed record GetCustomerQuery(Guid CustomerId) : IQuery<CustomerResponse>;
