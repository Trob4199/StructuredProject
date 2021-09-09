using CKK.Logic.Models;
using System;   

namespace CKK.Logic.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            Product Product1 = new();
            Customer Customer1 = new();
            Product Product2 = new();
            

            Product1.SetId(1);
            Product1.SetName("Screw");
            Product1.SetPrice(.090m);

            Customer1.SetId(1);
            Customer1.SetName("Trevor");
            
            Customer1.SetAddress("Street");

            ShoppingCart ShoppingCart1 = new(Customer1);


            //ShoppingCartItem1.AddProduct(Product1, 10);

            ShoppingCart1.AddProduct(Product1,10);
            ShoppingCart1.AddProduct(Product1,10);
            ShoppingCart1.AddProduct(Product1,10);
            ShoppingCart1.AddProduct(Product1,-1);

            Console.WriteLine(ShoppingCart1.GetTotal());


            //Console.WriteLine(value: ShoppingCart.GetTotal());

        }
    }
}
