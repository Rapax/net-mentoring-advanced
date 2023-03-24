using LiteDB;
using NetMentoringAdvanced.CartingService.Domain;

namespace NetMentoringAdvanced.CartingService.DAL
{
    internal class CartRepository : ICartRepository
    {
        private readonly LiteDatabase _database;

        public CartRepository(LiteDatabase database)
        {
            _database = database;
        }

        public void AddItem(Guid cartId, CartItem item)
        {
            var cart = _database.GetCollection<Cart>("carts").FindOne(c => c.Id == cartId);

            if (cart == null)
            {
                cart = new Cart { Id = cartId, Items = new List<CartItem>() };
                _database.GetCollection<Cart>("carts").Insert(cart);
            }

            cart.Items.Add(item);
            _database.GetCollection<Cart>("carts").Update(cart);
        }

        public IEnumerable<CartItem> GetItems(Guid cartId)
        {
            var cart = _database.GetCollection<Cart>("carts").FindOne(c => c.Id == cartId);
            return cart?.Items ?? Enumerable.Empty<CartItem>();
        }

        public void RemoveItem(Guid cartId, int itemId)
        {
            var cart = _database.GetCollection<Cart>("carts").FindOne(c => c.Id == cartId);
            if (cart != null)
            {
                cart.Items.RemoveAll(i => i.Id == itemId);
                _database.GetCollection<Cart>("carts").Update(cart);
            }
        }
    }
}
