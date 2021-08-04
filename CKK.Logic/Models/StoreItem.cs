using System;


namespace CKK.Logic.Models
{
    public class StoreItem
    {
        Product Product;
        int Quantity;

        public StoreItem(Product aProduct, int aQuantity)
        {
            Product = aProduct;
            Quantity = aQuantity;
        }

        public void SetQuantity(int aQuantity)
        {
            Quantity = aQuantity;
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        public void SetProduct(Product aProduct)
        {
            Product = aProduct;
        }

        public Product GetProduct()
        {
            return Product;
        }

    }
}
