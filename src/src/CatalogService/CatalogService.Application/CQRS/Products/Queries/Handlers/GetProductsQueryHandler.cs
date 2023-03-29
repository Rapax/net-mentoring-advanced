using CatalogService.Application.CQRS.Products.ViewModels;
using CatalogService.Domain.Repositories;
using MediatR;

namespace CatalogService.Application.CQRS.Products.Queries.Handlers
{
    internal class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductViewModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _productRepository.GetAllAsync(p => p.CategoryId == request.CategoryId, cancellationToken, p => p.Category);

            return entities.Select(e => new ProductViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Image = e.Image,
                Description = e.Description,
                Price = e.Price,
                Amount = e.Amount,
                Category = new SimpleCategoryViewModel
                {
                    Id = e.Category.Id,
                    Name = e.Category.Name,
                }
            });
        }
    }
}
