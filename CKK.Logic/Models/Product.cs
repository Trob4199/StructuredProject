using System;


namespace CKK.Logic.Models
{
    public class Product
    {
        int Id;
        string Name;
        decimal Price;

        public void SetId(int ID)
        {
            Id = ID;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetName(string Name1)
        {
            Name = Name1;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetPrice(decimal Price1)
        {
            Price = Price1;
        }

        public decimal GetPrice()
        {
            return Price;
        }
    }
}
