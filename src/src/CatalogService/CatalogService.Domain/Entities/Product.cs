using CatalogService.Domain.Common;

namespace CatalogService.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        public Category Category { get; set; }
    }
}
