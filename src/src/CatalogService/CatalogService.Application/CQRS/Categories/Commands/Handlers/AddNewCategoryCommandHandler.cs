using CatalogService.Domain.Entities;
using CatalogService.Domain.Repositories;
using MediatR;

namespace CatalogService.Application.CQRS.Categories.Commands.Handlers
{
    internal class AddNewCategoryCommandHandler : IRequestHandler<AddNewCategoryCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddNewCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddNewCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                Image = request.Image,
                ParentCategoryId = request.ParentCategoryId,
            };


            _categoryRepository.Add(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return category.Id;
        }
    }
}
