using MercadoLibre.AspNetCore.SDK.Exceptions;
using MercadoLibre.AspNetCore.SDK.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace MercadoLibre.AspNetCore.SDK
{
    public class Meli
    {
        #region Static variables

        private static readonly string SdkVersion = "MELI-NETCORE-SDK-1.1.0";
        public const string ApiUrl = "https://api.mercadolibre.com";
        public const string AccessTokenKeyName = "access_token";

        #endregion

        #region Private fields

        private readonly HttpClient _client;

        #endregion

        private readonly string _clientSecret;
        private readonly long _clientId;
        public AuthorizeToken AuthorizeToken { get; private set; }

        #region Constructors

        private Meli()
        {
            if (_client is null)
            {
                _client = new HttpClient
                {
                    BaseAddress = new Uri(ApiUrl),
                };

                _client.DefaultRequestHeaders.Clear();

                _client.DefaultRequestHeaders.Add("User-Agent", SdkVersion);
                _client.DefaultRequestHeaders.Add("Accept", "application/json");
                _client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            }

            if (AuthorizeToken is null)
                this.AuthorizeToken = new AuthorizeToken();
        }

        public Meli(long clientId, string clientSecret, string accessToken = null, string refreshToken = null)
            : this()
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            this.AuthorizeToken.AccessToken = accessToken;
            this.AuthorizeToken.RefreshToken = refreshToken;
        }

        #endregion

        public string GetAuthUrl(string authUrl, string redirectUri)
        {
            return $"{authUrl}/authorization?response_type=code&client_id={_clientId}&redirect_uri={HttpUtility.UrlEncode(redirectUri)}";
        }

        public async Task AuthorizeAsync(string code, string redirectUri)
        {
            var url = $"/oauth/token?grant_type=authorization_code&client_id={_clientId}&client_secret={_clientSecret}&code={code}&redirect_uri={redirectUri}";

            var response = await _client.PostAsync(url, null);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();

                this.AuthorizeToken = JsonSerializer.Deserialize<AuthorizeToken>(content);
            }
            else
            {
                throw new AuthorizationException();
            }
        }

        public async Task RefreshTokenAsync()
        {
            await RefreshTokenAsync(AuthorizeToken.RefreshToken);
        }


        public async Task RefreshTokenAsync(string refreshToken)
        {
            var url = $"/oauth/token?grant_type=refresh_token&client_id={_clientId}&client_secret={_clientSecret}&refresh_token={refreshToken}";

            var response = await _client.PostAsync(url, null);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();

                this.AuthorizeToken = JsonSerializer.Deserialize<AuthorizeToken>(content);
            }
            else
            {
                throw new AuthorizationException();
            }
        }

        public async Task<HttpResponseMessage> GetAsync(string resource, Dictionary<string, object> props = null)
        {
            var url = $"{resource}?{ParamsToGetUrl(props)}";

            return await _client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsync(string resource, Dictionary<string, object> props = null, HttpContent body = null)
        {
            var url = $"{resource}?{ParamsToGetUrl(props)}";

            return await _client.PostAsync(url, body);
        }

        public async Task<HttpResponseMessage> PutAsync(string resource, Dictionary<string, object> props = null, HttpContent body = null)
        {
            var url = $"{resource}?{ParamsToGetUrl(props)}";

            return await _client.PutAsync(url, body);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string resource, Dictionary<string, object> props = null)
        {
            var url = $"{resource}?{ParamsToGetUrl(props)}";

            return await _client.DeleteAsync(url);
        }

        #region Private methods

        private string ParamsToGetUrl(Dictionary<string, object> props, bool includeAccessToken = true)
        {
            if (props == null)
                props = new Dictionary<string, object>();

            if (includeAccessToken && !props.ContainsKey(AccessTokenKeyName))
            {
                props[AccessTokenKeyName] = AuthorizeToken.AccessToken;
            }

            var values = new List<string>();

            foreach (var p in props)
            {
                values.Add($"{p.Key}={{{p.Value}}}");
            }

            return string.Join("&", values);
        }

        #endregion
    }
}
