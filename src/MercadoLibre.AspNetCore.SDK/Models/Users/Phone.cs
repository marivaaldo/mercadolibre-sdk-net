using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MercadoLibre.AspNetCore.SDK.Models.Users
{
    public class Phone
    {
        [JsonPropertyName("area_code")]
        public string AreaCode { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("extension")]
        public string Extension { get; set; }

        [JsonPropertyName("verified")]
        public bool Verified { get; set; }
    }
}
