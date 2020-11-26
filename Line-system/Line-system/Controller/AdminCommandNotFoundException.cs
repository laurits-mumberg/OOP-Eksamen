using System;

namespace Line_system.Controller
{
    public class AdminCommandNotFoundException : Exception
    {
        // Taken from https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
        public AdminCommandNotFoundException()
        {
        }

        public AdminCommandNotFoundException(string message)
            : base(message)
        {
        }

        public AdminCommandNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}