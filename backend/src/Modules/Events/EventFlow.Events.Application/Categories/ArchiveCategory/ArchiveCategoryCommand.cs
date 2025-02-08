using EventFlow.Events.Application.Abstractions.Messaging;

namespace EventFlow.Events.Application.Categories.ArchiveCategory;

public sealed record ArchiveCategoryCommand(Guid CategoryId) : ICommand;
