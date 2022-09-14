namespace CKK.Logic.Models
{
    public class ShoppingCart
    {

        public int ShoppingCartId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
