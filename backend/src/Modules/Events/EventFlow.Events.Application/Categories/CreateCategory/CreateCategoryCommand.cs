using EventFlow.Common.Application.Messaging;

namespace EventFlow.Events.Application.Categories.CreateCategory;

public sealed record CreateCategoryCommand(string Name) : ICommand<Guid>;
