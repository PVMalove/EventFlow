﻿using EventFlow.Common.Application.Messaging;

namespace EventFlow.Ticketing.Application.Carts.GetCart;

public sealed record GetCartQuery(Guid CustomerId) : IQuery<Cart>;
