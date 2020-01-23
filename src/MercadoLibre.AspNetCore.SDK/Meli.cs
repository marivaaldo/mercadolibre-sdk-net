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

        private static readonly string SdkVersion = "MELI-NETCORE-SDK-1.0.0";

        public static string ApiUrl { get; set; } = "https://api.mercadolibre.com";

        public const string AccessTokenKeyName = "access_token";

        #endregion

        #region Private fields

        private readonly HttpClient _Client;

        #endregion

        public string ClientSecret { get; private set; }

        public long ClientId { get; private set; }

        public AuthorizeToken AuthorizeToken { get; set; } = new AuthorizeToken();

        #region Constructors

        public Meli()
        {
            _Client = new HttpClient
            {
                BaseAddress = new Uri(ApiUrl),
            };

            _Client.DefaultRequestHeaders.Clear();

            _Client.DefaultRequestHeaders.Add("User-Agent", SdkVersion);
            _Client.DefaultRequestHeaders.Add("Accept", "application/json");
            //_Client.DefaultRequestHeaders.Add("Content-Type", "application/json");
        }

        public Meli(MeliConfiguration configuration)
        {
            this.ClientId = configuration.ClientId;
            this.ClientSecret = configuration.ClientSecret;
        }

        public Meli(long clientId, string clientSecret)
            : this()
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
        }

        public Meli(long clientId, string clientSecret, string accessToken)
            : this()
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.AuthorizeToken.AccessToken = accessToken;
        }

        public Meli(long clientId, string clientSecret, string accessToken, string refreshToken)
            : this()
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.AuthorizeToken.AccessToken = accessToken;
            this.AuthorizeToken.RefreshToken = refreshToken;
        }

        #endregion

        public string GetAuthUrl(string authUrl, string redirectUri)
        {
            return $"{authUrl}/authorization?response_type=code&client_id={ClientId}&redirect_uri={HttpUtility.UrlEncode(redirectUri)}";
        }

        public async Task AuthorizeAsync(string code, string redirectUri)
        {
            var url = $"/oauth/token?grant_type=authorization_code&client_id={ClientId}&client_secret={ClientSecret}&code={code}&redirect_uri={redirectUri}";

            var response = await _Client.PostAsync(url, null);

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
            var url = $"/oauth/token?grant_type=refresh_token&client_id={ClientId}&client_secret={ClientSecret}&refresh_token={refreshToken}";

            var response = await _Client.PostAsync(url, null);

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

            return await _Client.GetAsync(url);
        }

        public async Task<T> GetAsync<T>(string resource, Dictionary<string, object> props = null)
        {
            var response = await GetAsync(resource, props);

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(content);
        }

        public async Task<HttpResponseMessage> PostAsync(string resource, Dictionary<string, object> props = null, HttpContent body = null)
        {
            var url = $"{resource}?{ParamsToGetUrl(props)}";

            return await _Client.PostAsync(url, body);
        }

        public async Task<T> PostAsync<T>(string resource, Dictionary<string, object> props = null, HttpContent body = null)
        {
            var response = await PostAsync(resource, props, body);

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(content);
        }

        public async Task<HttpResponseMessage> PutAsync(string resource, Dictionary<string, object> props = null, HttpContent body = null)
        {
            var url = $"{resource}?{ParamsToGetUrl(props)}";

            return await _Client.PutAsync(url, body);
        }

        public async Task<T> PutAsync<T>(string resource, Dictionary<string, object> props = null, HttpContent body = null)
        {
            var response = await PutAsync(resource, props, body);

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(content);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string resource, Dictionary<string, object> props = null)
        {
            var url = $"{resource}?{ParamsToGetUrl(props)}";

            return await _Client.DeleteAsync(url);
        }

        public async Task<T> DeleteAsync<T>(string resource, Dictionary<string, object> props = null)
        {
            var response = await DeleteAsync(resource, props);

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(content);
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
                if (p.Key == AccessTokenKeyName)
                {
                    values.Add($"{p.Key}={p.Value}");
                }
                else
                {
                    values.Add($"{p.Key}={{{p.Value}}}");
                }
            }

            return string.Join("&", values);
        }

        #endregion
    }
}
