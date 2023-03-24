using CartingService.Domain;

namespace CartingService.BLL
{
    public interface ICartService
    {
        IEnumerable<CartItem> GetItems(Guid cartId);

        void AddItem(Guid cartId, CartItem item);

        void RemoveItem(Guid cartId, int itemId);
    }
}
