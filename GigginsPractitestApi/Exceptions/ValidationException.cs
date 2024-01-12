using GigginsPractitestApi.Constants;

namespace GigginsPractitestApi.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message)
            : base(message)
        {
        }
    }
}
