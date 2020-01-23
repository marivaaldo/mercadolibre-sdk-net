using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MercadoLibre.AspNetCore.SDK.Models.Users
{
    public class StatusDetailImmediatePayment
    {
        [JsonPropertyName("required")]
        public bool Required { get; set; }

        [JsonPropertyName("reasons")]
        public List<string> Reasons { get; set; }
    }
}
