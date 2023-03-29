using MediatR;

namespace CatalogService.Application.CQRS.Categories.Commands
{
    public record UpdateCategoryCommand : IRequest<int>
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string? Image { get; init; }

        public int? ParentCategoryId { get; init; }
    }
}
