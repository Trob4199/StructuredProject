using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    public interface IStore
    {

        StoreItem AddStoreItem(Product prod, int quantity);


        StoreItem RemoveStoreItem(int Id, int quantity);

        string DeleteStoreItem(int Id);


        StoreItem FindStoreItemById(int Id);


        public List<StoreItem> GetStoreItems();

        List<StoreItem> GetAllProductsByName(string name);

        List<StoreItem> GetProductsByQuantity();

        List<StoreItem> GetProductsByPrice();
    }
}
