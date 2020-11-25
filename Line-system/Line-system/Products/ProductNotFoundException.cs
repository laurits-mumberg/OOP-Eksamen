using System;

namespace Line_system.Products
{
    public class ProductNotFoundException : Exception
    {
        // Taken from https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
        public ProductNotFoundException()
        {
        }

        public ProductNotFoundException(string message)
            : base(message)
        {
        }

        public ProductNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}