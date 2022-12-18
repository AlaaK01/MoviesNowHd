using Blazor.Shared.Models;

namespace Blazor.Server.Services
{
    public interface IMoviesServices
    {
        Task<Movie> CreateAsync(string title, string genre, int yers, double rate, string summary, List<string> actors, string url);
        Task<Genre> GetGenreById(string id);
        Task<IEnumerable<Genre>> GetGenres();
        Task<Movie> GetMovieByGenre(string genre);
        Task<Movie> GetMovieById(string id);
        Task<IEnumerable<Movie>> GetMovieByTitle(string title);
        Task<IEnumerable<Movie>> GetAllMovies();
        Task Remove(string id);
        Task Update(string id, Movie updateMovie);
        Task<IEnumerable<Movie>> GetMoviesByGenre(string id);
    }
}