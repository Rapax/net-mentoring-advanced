using MediatR;

namespace CatalogService.Application.CQRS.Categories.Commands
{
    public record AddNewCategoryCommand : IRequest<int>
    {
        public string Name { get; init; }

        public string? Image { get; init; }

        public int? ParentCategoryId { get; init; }
    }
}
