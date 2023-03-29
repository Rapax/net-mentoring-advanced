using CatalogService.Domain.Entities;
using CatalogService.Domain.Repositories;
using MediatR;

namespace CatalogService.Application.CQRS.Products.Commands.Handlers
{
    internal class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddProductCommandHandler(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(request.CategoryId);
            if(category == null)
            {
                // TODO: Clarify how to handle this case
                return -1;
            }

            var product = new Product
            {
                Name = request.Name,
                CategoryId = category.Id,
                Image = request.Image,
                Description = request.Description,
                Amount = request.Amount,
                Price = request.Price,
            };

            _productRepository.Add(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
