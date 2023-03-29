using MediatR;

namespace CatalogService.Application.CQRS.Categories.Commands
{
    public record DeleteCategoryCommand : IRequest<bool>
    {
        public int Id { get; init; }
    }
}
