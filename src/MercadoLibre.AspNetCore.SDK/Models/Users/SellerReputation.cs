using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MercadoLibre.AspNetCore.SDK.Models.Users
{
    public class SellerReputation
    {
        [JsonPropertyName("LevelId")]
        public string LevelId { get; set; }

        [JsonPropertyName("power_seller_status")]
        public string PowerSellerStatus { get; set; }

        [JsonPropertyName("transactions")]
        public SellerReputationTransactions Transactions { get; set; }
    }
}
