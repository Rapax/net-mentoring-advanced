using CatalogService.Domain.Repositories;
using MediatR;

namespace CatalogService.Application.CQRS.Categories.Commands.Handlers
{
    internal class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(request.Id);
            if (category == null)
            {
                // TODO: Clarify how to handle this case

                return -1;
            }

            category.Name = request.Name;
            category.Image = request.Image;
            category.ParentCategoryId = request.ParentCategoryId;

            _categoryRepository.Update(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return category.Id;
        }
    }
}
