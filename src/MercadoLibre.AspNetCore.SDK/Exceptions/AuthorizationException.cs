using System;
using System.Collections.Generic;
using System.Text;

namespace MercadoLibre.AspNetCore.SDK.Exceptions
{
    public class AuthorizationException : MeliException
    {
        public AuthorizationException()
        {
        }

        public AuthorizationException(string msg, Exception ex) : base(msg, ex)
        {
        }
    }
}
