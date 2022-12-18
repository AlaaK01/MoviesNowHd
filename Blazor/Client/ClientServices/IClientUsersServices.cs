using Blazor.Shared.Dto;

namespace Blazor.Client.ClientServices
{
    public interface IClientUsersServices
    {
        Task<CartMovieDto> AddMovie(CartMovieToAddDto cartMovieToAddDto);
        Task<CartMovieDto> DeleteMovie(string id);
        Task<List<CartMovieDto>> GetMovies(string userId);
    }
}