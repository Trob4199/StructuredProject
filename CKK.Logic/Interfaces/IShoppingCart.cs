using CKK.Logic.Models;
using System.Collections.Generic;

namespace CKK.Logic.Interfaces
{
    public interface IShoppingCart
    {
        int GetCustomerId();
        ShoppingCartItem AddProduct(Product prod, int Quantity);
        ShoppingCartItem RemoveProduct(int id, int Quantity);
        decimal GetTotal();
        ShoppingCartItem GetProductById(int id);
        List<ShoppingCartItem> GetProducts();

    }
}