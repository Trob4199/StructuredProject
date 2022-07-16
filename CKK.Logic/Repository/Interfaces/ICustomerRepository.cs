using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.Logic.Repository.Interfaces
{
    internal interface ICustomerRepository : IRepository<Customer>
    {
        Customer Find(int id);

    }
}
