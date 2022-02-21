using System;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    [Serializable]
    public class ShoppingCartItem : InventoryItem  // Class, does not include modifier (public, private)
    {

        public ShoppingCartItem(Product aProduct, int aQuantity)
            
        {
            Product = aProduct;
            Quantity = aQuantity;
        }
        /*
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
        */
        public decimal GetTotal()
        {
            return Product.Price * Quantity;
        }



    }
}
