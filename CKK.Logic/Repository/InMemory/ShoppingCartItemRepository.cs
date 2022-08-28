using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Repository.Interfaces;
using CKK.Logic.Models;
using Dapper;
using System.ComponentModel.DataAnnotations;

namespace CKK.Logic.Repository.InMemory
{
    public class ShoppingCartItemRepository : IShoppingCartItemRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly string _tableName = "ShoppingCarts";

        public ShoppingCartItemRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

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
        public void AddToCart(ShoppingCartItem _shoppingCartItem)
        {
            var customerId = _shoppingCartItem.CustomerId;
            var itemId = _shoppingCartItem.ProductId;
            var quantity = _shoppingCartItem.Quantity;
            //var shoppingCartId = 1.0;

            using (var conn = _connectionFactory.GetConnection)
            {
                string insertQuery = @"INSERT INTO [dbo].[ShoppingCarts]([ShoppingCartId],[CustomerId], [ProductId], [Quantity],[Ordered]) VALUES (2, @customerId, @ProductId, @Quantity,0)";
                conn.Execute(insertQuery, _shoppingCartItem);
            }
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
            using (var conn = _connectionFactory.GetConnection)
            {
                var result = conn.Query<ShoppingCartItem>($"SELECT * FROM {_tableName} WHERE ShoppingCartId = @shoppingCartId AND Ordered != 1", new { ShoppingCartId = shoppingCartId }).ToList();

                return result;
            }
        }

        public void Ordered(int shoppingCartId)
        {
            int ordered = 1;
            using (var conn = _connectionFactory.GetConnection)
            {
                conn.Execute($"UPDATE {_tableName} SET Ordered = 1 WHERE ShoppingCartId = @shoppingCartId", new {ShoppingCartId = shoppingCartId });
            }
        }
        public IEnumerable<ShoppingCartItem> GetProductsByCust(int customerId)
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                var result = conn.Query<ShoppingCartItem>($"SELECT * FROM {_tableName} WHERE CustomerId = @customerId", new{CustomerId = customerId});
                
                return result;
            }


            
        }
    }
}
