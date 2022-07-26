using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class OrderSummary
    {
        public OrderSummary(IShoppingCart cart)
        {
            Cart = cart;
        }

        public IShoppingCart Cart { get; set; }

        
    }
}
