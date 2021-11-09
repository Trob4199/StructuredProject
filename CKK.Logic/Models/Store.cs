using System;
using System.Linq;
using System.Collections.Generic;
using CKK.Logic.Interfaces;


namespace CKK.Logic.Models
{
    public class Store : Entity, IStore
    {

        List<StoreItem> Items = new();
        

        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            int productid = prod.id;
            int idIndex = 0;

            if(quantity <= 0)
            {
                return null;
            }

            StoreItem storeItemtemp = new(prod, quantity);

            if (FindStoreItemById(productid) == null)
            {

                Items.Add(storeItemtemp);
                return storeItemtemp;
            }
            else
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].GetProduct().id == prod.id)
                    {
                        Items[i].Quantity=(Items[i].Quantity + quantity);
                        idIndex = i;

                    }
                }

                return Items[idIndex];

            }
           
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            int idIndex = 0;

            if(FindStoreItemById(id) != null)
            {
                for (int i =0; i < Items.Count; i++)
                {
                    if (Items[i].GetProduct().id == id)
                    {
                        idIndex = i;
                        if (Items[i].Quantity > quantity)
                        {
                            Items[i].Quantity=(Items[i].Quantity - quantity);
                        }
                        else Items[i].Quantity = 0;
                        

                    }
                }
                return Items[idIndex];
            }
            return null;
            

        }

        public StoreItem FindStoreItemById(int Id)
        {



            if (Items.Count > 0)
            {
                var storeItem2 =
                    from item in Items
                    where item.GetProduct().id == Id
                    select item;

                return storeItem2.FirstOrDefault();

                //var storeItem1 =
                //Items.Where(f => f.GetProduct().GetId() == Id).FirstOrDefault();


                //return storeItem1;
            }

            return null;

        }

        public List<StoreItem> GetStoreItems()
        {
            return Items;
        }

    }
}
