using Client.Model;

namespace Client.APIServices
{
    public interface IMoviesAPIService
    {
        Task<IEnumerable<Movies>> GetMovies();
        Task<Movies> GetMovie(string id);
        Task<Movies> CreateMovie(Movies movie);
        Task<Movies> UpdateMovie(Movies movie);
        Task DeleteMovie(int id);

    }
}
