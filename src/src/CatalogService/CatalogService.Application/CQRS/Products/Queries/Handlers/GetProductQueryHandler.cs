using CatalogService.Application.CQRS.Products.ViewModels;
using CatalogService.Domain.Repositories;
using MediatR;

namespace CatalogService.Application.CQRS.Products.Queries.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductViewModel?>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductViewModel?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.GetAsync(request.Id, cancellationToken, p => p.Category);
            if (entity == null)
            {
                return null;
            }

            return new ProductViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Image = entity.Image,
                Description = entity.Description,
                Price = entity.Price,
                Amount = entity.Amount,
                Category = new SimpleCategoryViewModel
                {
                    Id = entity.Category.Id,
                    Name = entity.Category.Name,
                }
            };
        }
    }
}
