namespace CKK.Logic.Models
{
    public class OrderSummary
    {
        public OrderSummary(ShoppingCart cart)
        {
            Cart = cart;
        }

        public ShoppingCart Cart { get; set; }

    }
}
