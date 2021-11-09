using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public interface IStore
    {

        StoreItem AddStoreItem(Product prod, int quantity);


        StoreItem RemoveStoreItem(int id, int quantity);


        StoreItem FindStoreItemById(int Id);


        public List<StoreItem> GetStoreItems();

    }
}
