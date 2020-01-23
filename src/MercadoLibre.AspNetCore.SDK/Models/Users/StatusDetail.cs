using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MercadoLibre.AspNetCore.SDK.Models.Users
{
    public class StatusDetail
    {
        [JsonPropertyName("allow")]
        public bool Allow { get; set; }

        [JsonPropertyName("codes")]
        public List<string> Codes { get; set; }

        [JsonPropertyName("immediate_payment")]
        public StatusDetailImmediatePayment ImmediatePayment { get; set; }
    }
}
