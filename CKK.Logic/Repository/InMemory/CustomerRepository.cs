using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;
using CKK.Logic.Repository.Interfaces;

namespace CKK.Logic.Repository.InMemory
{
    internal class CustomerRepository : ICustomerRepository
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
