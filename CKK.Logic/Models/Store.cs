using System;
using System.Linq;
using System.Collections.Generic;


namespace CKK.Logic.Models
{
    public class Store
    {
        int Id;
        string Name;
        List<StoreItem> Items = new();

        
        Product Product1;
        Product Product2;
        Product Product3;
        
        public void SetId(int aId)
        {
            Id = aId;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetName(string aName)
        {
            Name = aName;
        }

        public string GetName()
        {
            return Name;
        }

        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            int productid = prod.GetId();
            int idIndex = 0;

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
                    if (Items[i].GetProduct().GetId() == prod.GetId())
                    {
                        Items[i].SetQuantity(Items[i].GetQuantity() + quantity);
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
                    if (Items[i].GetProduct().GetId() == id)
                    {
                        idIndex = i;
                        if (Items[i].GetQuantity() < quantity)
                        {
                            Items[i].SetQuantity(Items[i].GetQuantity() - quantity);
                        }
                        else Items[i].SetQuantity(0);
                        

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
                    where item.GetProduct().GetId() == Id
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
