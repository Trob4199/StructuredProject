using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.Logic.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        public void Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByCustomerId(int id);

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
