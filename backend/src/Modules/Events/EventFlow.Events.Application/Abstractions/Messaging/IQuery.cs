using EventFlow.Events.Domain.Abstractions;
using MediatR;

namespace EventFlow.Events.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
