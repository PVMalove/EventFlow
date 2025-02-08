using EventFlow.Events.Domain.Abstractions;
using MediatR;

namespace EventFlow.Events.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
