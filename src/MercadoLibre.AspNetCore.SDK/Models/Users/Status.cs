using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MercadoLibre.AspNetCore.SDK.Models.Users
{
    public class Status
    {
        [JsonPropertyName("site_status")]
        public string SiteStatus { get; set; }

        [JsonPropertyName("mercadopago_tc_accepted")]
        public bool MercadoPagoTcAccepted { get; set; }

        [JsonPropertyName("mercadopago_account_type")]
        public string MercadoPagoAccountType { get; set; }

        [JsonPropertyName("mercadoenvios")]
        public string MercadoEnvios { get; set; }

        [JsonPropertyName("immediate_payment")]
        public bool ImmediatePayment { get; set; }

        [JsonPropertyName("confirmed_email")]
        public bool ConfirmedEmail { get; set; }

        [JsonPropertyName("user_type")]
        public string UserType { get; set; }

        [JsonPropertyName("required_action")]
        public string RequiredAction { get; set; }

        [JsonPropertyName("list")]
        public StatusDetail List { get; set; }

        [JsonPropertyName("buy")]
        public StatusDetail Buy { get; set; }

        [JsonPropertyName("sell")]
        public StatusDetail Sell { get; set; }

        [JsonPropertyName("billing")]
        public StatusDetail Billing { get; set; }
    }
}
