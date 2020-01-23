using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MercadoLibre.AspNetCore.SDK.Models.Users
{
    public class BuyerReputation
    {
        [JsonPropertyName("canceled_transactions")]
        public int CanceledTransactions { get; set; }

        [JsonPropertyName("transactions")]
        public BuyerReputationTransactions Transactions { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}
