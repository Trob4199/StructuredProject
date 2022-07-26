using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.Logic.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<OrderSummary>
    {
        public void Add(OrderSummary entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderSummary> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByCustomerId(int id);

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
