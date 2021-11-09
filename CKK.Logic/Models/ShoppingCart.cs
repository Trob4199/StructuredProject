using System.Collections.Generic;
using System.Linq;
using CKK.Logic.Interfaces;

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
            int Id = Customer.id;
            return Id;
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            int productid = prod.id;
            int idIndex = 0;

            if (quantity < 1)
            {
                return null;
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
                    if (Products[i].Product.id == prod.id)
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

            if (GetProductById(id) != null)
            {
                for (int i = 0; i < Products.Count; i++)
                {
                    if (Products[i].Product.id == id)
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
            return null;
        }
        public ShoppingCartItem GetProductById(int id)
        {

            if (Products.Count > 0)
            {
                var cartItem2 =
                    from item in Products
                    where item.Product.id == id
                    select item;

                return cartItem2.FirstOrDefault();

                //var storeItem1 =
                //Items.Where(f => f.GetProduct().GetId() == Id).FirstOrDefault();


                //return storeItem1;
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
