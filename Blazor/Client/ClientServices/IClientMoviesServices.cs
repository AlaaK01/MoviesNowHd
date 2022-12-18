using Blazor.Shared.Dto;

namespace Blazor.Client.ClientServices
{
    public interface IClientMoviesServices
    {
        Task<IEnumerable<GenreDto>> GetGenres();
        Task<MovieDto> GetMovie(string id);
        Task<IEnumerable<MovieDto>> GetMovies();
        Task<IEnumerable<MovieDto>> GetMoviesByGenre(string genreId);
    }
}