using System;


namespace CKK.Logic.Models
{
    public class Store
    {
        int Id;
        string Name;
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

        public void AddStoreItem(Product prod)
        {
            if (Product1 == null)
            {
                Product1 = prod;
            }
            else if (Product2 == null)
            {
                Product2 = prod;
            }
            else if (Product3 == null)
            {
                Product3 = prod;
            }
        }

        public void RemoveStoreItem(int productNum)
        {
            if (productNum == 1)
            {
                Product1 = null;
            }
            else if (productNum == 2) 
            {
                Product2 = null;
            }
            else if (productNum == 3)
            {
                Product3 = null;
            }
        }

        public Product GetStoreItem(int productNum)
        {
            if (productNum == 1)
            {
                return Product1;
            }
            else if (productNum == 2)
            {
                return Product2;
            }
            else if (productNum == 3)
            {
                return Product3;
            }
            else return null;
        }

        public Product FindStoreItemById(int Id)
        {
            if (Id == 1)
            {
                return Product1;
            }
            else if (Id == 2)
            {
                return Product2;
            }
            else if (Id == 3)
            {
                return Product3;
            }
            else return null;
        }

    }
}
