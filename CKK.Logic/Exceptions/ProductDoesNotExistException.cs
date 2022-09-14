namespace CKK.Logic.Exceptions
{
    public class ProductDoesNotExistException : Exception
    {

        public ProductDoesNotExistException() : base("Product does not exist") { }

        public ProductDoesNotExistException(string messageValue) : base(messageValue) { }
    }
}
