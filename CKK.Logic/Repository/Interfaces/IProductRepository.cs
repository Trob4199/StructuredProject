using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.Logic.Repository.Interfaces
{
    internal interface IProductRepository: IRepository<Product>
    {
        Product Find(int id);
        IEnumerable<Product> Find(string name);
        IEnumerable<Product> GetItemsByQuantity();
        IEnumerable<Product> GetItemsByPrice();
    }
}
