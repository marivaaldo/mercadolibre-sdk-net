using System;
using System.Collections.Generic;
using System.Text;

namespace MercadoLibre.AspNetCore.SDK.Resources
{
    public abstract class MeliResource
    {
        public Meli Meli { get; set; }

        public MeliResource()
        {

        }

        public MeliResource(Meli meli)
        {
            Meli = meli;
        }
    }
}
