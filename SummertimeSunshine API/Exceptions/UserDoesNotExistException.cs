namespace SummertimeSunshine_API.Exceptions
{
    public class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException() { }
        public UserDoesNotExistException (string message) : base(message) { }
    }
}
