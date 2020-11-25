using System;

namespace Line_system.Products
{
    public class ProductNotActiveException : Exception
    {
        // Taken from https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
        public ProductNotActiveException()
        {
        }

        public ProductNotActiveException(string message)
            : base(message)
        {
        }

        public ProductNotActiveException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}