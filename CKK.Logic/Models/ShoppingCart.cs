using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class ShoppingCart:IShoppingCart
    {

        public ShoppingCart(Customer cust)
        {
            Customer = cust;
        }

        public int ShoppingCartId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer;
        public List<ShoppingCartItem> Products { get; set; }
        

    }
}
