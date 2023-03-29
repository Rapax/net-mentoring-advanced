using MediatR;

namespace CatalogService.Application.CQRS.Products.Commands
{
    public record AddProductCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        public int CategoryId { get; set; }
    }
}
