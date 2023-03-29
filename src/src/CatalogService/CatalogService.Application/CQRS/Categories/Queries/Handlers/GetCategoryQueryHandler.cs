using CatalogService.Application.CQRS.Categories.ViewModels;
using CatalogService.Domain.Repositories;
using MediatR;

namespace CatalogService.Application.CQRS.Categories.Queries.Handlers
{
    internal class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryViewModel?>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryViewModel?> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(request.Id, cancellationToken);
            if (category == null)
            {
                // TODO: Clarify what should be done in this case
                return null;
            }

            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Image = category.Image,
                ParentCategory = new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Image = category.Image
                },
                ChildrenCategoryIds = category.ChildrenCategories.Select(c => c.Id)
            };
        }
    }
}
