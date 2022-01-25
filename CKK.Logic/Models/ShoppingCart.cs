using System.Collections.Generic;
using System.Linq;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;
using System;

namespace CKK.Logic.Models
{
    public class ShoppingCart : IShoppingCart
    {
        Customer Customer;
        public List<ShoppingCartItem> Products = new();

        public ShoppingCart(Customer cust)
        {
            Customer = cust;
        }

        public List<ShoppingCartItem> Products2 { get; }

        public int GetCustomerID()
        {
            int Id = Customer.Id;
            return Id;
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            int productid = prod.Id;
            int idIndex = 0;

            if (quantity < 1)
            {
                
                throw new InventoryItemStockTooLowException("Quanity Shall be greater than 0");

            }

            if (GetProductById(productid) == null)
            {
                ShoppingCartItem cartItemTemp = new(prod, quantity);
                Products.Add(cartItemTemp);
                return cartItemTemp;
            }
            else
            {
                for (int i = 0; i < Products.Count; i++)
                {
                    if (Products[i].Product.Id == prod.Id)
                    {
                        Products[i].Quantity = Products[i].Quantity + quantity;
                        idIndex = i;
                    }
                }
                return Products[idIndex];
            }

        }


        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            int idIndex = 0;
            ShoppingCartItem ShoppingCartItemTemp;

            if(quantity < 0)
            {
                throw new ArgumentOutOfRangeException("Number shall be greater than 0");
            }

            if (GetProductById(id) != null)
            {
                for (int i = 0; i < Products.Count; i++)
                {
                    if (Products[i].Product.Id == id)
                    {

                        if (Products[i].Quantity > quantity)
                        {
                            Products[i].Quantity = (Products[i].Quantity - quantity);
                            idIndex = i;
                            return Products[i];

                        }
                        else
                        {
                            Products[i].Quantity = 0;
                            ShoppingCartItemTemp = Products[i];
                            Products.RemoveAt(i);
                            return ShoppingCartItemTemp;
                        }
                    }
                }
                return Products[idIndex];
            }
            else if(GetProductById(id) == null)
            {
                throw new ProductDoesNotExistException("Product does not exist");
            }
            return null;
        }
        public ShoppingCartItem GetProductById(int id)
        {
            if(id < 0)
            {
                throw new InvalidIdException("ID must be greater than 0");
            }
     

            if (Products.Count > 0)
            {
                var cartItem2 =
                    from item in Products
                    where item.Product.Id == id
                    select item;

                return cartItem2.FirstOrDefault();

            }

            return null;

        }
        public decimal GetTotal()
        {
            decimal total = 0;

            for (int i = 0; i < Products.Count; i++)
            {
                total += Products[i].GetTotal();
            }

            return total;
        }
        public List<ShoppingCartItem> GetProducts()
        {
            return Products;
        }
    }
}
