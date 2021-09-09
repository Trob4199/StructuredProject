using Microsoft.VisualStudio.TestTools.UnitTesting;
using CKK.Logic.Models;

namespace CKK.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddCart()
        {
            Product Product1 = new();
            Customer Customer1 = new();
            Product Product2 = new();


            Product1.SetId(1);
            Product1.SetName("Screw");
            Product1.SetPrice(.090m);

            Product2.SetId(2);
            Product2.SetName("Hammer");
            Product2.SetPrice(12.50m);

            Customer1.SetId(1);
            Customer1.SetName("Trevor");

            Customer1.SetAddress("Street");

            ShoppingCart ShoppingCart1 = new(Customer1);
            ShoppingCartItem addtest = ShoppingCart1.AddProduct(Product1, 10);

            Assert.IsNotNull(ShoppingCart1.AddProduct(Product1, 10));
            

        }
        [TestMethod]
        public void RemoveItem()
        {
            Product Product1 = new();
            Customer Customer1 = new();
            Product Product2 = new();


            Product1.SetId(1);
            Product1.SetName("Screw");
            Product1.SetPrice(.090m);

            Product2.SetId(2);
            Product2.SetName("Hammer");
            Product2.SetPrice(12.50m);

            Customer1.SetId(1);
            Customer1.SetName("Trevor");

            Customer1.SetAddress("Street");

            ShoppingCart ShoppingCart1 = new(Customer1);
            ShoppingCart1.AddProduct(Product1, 10);

            Assert.IsNull(ShoppingCart1.RemoveProduct(Product1, 10));
        }

        [TestMethod]
        public void CartTotal()
        {
            Product Product1 = new();
            Customer Customer1 = new();
            Product Product2 = new();


            Product1.SetId(1);
            Product1.SetName("Screw");
            Product1.SetPrice(.090m);

            Product2.SetId(2);
            Product2.SetName("Hammer");
            Product2.SetPrice(12.50m);

            Customer1.SetId(1);
            Customer1.SetName("Trevor");

            Customer1.SetAddress("Street");

            ShoppingCart ShoppingCart1 = new(Customer1);
            ShoppingCart1.AddProduct(Product1, 10);
            ShoppingCart1.AddProduct(Product2, 3);
            decimal total = 38.40m;

            Assert.AreEqual(ShoppingCart1.GetTotal(),total);
        }
    }
}
