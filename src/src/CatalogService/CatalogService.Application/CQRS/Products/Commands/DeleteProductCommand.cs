using MediatR;

namespace CatalogService.Application.CQRS.Products.Commands
{
    public record DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
