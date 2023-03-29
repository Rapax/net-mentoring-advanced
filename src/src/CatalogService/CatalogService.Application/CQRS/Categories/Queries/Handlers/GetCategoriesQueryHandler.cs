using CatalogService.Application.CQRS.Categories.ViewModels;
using CatalogService.Domain.Repositories;
using MediatR;

namespace CatalogService.Application.CQRS.Categories.Queries.Handlers
{
    internal class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryViewModel>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryViewModel>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync(null, cancellationToken, c => c.ParentCategory, c => c.ChildrenCategories);

            return categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                ParentCategory = new CategoryViewModel 
                { 
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image 
                },
                ChildrenCategoryIds = x.ChildrenCategories.Select(c => c.Id)
            });
        }
    }
}
