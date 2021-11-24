using System;

namespace Common.Exceptions
{
    public class GlobalExceptionError : Exception
    {
        public GlobalExceptionError(string message, Exception inner)
        : base(message, inner) { }
    }
}
