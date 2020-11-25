using System;

namespace Line_system.Users
{
    public class UserNotFoundException : Exception
    {
        // Taken from https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(string message)
            : base(message)
        {
        }

        public UserNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}