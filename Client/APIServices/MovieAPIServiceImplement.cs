using Client.Model;
using IdentityModel.Client;
using Microsoft.CodeAnalysis.Text;
using Newtonsoft.Json;

namespace Client.APIServices
{
    public class MovieAPIServiceImplement : IMoviesAPIService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public MovieAPIServiceImplement(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<Movies> CreateMovie(Movies movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }
        
        public Task<Movies> GetMovie(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movies>> GetMovies()
        {

            //Get token from Identity Server, 
            //Send request  to API Resource with token
            //Get data from API Resource

            var client = _httpClientFactory.CreateClient("APIResourceClient");
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Movies");
            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var movies = JsonConvert.DeserializeObject<List<Movies>>(content);
            return movies.AsEnumerable();


            //retrieve our api credentials. This must be registered in the Identity Server
            //var apiClientCridentials = new ClientCredentialsTokenRequest
            //{
            //    Address = "https://localhost:5005/connect/token",
            //    ClientId = "movieClient",
            //    ClientSecret = "secret",

            //    Scope = "movieAPI"
            //};

            // connect to Identity Server and get the token
            //var client = new HttpClient();

            //check if the Identity Server is up
            //var discoveryDocument = client.GetDiscoveryDocumentAsync("https://localhost:5005").Result;
            //if(discoveryDocument.IsError)
            //{
            //    return null;
            //}

            // get the access token
            //var tokenResponse = client.RequestClientCredentialsTokenAsync(apiClientCridentials).Result;
            //if(tokenResponse.IsError)
            //{
            //    return null;
            //}

            // apiclient to call the API Resource
            //var apiClient = new HttpClient();

            // set the access token to the header
            //apiClient.SetBearerToken(tokenResponse.AccessToken);

            // call the API Resource
            //var response = apiClient.GetAsync("https://localhost:5001/api/Movies").Result;
            //response.EnsureSuccessStatusCode();

            //var content = response.Content.ReadAsStringAsync().Result;
            //var movies = JsonConvert.DeserializeObject<List<Movies>>(content);
            //return Task.FromResult(movies.AsEnumerable());

        }

        public Task<Movies> UpdateMovie(Movies movie)
        {
            throw new NotImplementedException();
        }
    }
}
