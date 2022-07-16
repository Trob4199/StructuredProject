using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using CKK.Persistance.Interfaces;
using CKK.Logic.Exceptions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;


namespace CKK.Persistance.Models
{
    public class FileStore : ISavable, ILoadable
    {

        List<StoreItem> Items = new();
        readonly string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Persistance" + Path.DirectorySeparatorChar + "StoreItems.dat";
        int IdCounter;
        public BinaryFormatter formatter = new BinaryFormatter();
        public FileStream output;



        public FileStore()
        {
            Load();
            
        }




        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            int productid = prod.Id;
            int idIndex = 0;

            if (quantity < 0)
            {
                throw new InventoryItemStockTooLowException("Store Item quantity must be greater than 0");
            }
            if (productid == 0)
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
            if (quantity <= 0)
            {
                return null;
            }

            StoreItem storeItemtemp = new(prod, quantity);

            if (FindStoreItemById(productid) == null)
            {

                Items.Add(storeItemtemp);
                Save();
                return storeItemtemp;
                
            }
            else
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].GetProduct().Id == prod.Id)
                    {
                        Items[i].Quantity = (Items[i].Quantity + quantity);
                        idIndex = i;

                    }
                }




                Save();
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

            if (FindStoreItemById(id) != null)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].GetProduct().Id == id)
                    {
                        idIndex = i;
                        if (Items[i].Quantity > quantity)
                        {
                            Items[i].Quantity = (Items[i].Quantity - quantity);
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
                        Save();
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

        public void Save()
        {
            CreatePath();
            try
            {
                //open file with write access
                formatter.Serialize(output, Items);
                output.Close();
            }
            catch (IOException)
            {

            }



        }

        public void Load()
        {
            BinaryFormatter formatter2 = new BinaryFormatter();
            Stream input = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            
            Items = (List<StoreItem>)(formatter2.Deserialize(input));

            input.Close();
        }


        public void CreatePath()
        {

            try
            {
                //open file with write access
                output = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Write);

            }
            catch(IOException)
            {
                
            }
        }
    }
}
