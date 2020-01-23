using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercadoLibre.AspNetCore.SDK.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddMercadoLibre(this IServiceCollection services, long clientId, string clientSecret)
        {
            services.AddTransient<Meli>(o => new Meli(clientId, clientSecret));

            return services;
        }
    }
}
