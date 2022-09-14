using CKK.Logic.Models;

namespace CKK.Logic.Repository.Interfaces
{
    internal interface ICustomerRepository : IRepository<Customer>
    {
        Customer Find(int id);

    }
}
