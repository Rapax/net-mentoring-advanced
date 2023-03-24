using CartingService.Domain;

namespace CartingService.DAL
{
    public interface ICartRepository
    {
        IEnumerable<CartItem> GetItems(Guid cartId);

        void AddItem(Guid cartId, CartItem item);

        void RemoveItem(Guid cartId, int itemId);
    }
}
