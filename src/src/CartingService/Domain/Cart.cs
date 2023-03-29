namespace CartingService.Domain
{
    public class Cart
    {
        public Guid Id { get; set; }

        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
