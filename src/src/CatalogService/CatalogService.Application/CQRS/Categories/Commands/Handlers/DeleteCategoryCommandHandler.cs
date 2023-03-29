using CatalogService.Domain.Repositories;
using MediatR;

namespace CatalogService.Application.CQRS.Categories.Commands.Handlers
{
    internal class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(request.Id, cancellationToken, x => x.Products, x => x.ChildrenCategories);
            if(category == null)
            {
                // TODO: Clarify how to handle this case

                return false;
            }

            if (category.ChildrenCategories.Any())
            {
                // TODO: Clarify how to handle this case

                return false;
            }

            if(category.Products.Any())
            {
                // TODO: Clarify how to handle this case

                return false;
            }

            _categoryRepository.Delete(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
