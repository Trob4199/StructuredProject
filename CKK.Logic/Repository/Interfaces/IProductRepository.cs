using CKK.Logic.Models;

namespace CKK.Logic.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Find(int id);
        Product FindByName(string name);
        IEnumerable<Product> GetItemsByName(string name);
        IEnumerable<Product> GetItemsByQuantity(int quantity);
        IEnumerable<Product> GetItemsByPrice(decimal price);


    }
}
