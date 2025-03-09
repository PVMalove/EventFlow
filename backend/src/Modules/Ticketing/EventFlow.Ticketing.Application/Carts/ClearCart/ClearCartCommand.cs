using EventFlow.Common.Application.Messaging;

namespace EventFlow.Ticketing.Application.Carts.ClearCart;

public sealed record ClearCartCommand(Guid CustomerId) : ICommand;
