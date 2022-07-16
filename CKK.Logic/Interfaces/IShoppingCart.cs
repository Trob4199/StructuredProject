using CKK.Logic.Models;
using System.Collections.Generic;

namespace CKK.Logic.Interfaces
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