using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private decimal price;
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price must be greater than 0");
                }
                price = value;
            }
        }
        public int Quantity { get; set; }
        public override string ToString() => $"{Id} \t\t {Name} \t\t {Price:C} \t\t {Quantity}";


    }
}
