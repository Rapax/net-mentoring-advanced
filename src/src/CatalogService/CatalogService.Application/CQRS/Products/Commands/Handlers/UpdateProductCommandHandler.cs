using CatalogService.Domain.Repositories;
using MediatR;

namespace CatalogService.Application.CQRS.Products.Commands.Handlers
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(request.CategoryId);
            if (category == null)
            {
                // TODO: Clarify how to handle this case
                return -1;
            }

            var product = await _productRepository.GetAsync(request.Id);

            if(product == null)
            {
                // TODO: Clarify how to handle this case
                return -1;
            }

            product.Name = request.Name;
            product.CategoryId = category.Id;
            product.Image = request.Image;
            product.Description = request.Description;
            product.Amount = request.Amount;
            product.Price = request.Price;

            _productRepository.Update(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
