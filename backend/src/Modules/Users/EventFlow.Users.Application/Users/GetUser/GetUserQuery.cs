﻿using EventFlow.Common.Application.Messaging;

namespace EventFlow.Users.Application.Users.GetUser;

public sealed record GetUserQuery(Guid UserId) : IQuery<UserResponse>;
