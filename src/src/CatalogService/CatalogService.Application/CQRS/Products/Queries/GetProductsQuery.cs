using CatalogService.Application.CQRS.Products.ViewModels;
using MediatR;

namespace CatalogService.Application.CQRS.Products.Queries
{
    public record GetProductsQuery : IRequest<IEnumerable<ProductViewModel>>
    {
        public int CategoryId { get; set; }
    }
}