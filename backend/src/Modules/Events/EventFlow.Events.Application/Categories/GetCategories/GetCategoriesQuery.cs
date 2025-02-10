using EventFlow.Common.Application.Messaging;
using EventFlow.Events.Application.Categories.GetCategory;

namespace EventFlow.Events.Application.Categories.GetCategories;

public sealed record GetCategoriesQuery : IQuery<IReadOnlyCollection<CategoryResponse>>;
