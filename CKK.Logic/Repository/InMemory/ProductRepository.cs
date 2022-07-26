using CKK.Logic.Models;
using CKK.Logic.Repository.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CKK.Logic.Repository.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly string _tableName = "Products";
        public ProductRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public void Add(Product entity)
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                string insertQuery = @"INSERT INTO [dbo].[Products]([Price], [Quantity], [Name]) VALUES (@Price, @Quantity, @Name)";
                conn.Execute(insertQuery, entity);
            }
        }
        public Product Find(int id)
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                var result = conn.QuerySingleOrDefault<Product>($"SELECT * FROM {_tableName} WHERE Id = @Id", new { Id = id });
                if (result == null)
                    throw new KeyNotFoundException($"{_tableName} with id [{id}] could not be found.");
                return result;
            }
        }
        public IEnumerable<Product> GetAll()
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                var result = conn.Query<Product>($"SELECT * FROM {_tableName}");
                return result;
            }
        }
        public IEnumerable<Product> GetItemsByName(string name)
        {
            using (var conn = _connectionFactory.GetConnection)
            {

                var result = conn.Query<Product>($"SELECT * FROM {_tableName} WHERE Name like '%' + @Name + '%'", new { Name = name });
                if (result == null)
                    throw new KeyNotFoundException($"{_tableName} with name [{name}] could not be found.");
                return result;
            }
        }
        public IEnumerable<Product> GetItemsByPrice(decimal price)
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                return conn.Query<Product>($"SELECT * FROM {_tableName} WHERE Price = @price", new { price });
            }
        }
        public IEnumerable<Product> GetItemsByQuantity(int quantity)
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                return conn.Query<Product>($"SELECT * FROM {_tableName} WHERE quantity = @quantity", new { quantity });
            }
        }
        public void Remove(Product entity)
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                conn.Execute($"DELETE FROM {_tableName} WHERE Id=@Id", new { entity.Id });
            }
        }
        public void Update(Product entity)
        {
            var query = "UPDATE Products SET Name = @Name, Price = @Price, Quantity = @Quantity WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", entity.Id, DbType.Int32);
            parameters.Add("Name", entity.Name, DbType.String);
            parameters.Add("Price", entity.Price, DbType.String);
            parameters.Add("Quantity", entity.Quantity, DbType.String);
            using (var conn = _connectionFactory.GetConnection)
            {
                conn.Execute(query, parameters);
            }
        }
    }
}
