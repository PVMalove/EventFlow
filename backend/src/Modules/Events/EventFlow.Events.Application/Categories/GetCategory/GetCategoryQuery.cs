using EventFlow.Events.Application.Abstractions.Messaging;

namespace EventFlow.Events.Application.Categories.GetCategory;

public sealed record GetCategoryQuery(Guid CategoryId) : IQuery<CategoryResponse>;
