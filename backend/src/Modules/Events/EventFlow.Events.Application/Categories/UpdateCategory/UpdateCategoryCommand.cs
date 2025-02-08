using EventFlow.Events.Application.Abstractions.Messaging;

namespace EventFlow.Events.Application.Categories.UpdateCategory;

public sealed record UpdateCategoryCommand(Guid CategoryId, string Name) : ICommand;
