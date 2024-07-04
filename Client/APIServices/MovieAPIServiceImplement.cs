using Client.Model;

namespace Client.APIServices
{
    public class MovieAPIServiceImplement : IMoviesAPIService
    {
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
            var movie = new Movies
            {
                Id = 1,
                Title = "The Shawshank Redemption",
                Genre = "Drama",
                Rating = "9.3",
                ReleaseDate = new DateTime(1994, 10, 14),
                ImageUrl = "https://www.imdb.com/title/tt0111161/mediaviewer/rm10105600",
                Owner = "admin"
            };
        }

        public Task<IEnumerable<Movies>> GetMovies()
        {
            throw new NotImplementedException();
        }

        public Task<Movies> UpdateMovie(Movies movie)
        {
            throw new NotImplementedException();
        }
    }
}
