using CKK.Logic.Exceptions;
using CKK.Logic.Models;

namespace CKK.Logic.Interfaces
{
    [Serializable]
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
                if (value < 0)
                {
                    throw new InventoryItemStockTooLowException("Quanitiy must be greater than 0");
                }

                quanity = value;
            }
        }

    }
}
