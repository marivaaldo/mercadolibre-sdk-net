using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MercadoLibre.AspNetCore.SDK.Models.Users
{
    public class SellerReputationTransactionsRatings
    {
        [JsonPropertyName("positive")]
        public int Positive { get; set; }
        
        [JsonPropertyName("negative")]
        public int Negative { get; set; }
        
        [JsonPropertyName("neutral")]
        public int Neutral { get; set; }
    }
}
