using EventFlow.Events.Domain.Abstractions;
using MediatR;

namespace EventFlow.Events.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;
