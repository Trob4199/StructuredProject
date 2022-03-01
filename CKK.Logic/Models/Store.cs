using System;
using System.Linq;
using System.Collections.Generic;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;


namespace CKK.Logic.Models
{
    public class Store : Entity, IStore
    {

         List<StoreItem> Items = new();
        

        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            int productid = prod.Id;
            int idIndex = 0;

            if (quantity < 0)
            {
                throw new InventoryItemStockTooLowException("Store Item quantity must be greater than 0");
            }
            if(productid == 0)
            {
                if (Items.Count > 0)
                {
                    int lastitemindex = Items.Count - 1;
                    int lastid = Items[lastitemindex].GetProduct().Id;
                    prod.Id = lastid + 1;
                }
                else
                {
                    prod.Id = 1;
                }
            }
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
                    if (Items[i].GetProduct().Id == prod.Id)
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

            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException("Quantity to remove must be greater than 0");
            }

            if(FindStoreItemById(id) != null)
            {
                for (int i =0; i < Items.Count; i++)
                {
                    if (Items[i].GetProduct().Id == id)
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
            else if (FindStoreItemById(id) == null)
            {
                throw new ProductDoesNotExistException("Product being removed does not exist.");
            }
            return null;
            

        }

        public String DeleteStoreItem(int id)
        {
            

            if (FindStoreItemById(id) != null)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].GetProduct().Id == id)
                    {
                        Items.RemoveAt(i); 
                    }
                }
                return "Deleted";
            }
            else if (FindStoreItemById(id) == null)
            {
                throw new ProductDoesNotExistException("Product being removed does not exist.");
            }
            return null;

        }
        public StoreItem FindStoreItemById(int Id)
        {

            if (Id < 0)
            {
                throw new InvalidIdException("Invalid Id, ID must be greater than 0");
            }

            if (Items.Count > 0)
            {
                var storeItem2 =
                    from item in Items
                    where item.GetProduct().Id == Id
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

        public List<StoreItem> GetAllProductsByName(string name)
        {
            List<StoreItem> StoreItems = new List<StoreItem>();

            for (int i = 0; i< Items.Count; i++)
            {
                var item = Items[i];
                if (item.Product.Name.Contains(name))
                {
                    StoreItems.Add(item);
                }
            }

            return StoreItems;
        }

        public List<StoreItem> GetProductsByQuantity()
        {
            List<StoreItem> ItemsByQuantity = new List<StoreItem>();

            return ItemsByQuantity;
        }

        public List<StoreItem> GetProductsByPrice()
        {
            List<StoreItem> ItemsByPrice = new List<StoreItem>();

            return ItemsByPrice;

        }

    }
}
