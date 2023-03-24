using NetMentoringAdvanced.CartingService.Domain;

namespace NetMentoringAdvanced.CartingService.DAL
{
    public interface ICartRepository
    {
        IEnumerable<CartItem> GetItems(Guid cartId);

        void AddItem(Guid cartId, CartItem item);

        void RemoveItem(Guid cartId, int itemId);
    }
}
