using EventFlow.Common.Domain.Abstractions;
using MediatR;

namespace EventFlow.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
