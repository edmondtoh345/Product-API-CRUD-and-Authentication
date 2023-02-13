namespace SummertimeSunshine_API.Exceptions
{
    public class ProductNotAvailableException : Exception
    {
        public ProductNotAvailableException() { }
        public ProductNotAvailableException(string message) : base(message) { }
    }
}
