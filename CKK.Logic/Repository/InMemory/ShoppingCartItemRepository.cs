using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Repository.Interfaces;
using CKK.Logic.Models;

namespace CKK.Logic.Repository.InMemory
{
    internal class ShoppingCartItemRepository : IShoppingCartItemRepository
    {

        public int GetCustomerId(int shoppingCartId)
        {
            throw new NotImplementedException();
        }
        public ShoppingCartItem AddToCart(int itemId, int quantity)
        {
            throw new NotImplementedException();
        }
        public ShoppingCartItem AddToCart(string itemName, int quantity)
        {
            throw new NotImplementedException();
        }
        public ShoppingCartItem RemoveFromCart(int shoppingCartId, int itemId, int quantity = 1)
        {
            throw new NotImplementedException();
        }
        public decimal GetTotal(int ShoppingCartId)
        {
            throw new NotImplementedException();
        }
        public List<ShoppingCartItem> GetProducts(int shoppingCartId)
        {
            throw new NotImplementedException();
        }
    }
}
