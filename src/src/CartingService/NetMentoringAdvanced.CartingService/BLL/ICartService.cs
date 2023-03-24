using NetMentoringAdvanced.CartingService.Domain;

namespace NetMentoringAdvanced.CartingService.BLL
{
    public interface ICartService
    {
        IEnumerable<CartItem> GetItems(Guid cartId);

        void AddItem(Guid cartId, CartItem item);

        void RemoveItem(Guid cartId, int itemId);
    }
}
