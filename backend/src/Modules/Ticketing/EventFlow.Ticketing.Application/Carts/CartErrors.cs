using EventFlow.Common.Domain.Abstractions;

namespace EventFlow.Ticketing.Application.Carts;

public static class CartErrors
{
    public static readonly Error Empty = Error.Problem("Carts.Empty", "The cart is empty");
}
