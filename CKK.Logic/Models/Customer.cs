using System;

namespace CKK.Logic.Models
{
    public class Customer
    {
        private int Id;
        private string Name;
        private string Address;


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
        
        public void SetAddress(string Address1)
        {
            Address = Address1;
        }

        public string GetAddress()
        {
            return Address;
        }
    }
}
