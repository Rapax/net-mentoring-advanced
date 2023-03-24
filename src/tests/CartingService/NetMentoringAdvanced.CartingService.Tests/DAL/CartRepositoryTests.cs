using LiteDB;
using NetMentoringAdvanced.CartingService.DAL;
using NetMentoringAdvanced.CartingService.Domain;

namespace NetMentoringAdvanced.CartingService.Tests.DAL
{
    [TestFixture]
    public class CartRepositoryTests
    {
        private LiteDatabase _database;
        private CartRepository _cartRepository;

        [SetUp]
        public void Setup()
        {
            _database = new LiteDatabase(":memory:");
            _cartRepository = new CartRepository(_database);
        }

        [Test]
        public void AddItem_ShouldAddItemToCart()
        {
            // Arrange
            var cartId = Guid.NewGuid();
            var item = new CartItem { Id = 1, Name = "Test Item", Price = 9.99M };

            // Act
            _cartRepository.AddItem(cartId, item);

            // Assert
            var cart = _database.GetCollection<Cart>("carts").FindOne(c => c.Id == cartId);
            Assert.IsNotNull(cart);
            Assert.That(cart.Items.Count(), Is.EqualTo(1));
            var cartItem = cart.Items.Single();
            Assert.Multiple(() =>
            {
                Assert.That(cartItem.Id, Is.EqualTo(item.Id));
                Assert.That(cartItem.Name, Is.EqualTo(item.Name));
                Assert.That(cartItem.Image, Is.EqualTo(item.Image));
                Assert.That(cartItem.Quantity, Is.EqualTo(item.Quantity));
            });
        }

        [Test]
        public void GetItems_ShouldReturnItemsInCart()
        {
            // Arrange
            var cartId = Guid.NewGuid();
            var item1 = new CartItem { Id = 1, Name = "Test Item 1", Price = 9.99M };
            var item2 = new CartItem { Id = 2, Name = "Test Item 2", Price = 19.99M };
            _cartRepository.AddItem(cartId, item1);
            _cartRepository.AddItem(cartId, item2);

            // Act
            var items = _cartRepository.GetItems(cartId);

            // Assert
            Assert.IsNotNull(items);
            Assert.That(items.Count(), Is.EqualTo(2));

            var firstItem = items.First();
            Assert.Multiple(() =>
            {
                Assert.That(firstItem.Id, Is.EqualTo(item1.Id));
                Assert.That(firstItem.Name, Is.EqualTo(item1.Name));
                Assert.That(firstItem.Image, Is.EqualTo(item1.Image));
                Assert.That(firstItem.Quantity, Is.EqualTo(item1.Quantity));
            });

            var secondItem = items.Last();
            Assert.Multiple(() =>
            {
                Assert.That(secondItem.Id, Is.EqualTo(item2.Id));
                Assert.That(secondItem.Name, Is.EqualTo(item2.Name));
                Assert.That(secondItem.Image, Is.EqualTo(item2.Image));
                Assert.That(secondItem.Quantity, Is.EqualTo(item2.Quantity));
            });
        }

        [Test]
        public void RemoveItem_ShouldRemoveItemFromCart()
        {
            // Arrange
            var cartId = Guid.NewGuid();
            var item1 = new CartItem { Id = 1, Name = "Test Item 1", Price = 9.99M };
            var item2 = new CartItem { Id = 2, Name = "Test Item 2", Price = 19.99M };
            _cartRepository.AddItem(cartId, item1);
            _cartRepository.AddItem(cartId, item2);

            // Act
            _cartRepository.RemoveItem(cartId, item1.Id);

            // Assert
            var cart = _database.GetCollection<Cart>("carts").FindOne(c => c.Id == cartId);
            Assert.IsNotNull(cart);
            Assert.That(cart.Items.Count(), Is.EqualTo(1));

            var cartItem = cart.Items.Single();
            Assert.Multiple(() =>
            {
                Assert.That(cartItem.Id, Is.EqualTo(item2.Id));
                Assert.That(cartItem.Name, Is.EqualTo(item2.Name));
                Assert.That(cartItem.Image, Is.EqualTo(item2.Image));
                Assert.That(cartItem.Quantity, Is.EqualTo(item2.Quantity));
            });
        }
    }
}
