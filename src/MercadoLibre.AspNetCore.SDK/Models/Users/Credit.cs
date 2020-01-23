using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MercadoLibre.AspNetCore.SDK.Models.Users
{
    public class Credit
    {
        [JsonPropertyName("consumed")]
        public int Consumed { get; set; }

        [JsonPropertyName("credit_level_id")]
        public string CreditLevelId { get; set; }
    }
}
