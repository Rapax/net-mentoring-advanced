using CatalogService.Application.CQRS.Categories.ViewModels;
using MediatR;

namespace CatalogService.Application.CQRS.Categories.Queries
{
    public record GetCategoryQuery : IRequest<CategoryViewModel>
    {
        public int Id { get; init; }
    }
}
