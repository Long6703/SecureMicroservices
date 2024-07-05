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
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movies>> GetMovies()
        {
            var movies = new List<Movies>
            {
                new Movies
                {
                    Id = 1,
                    Title = "The Shawshank Redemption",
                    Genre = "Drama",
                    Rating = "9.3",
                    ReleaseDate = new DateTime(1994, 10, 14),
                    ImageUrl = "https://www.imdb.com/title/tt0111161/mediaviewer/rm10105600",
                    Owner = "Frank Darabont"
                },
                new Movies
                {
                    Id = 2,
                    Title = "The Godfather",
                    Genre = "Crime",
                    Rating = "9.2",
                    ReleaseDate = new DateTime(1972, 3, 24),
                    ImageUrl = "https://www.imdb.com/title/tt0068646/mediaviewer/rm10105600",
                    Owner = "Francis Ford Coppola"
                },
                new Movies
                {
                    Id = 3,
                    Title = "The Dark Knight",
                    Genre = "Action",
                    Rating = "9.0",
                    ReleaseDate = new DateTime(2008, 7, 18),
                    ImageUrl = "https://www.imdb.com/title/tt0468569/mediaviewer/rm10105600",
                    Owner = "Christopher Nolan"
                }
            };
            return Task.FromResult(movies.AsEnumerable());
        }

        public Task<Movies> UpdateMovie(Movies movie)
        {
            throw new NotImplementedException();
        }
    }
}
