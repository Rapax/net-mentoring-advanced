using NetMentoringAdvanced.CartingService.DAL;
using NetMentoringAdvanced.CartingService.Domain;

namespace NetMentoringAdvanced.CartingService.BLL
{
    internal class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void AddItem(Guid cartId, CartItem item)
        {
            _cartRepository.AddItem(cartId, item);
        }

        public IEnumerable<CartItem> GetItems(Guid cartId)
        {
            return _cartRepository.GetItems(cartId);
        }

        public void RemoveItem(Guid cartId, int itemId)
        {
            _cartRepository.RemoveItem(cartId, itemId);
        }
    }
}
