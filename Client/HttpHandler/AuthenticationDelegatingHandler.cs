using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Client.HttpHandler
{
    public class AuthenticationDelegatingHandler : DelegatingHandler
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        //private readonly ClientCredentialsTokenRequest _clientCredentialsTokenRequest;

        //public AuthenticationDelegatingHandler(IHttpClientFactory httpClientFactory, ClientCredentialsTokenRequest clientCredentialsTokenRequest)
        //{
        //    _httpClientFactory = httpClientFactory;
        //    _clientCredentialsTokenRequest = clientCredentialsTokenRequest;
        //}

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationDelegatingHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //var client = _httpClientFactory.CreateClient("IdentityServerClient");

            //var tokenResponse = await client.RequestClientCredentialsTokenAsync(_clientCredentialsTokenRequest);

            //if (tokenResponse.IsError)
            //{
            //    throw new HttpRequestException("Something went wrong while requesting the access token");
            //}

            //request.SetBearerToken(tokenResponse.AccessToken);

            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                request.SetBearerToken(accessToken);

            }

            #region Logging
            Console.WriteLine($"Method: {request.Method}");
            Console.WriteLine($"Request Uri: {request.RequestUri}");

            Console.WriteLine("Headers after setting Bearer Token:");
            foreach (var header in request.Headers)
            {
                Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
            }

            if (request.Content != null)
            {
                Console.WriteLine("Content Headers after setting Bearer Token:");
                foreach (var header in request.Content.Headers)
                {
                    Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
                }

                var content = await request.Content.ReadAsStringAsync();
                Console.WriteLine($"Content: {content}");
            }
            #endregion

            return await base.SendAsync(request, cancellationToken);

        }


    }
}
