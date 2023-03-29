using CatalogService.Application.CQRS.Products.ViewModels;
using MediatR;

namespace CatalogService.Application.CQRS.Products.Queries
{
    public record GetProductQuery : IRequest<ProductViewModel>
    {
        public int Id { get; init; }
    }
}
