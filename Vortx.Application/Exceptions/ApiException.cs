using System;
using System.Globalization;

namespace Vortx.Application.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException() : base("Exceção de API: ") { }

        public ApiException(string message) : base(message) { }

        public ApiException(string message, params object[] args) :
            base(String.Format(CultureInfo.CurrentCulture, message, args))
        { }
    }
}
