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

        }

        public Task<Movies> UpdateMovie(Movies movie)
        {
            throw new NotImplementedException();
        }
    }
}
