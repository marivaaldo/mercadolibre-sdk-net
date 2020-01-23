using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MercadoLibre.AspNetCore.SDK.Models.Users
{
    public class BuyerReputationTransactions
    {
        [JsonPropertyName("period")]
        public string Pediod { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("completed")]
        public int? Completed { get; set; }

        [JsonPropertyName("canceled")]
        public BuyerReputationTransactionsCanceled Canceled { get; set; }

        [JsonPropertyName("unrated")]
        public BuyerReputationTransactionsUnrated Unrated { get; set; }

        [JsonPropertyName("not_yet_rated")]
        public BuyerReputationTransactionsNotYetRated NotYetRated { get; set; }
    }
}
