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
        public Order GetOrderByCustomerId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
