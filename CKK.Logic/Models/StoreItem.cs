﻿using CKK.Logic.Interfaces;


namespace CKK.Logic.Models
{
    [Serializable]
    public class StoreItem : InventoryItem
    {

        public StoreItem(Product aProduct, int aQuantity)
        {
            Product = aProduct;
            Quantity = aQuantity;
        }

        /*
        public int quantity
        {
            get
            {
                return Quantity;
            }
            set
            {
                if (value >= 0)
                {
                    Quantity = aQuantity;
                }

                else Quantity = 0;
            }

            
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        */
        public void SetProduct(Product aProduct)
        {
            Product = aProduct;
        }

        public Product GetProduct()
        {
            return Product;
        }

        public override string ToString()
        {
            string str = ($"{Product.Id} \t\t {Product.Name} \t\t {Product.Price:C} \t\t {Quantity}");
            return str;
        }

    }
}
