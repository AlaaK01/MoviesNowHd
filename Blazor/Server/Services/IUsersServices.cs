using Blazor.Shared.Dto;
using Blazor.Shared.Models;

namespace Blazor.Server.Services
{
    public interface IUsersServices
    {
        Task<CartMovie> AddMovie(CartMovieToAddDto cartMovieToAddDto);
        Task DeleteUser(string id);
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<CartMovie> GetCartMovie(string id);
        Task<IEnumerable<CartMovie>> GetCartMovies(string userId);
        Task<Movie> GetMovieById(string id);
        Task<User> GetUserById(string id);
        Task<IEnumerable<User>> GetUsers();
        Task<CartMovie> RemoveMovie(string id);
        Task UpdateUser(string id, User updateUser);
    }
}