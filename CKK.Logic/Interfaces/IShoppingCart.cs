using System.Collections.Generic;

namespace CKK.Logic.Models
{
    public interface IShoppingCart
    {
        List<ShoppingCartItem> Products2 { get; }

        ShoppingCartItem AddProduct(Product prod, int quantity);
        int GetCustomerID();
        ShoppingCartItem GetProductById(int id);
        List<ShoppingCartItem> GetProducts();
        decimal GetTotal();
        ShoppingCartItem RemoveProduct(int id, int quantity);
    }
}