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

        #endregion

        #region Private fields

        private readonly HttpClient _Client;

        #endregion

        public string ClientSecret { get; private set; }

        public long ClientId { get; private set; }

        public string AccessToken { get; private set; }

        public string RefreshToken { get; private set; }

        /** News **/

        public long ExperiIn { get; private set; }

        public string Scope { get; private set; }

        public string UserId { get; private set; }

        public string TokenType { get; private set; }

        #region Constructors

        public Meli()
        {
            _Client = new HttpClient
            {
                BaseAddress = new Uri(ApiUrl),
            };

            _Client.DefaultRequestHeaders.UserAgent.Clear();
            _Client.DefaultRequestHeaders.Add("User-Agent", SdkVersion);

            _Client.DefaultRequestHeaders.Accept.Clear();
            _Client.DefaultRequestHeaders.Add("Accept", "application/json");
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
            this.AccessToken = accessToken;
        }

        public Meli(long clientId, string clientSecret, string accessToken, string refreshToken)
            : this()
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.AccessToken = accessToken;
            this.RefreshToken = refreshToken;
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
                var token = JsonConvert.DeserializeAnonymousType(response.Content, new
                {
                    refresh_token = "",
                    access_token = "",
                    expires_in = 0,
                    user_id = "",
                    scope = "",
                    token_type = ""
                });

                JsonSerializer.Deserialize()

                this.AccessToken = token.access_token;
                this.RefreshToken = token.refresh_token;
                this.ExperiIn = Convert.ToInt64(token.expires_in);
                this.Scope = token.scope;
                this.UserId = token.user_id;
                this.TokenType = token.token_type;
            }
            else
            {
                throw new AuthorizationException();
            }
        }

        public async Task<HttpResponseMessage> GetAsync(string resource)
        {
            return Get(resource, new List<Parameter>());
        }

        public void refreshToken()
        {
            var request = new RestRequest("/oauth/token?grant_type=refresh_token&client_id={client_id}&client_secret={client_secret}&refresh_token={refresh_token}", Method.POST);
            request.AddParameter("client_id", this.ClientId, ParameterType.UrlSegment);
            request.AddParameter("client_secret", this.ClientSecret, ParameterType.UrlSegment);
            request.AddParameter("refresh_token", this.RefreshToken, ParameterType.UrlSegment);

            request.AddHeader("Accept", "application/json");

            var response = ExecuteRequest(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var token = JsonConvert.DeserializeAnonymousType(response.Content, new
                {
                    refresh_token = "",
                    access_token = "",
                    expires_in = 0,
                    user_id = "",
                    scope = "",
                    token_type = ""
                });
                this.AccessToken = token.access_token;
                this.RefreshToken = token.refresh_token;
                this.ExperiIn = Convert.ToInt64(token.expires_in);
                this.Scope = token.scope;
                this.UserId = token.user_id;
                this.TokenType = token.token_type;
            }
            else
            {
                throw new AuthorizationException();
            }
        }


        public void refreshToken(string refresh_token)
        {
            var request = new RestRequest("/oauth/token?grant_type=refresh_token&client_id={client_id}&client_secret={client_secret}&refresh_token={refresh_token}", Method.POST);
            request.AddParameter("client_id", this.ClientId, ParameterType.UrlSegment);
            request.AddParameter("client_secret", this.ClientSecret, ParameterType.UrlSegment);
            request.AddParameter("refresh_token", refresh_token, ParameterType.UrlSegment);

            request.AddHeader("Accept", "application/json");

            var response = ExecuteRequest(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var token = JsonConvert.DeserializeAnonymousType(response.Content, new
                {
                    refresh_token = "",
                    access_token = "",
                    expires_in = 0,
                    user_id = "",
                    scope = "",
                    token_type = ""
                });
                this.AccessToken = token.access_token;
                this.RefreshToken = token.refresh_token;
                this.ExperiIn = Convert.ToInt64(token.expires_in);
                this.Scope = token.scope;
                this.UserId = token.user_id;
                this.TokenType = token.token_type;
            }
            else
            {
                throw new AuthorizationException();
            }
        }

        public IRestResponse Get(string resource, List<Parameter> param)
        {
            bool containsAT = false;

            var request = new RestRequest(resource, Method.GET);
            List<string> names = new List<string>();
            foreach (Parameter p in param)
            {
                names.Add(p.Name + "={" + p.Name + "}");
                if (p.Name.Equals("access_token"))
                {
                    containsAT = true;
                }
                p.Type = ParameterType.UrlSegment;
                request.AddParameter(p);
            }

            request.Resource = resource + "?" + String.Join("&", names.ToArray());

            request.AddHeader("Accept", "application/json");

            var response = ExecuteRequest(request);


            return response;
        }

        public IRestResponse Post(string resource, List<Parameter> param, object body)
        {
            bool containsAT = false;

            var request = new RestRequest(resource, Method.POST);
            List<string> names = new List<string>();
            foreach (Parameter p in param)
            {
                names.Add(p.Name + "={" + p.Name + "}");
                if (p.Name.Equals("access_token"))
                {
                    containsAT = true;
                }
                p.Type = ParameterType.UrlSegment;
                request.AddParameter(p);
            }

            request.Resource = resource + "?" + String.Join("&", names.ToArray());

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;

            request.AddBody(body);

            var response = ExecuteRequest(request);



            return response;
        }

        public IRestResponse Put(string resource, List<Parameter> param, object body)
        {
            bool containsAT = false;

            var request = new RestRequest(resource, Method.PUT);
            List<string> names = new List<string>();
            foreach (Parameter p in param)
            {
                names.Add(p.Name + "={" + p.Name + "}");
                if (p.Name.Equals("access_token"))
                {
                    containsAT = true;
                }
                p.Type = ParameterType.UrlSegment;
                request.AddParameter(p);
            }

            request.Resource = resource + "?" + String.Join("&", names.ToArray());

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;

            request.AddBody(body);

            var response = ExecuteRequest(request);



            return response;
        }

        public IRestResponse Delete(string resource, List<Parameter> param)
        {
            bool containsAT = false;

            var request = new RestRequest(resource, Method.DELETE);
            List<string> names = new List<string>();
            foreach (Parameter p in param)
            {
                names.Add(p.Name + "={" + p.Name + "}");
                if (p.Name.Equals("access_token"))
                {
                    containsAT = true;
                }
                p.Type = ParameterType.UrlSegment;
                request.AddParameter(p);
            }

            request.Resource = resource + "?" + String.Join("&", names.ToArray());

            request.AddHeader("Accept", "application/json");

            var response = ExecuteRequest(request);


            return response;
        }
    }
}
