using System;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CKK.Logic.Models
{
    [Serializable]
    public class ShoppingCartItem
    {
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        private int quantity { get; set; }
        public int ShoppingCartItemId { get; set; }
        public List<ShoppingCart> Carts { get; set; } = new List<ShoppingCart>();

        public int CustomerId { get; set; }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value >= 0)
                {
                    quantity = value;
                }
                else
                {
                    throw new InventoryItemStockTooLowException();
                }
            }
        }
        public decimal GetTotal()
        {
            return Product.Price * Quantity;
        }
        public override string ToString() => $"#{ProductId,-4} {Product.Name,-30} {$"Quantity: {Quantity:N0}",-13}";


    }
}
