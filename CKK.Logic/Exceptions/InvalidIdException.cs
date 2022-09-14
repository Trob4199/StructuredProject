namespace CKK.Logic.Exceptions
{
    [Serializable]
    public class InvalidIdException : Exception
    {
        public InvalidIdException() : base("Invalid ID value")
        {

        }
        public InvalidIdException(string messageValue) : base(messageValue)
        {

        }
    }
}
