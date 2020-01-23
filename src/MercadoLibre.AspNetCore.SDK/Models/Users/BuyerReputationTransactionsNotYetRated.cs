using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MercadoLibre.AspNetCore.SDK.Models.Users
{
    public class BuyerReputationTransactionsNotYetRated
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("paid")]
        public int? Paid { get; set; }

        [JsonPropertyName("units")]
        public int? Units { get; set; }
    }
}
