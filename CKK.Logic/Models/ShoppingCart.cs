using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        Customer Customer;
        ShoppingCartItem Product1;
        ShoppingCartItem Product2;
        ShoppingCartItem Product3;

        public ShoppingCart(Customer cust)
        {
            Customer = cust;
        }

        public int GetCustomerID()
        {
            int Id = Customer.GetId();
            return Id;
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            int quantityUpdate = 0;                                         

            if (quantity < 1)                                                   
            {
                return null;
            }

            if (Product1 != null && prod == Product1.GetProduct())
            {
                quantityUpdate = Product1.GetQuantity() + quantity;
                Product1.SetQuantity(quantityUpdate);
                return Product1;
            }
            else if(Product3 != null && prod == Product2.GetProduct())
            {
                quantityUpdate = Product2.GetQuantity() + quantity;
                Product2.SetQuantity(quantityUpdate);
                return Product2;
            }
            else if (Product3 != null && prod == Product3.GetProduct())
            {
                quantityUpdate = Product3.GetQuantity() + quantity;
                Product3.SetQuantity(quantityUpdate);
                return Product3;
            }

            if (Product1 == null)
            {
                Product1 = new(prod,quantity);
                return Product1;
            }
            else if (Product2 == null)
            {
                Product2 = new(prod, quantity);
                return Product2;
            }
            else if(Product3 == null)
            {
                Product3 = new(prod, quantity);
                return Product3;
            }
            else
            {
                return null;
            }
        }

        public ShoppingCartItem AddProduct(Product prod)
        {
            
            if (Product1 == null)
            {
                Product1 = new(prod, 1);
                return Product1;
            }
            else if (Product2 == null)
            {
                Product2 = new(prod, 1);
                return Product2;
            }
            else if (Product3 == null)
            {
                Product3 = new(prod, 1);
                return Product3;
            }
            else
            {
                return null;
            }
        }

        public ShoppingCartItem RemoveProduct(Product prod, int quantity)
        {
            if(prod == Product1.GetProduct())
            {
                Product1 = null;
                return Product1;
            }
            else if(prod == Product2.GetProduct())
            {
                Product2 = null;
                return Product2;
            }
            else if(prod == Product3.GetProduct())
            {
                Product3 = null;
                return Product3;
            }
            else
            {
                return null;
            }
        }
        public ShoppingCartItem GetProductById(int id)
        {
            Product product1 = Product1.GetProduct();
            Product product2 = Product2.GetProduct();
            Product product3 = Product3.GetProduct();

            if (id == product1.GetId())
            {
                return Product1;
            }
            else if(id == product2.GetId())
            {
                return Product2;
            }
            else if(id == product3.GetId())
            {
                return Product3;
            }

            else return null;
        }
        public decimal GetTotal()
        {
            decimal total = 0;
            if (Product1 != null)
            {
                total += Product1.GetTotal();
            }
            if (Product2 != null)
            {
                total += Product2.GetTotal();
            }
            if (Product3 != null)
            {
                total += Product3.GetTotal();
            }
            
            return total;
        }
        public ShoppingCartItem GetProduct(int productNum)
        {
            if (productNum == 1)
            {
                return Product1;
            }
            else if (productNum == 2)
            {
                return Product2;
            }
            else if (productNum == 3)
            {
                return Product3;
            }
            else
            {
                return null;
            }
        }
    }
}
