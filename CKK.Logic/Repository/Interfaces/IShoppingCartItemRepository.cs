using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.Logic.Repository.Interfaces
{
    public class IShoppingCartItemRepository
    {
        public int GetCustomerId(int shoppingCartId);
        public ShoppingCartItem AddToCart(int itemId, int quantity);
        public ShoppingCartItem AddToCart(string itemName, int quantity);
        public ShoppingCartItem RemoveFromCart(int shoppingCartId, int itemId, int quantity = 1);
        public decimal GetTotal(int ShoppingCartId);
        public List<ShoppingCartItem> GetProducts(int shoppingCartId);
    }
}
