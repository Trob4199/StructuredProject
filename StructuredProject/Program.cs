using CKK.Logic.Models;
using System;   

namespace CKK.Logic.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            Store Store1 = new();
            Product Product1 = new();
            Customer Customer1 = new();
            Product Product2 = new();
            //var storeitem1 = new();
            

            Product1.SetId(1);
            Product1.SetName("Screw");
            Product1.SetPrice(.090m);
            Product2.SetId(3);
            Product2.SetName("Nail");
            Product2.SetPrice(.020m);

            Store1.AddStoreItem(Product1, 100);
            Store1.AddStoreItem(Product1, 100);
            Store1.AddStoreItem(Product2, -12);
            Store1.AddStoreItem(Product2, 100);


            Customer1.SetId(1);
            Customer1.SetName("Trevor");
            
            Customer1.SetAddress("Street");

            ShoppingCart ShoppingCart1 = new(Customer1);


            //ShoppingCartItem1.AddProduct(Product1, 10);

            ShoppingCart1.AddProduct(Product1,10);
            ShoppingCart1.AddProduct(Product1,10);
            ShoppingCart1.AddProduct(Product1,10);
            ShoppingCart1.RemoveProduct(1, 40);
            ShoppingCart1.AddProduct(Product1,-1);

            Console.WriteLine(ShoppingCart1.GetTotal());


            //Console.WriteLine(value: ShoppingCart.GetTotal());

        }
    }
}
