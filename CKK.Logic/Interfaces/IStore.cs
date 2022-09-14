using CKK.Logic.Models;
namespace CKK.Logic.Interfaces
{
    public interface IStore
    {
        Product AddProduct(Product item);
        Product UpdateProduct(Product item);
        Product FindByName(string name);
        List<Product> GetAllProducts();
        Product FindProductById(int id);
        public Product DeleteProduct(int id);
        public List<Product> GetProductsByName(string name);
        public List<Product> GetProductsByQuantity(int quantity);
        public List<Product> GetProductsByPrice(decimal price);
    }
}