using CKK.Logic.Models;

namespace CKK.Logic.Repository.Interfaces
{
    public interface IShoppingCartItemRepository
    {
        public int GetCustomerId(int shoppingCartId);
        public ShoppingCartItem AddToCart(int itemId, int quantity);
        public ShoppingCartItem AddToCart(string itemName, int quantity);
        public void AddToCart(ShoppingCartItem _shoppingCartItem);
        public void RemoveFromCart(int shoppingCartId, int itemId, int quantity = 1);
        public decimal GetTotal(int ShoppingCartId);
        public List<ShoppingCartItem> GetProducts(int shoppingCartId);
        public IEnumerable<ShoppingCartItem> GetProductsByCust(int customerId);
        public void Ordered(int shoppingCartId);

    }
}
