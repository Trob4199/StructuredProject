using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Repository.Interfaces;
using CKK.Logic.Models;

namespace CKK.Logic.Repository.InMemory
{
    internal class OrderRepository : IOrderRepository
    {
        public void Add(OrderSummary entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderSummary> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(OrderSummary entity)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderSummary entity)
        {
            throw new NotImplementedException();
        }
    }
}
