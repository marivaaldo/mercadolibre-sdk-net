using System;
using System.Collections.Generic;
using System.Text;

namespace MercadoLibre.AspNetCore.SDK.Exceptions
{
    public class MeliException : Exception
    {
        public MeliException() : base() { }
        public MeliException(string message) : base(message) { }
        public MeliException(string message, Exception innerException) : base(message, innerException) { }
    }
}
