namespace CatalogService.Application.CQRS.Products.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        public SimpleCategoryViewModel Category { get; set; }
    }
}
