namespace SummertimeSunshine_API.Exceptions
{
    public class ProductAlreadyExistException : Exception
    {
        public ProductAlreadyExistException() { }
        public ProductAlreadyExistException(string message) : base(message) { }
    }
}
