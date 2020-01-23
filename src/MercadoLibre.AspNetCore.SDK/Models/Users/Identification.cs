using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MercadoLibre.AspNetCore.SDK.Models.Users
{
    public class Identification
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }
    }
}
