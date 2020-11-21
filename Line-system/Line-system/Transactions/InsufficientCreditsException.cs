using System;
using Line_system.Products;
using Line_system.Users;

namespace Line_system.Transactions
{
    public class InsufficientCreditsException : Exception
    {
        // Taken from https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
        public InsufficientCreditsException()
        {
        }

        public InsufficientCreditsException(string message)
            : base(message)
        {
        }

        public InsufficientCreditsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}