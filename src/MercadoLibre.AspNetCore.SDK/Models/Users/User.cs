using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MercadoLibre.AspNetCore.SDK.Models.Users
{
    public class User
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("nickname")]
        public string Nickname { get; set; }

        [JsonPropertyName("registration_date")]
        public DateTime RegistrationDate { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("country_id")]
        public string Country { get; set; }

        [JsonPropertyName("identification")]
        public Identification Identification { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("phone")]
        public Phone Phone { get; set; }

        [JsonPropertyName("alternative_phone")]
        public Phone AlternativePhone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("user_type")]
        public string UserType { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("logo")]
        public string Logo { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }

        [JsonPropertyName("site_id")]
        public string SiteId { get; set; }

        [JsonPropertyName("permalink")]
        public string PermanentLink { get; set; }

        [JsonPropertyName("shipping_modes")]
        public List<string> ShippingModes { get; set; }

        [JsonPropertyName("seller_experience")]
        public string SellerExperience { get; set; }

        [JsonPropertyName("seller_reputation")]
        public SellerReputation SellerReputation { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("credit")]
        public Credit Credit { get; set; }
    }
}
