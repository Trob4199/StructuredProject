using System;


namespace CKK.Logic.Models
{
    public class ShoppingCartItem  // Class, does not include modifier (public, private)
    {
        Product Product;
        int Quantity;

        public ShoppingCartItem(Product aProduct, int aQuantity)
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

        public decimal GetTotal()
        {
            return Product.GetPrice() * Quantity;
        }



    }
}
