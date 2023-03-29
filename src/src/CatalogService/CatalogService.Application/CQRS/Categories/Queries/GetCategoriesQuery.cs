using CatalogService.Application.CQRS.Categories.ViewModels;
using MediatR;

namespace CatalogService.Application.CQRS.Categories.Queries
{
    internal class GetCategoriesQuery : IRequest<IEnumerable<CategoryViewModel>>
    {
    }
}
