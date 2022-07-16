using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {

        //public ShoppingCart(Customer cust)
        //{
           // Customer = cust;
        //}
        
        public int ShoppingCartId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<ShoppingCartItem> ShoppingCartList { get; set; } = new List<ShoppingCartItem>();



    }
}
