using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    public abstract class InventoryItem : Object
    {
        private int quanity; 
        public Product Product { get; set; }
        public int Quantity 
        {
            get
            {
                return quanity;
            }
            set
            {
                if(value < 0)
                {
                    throw new InventoryItemStockTooLowException("Quanitiy must be greater than 0");
                }

                quanity = value;
            }
        }

    }
}
