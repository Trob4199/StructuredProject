namespace CKK.Logic.Exceptions
{
    [Serializable]
    public class InventoryItemStockTooLowException : Exception
    {
        public InventoryItemStockTooLowException() : base("Item Inventory stock too low") { }

        public InventoryItemStockTooLowException(string messageValue) : base(messageValue) { }

    }
}
