using CKK.Logic.Interfaces;
using System;

namespace CKK.Logic.Models
{
    public class Product : Entity
    {
        decimal price;
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price must be greater than 0");
                }
                price = value;
            }
        }

    }
}
