using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MercadoLibre.AspNetCore.SDK.Models.Users
{
    public class SellerReputationTransactions
    {
        [JsonPropertyName("period")]
        public string Period { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("completed")]
        public int Completed { get; set; }

        [JsonPropertyName("canceled")]
        public int Canceled { get; set; }

        [JsonPropertyName("ratings")]
        public SellerReputationTransactionsRatings Ratings { get; set; }
    }
}