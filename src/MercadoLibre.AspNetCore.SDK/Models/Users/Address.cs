using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MercadoLibre.AspNetCore.SDK.Models.Users
{
    public class Address
    {
        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("address")]
        public string AddressLine { get; set; }

        [JsonPropertyName("zip_code")]
        public string ZipCode { get; set; }
    }
}
