using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Repository.Interfaces;
using CKK.Logic.Models;
using Dapper;

namespace CKK.Logic.Repository.InMemory
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly string _tableName = "Orders";

        public OrderRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public void Add(Order entity)
        {
            string OrderNum = "Trevor1";
            using (var conn = _connectionFactory.GetConnection)
            {
                string insertQuery = @"INSERT INTO [dbo].[Orders]([OrderNumber], [ShoppingCartId]) VALUES (@OrderNumber, @ShoppingCartId)";
                conn.Execute(insertQuery, entity);
            }
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
