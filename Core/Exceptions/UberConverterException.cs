using System;

namespace Core.Exceptions
{
    public class UberConverterException : Exception
    {
        public UberConverterException(): base(message: "Uber converter exception")
        {
            
        }
    }
}