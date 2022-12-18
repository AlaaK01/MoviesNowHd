using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Blazor.Shared.Models;
using Blazor.Shared.Dto;
using Blazor.Shared.MongoSittingServices;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IMongoCollection<User> _users;
        private readonly IMongoCollection<Movie> _movies;
        private readonly IMongoCollection<Cart> _carts;
        private readonly IMongoCollection<CartMovie> _cartMovies;
        public UsersServices(IOptions<MoviesDatabaseSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _users = client.GetDatabase(options.Value.DatabaseName).GetCollection<User>(options.Value.CollectionUsers);
            _movies = client.GetDatabase(options.Value.DatabaseName).GetCollection<Movie>(options.Value.CollectionMovies);
            _carts = client.GetDatabase(options.Value.DatabaseName).GetCollection<Cart>(options.Value.CollectionCarts);
            _cartMovies = client.GetDatabase(options.Value.DatabaseName).GetCollection<CartMovie>(options.Value.CollectionCartMovies);
        }




        public async Task<IEnumerable<User>> GetUsers() => await _users.Find(u => true).ToListAsync();
        public async Task<IEnumerable<Movie>> GetAllMovies() => await _movies.Find(m => true).ToListAsync();
        public async Task<User> GetUserById(string id) => await _users.Find(u => u.Id == id).SingleOrDefaultAsync();

        public async Task UpdateUser(string id, User updateUser) => await _users.ReplaceOneAsync(id, updateUser);
        public async Task DeleteUser(string id) => await _users.DeleteOneAsync(u => u.Id == id);


        public async Task<CartMovie> AddMovie(CartMovieToAddDto cartMovieToAddDto)
        {
            var ExisitCartMovie = await _cartMovies.Find(c => c.CartId == cartMovieToAddDto.CartId && c.MovieId == cartMovieToAddDto.MovieId).SingleOrDefaultAsync();
            if (ExisitCartMovie != null)
            {
                var movies = await _movies.Find(x => true).ToListAsync();
                var cartMovie = (from movie in movies
                                 where movie.Id == cartMovieToAddDto.MovieId
                                 select new CartMovie
                                 {
                                     CartId = cartMovieToAddDto.CartId,
                                     MovieId = movie.Id,
                                     Quantity = cartMovieToAddDto.Quantity
                                 }).SingleOrDefault();

                if (cartMovie != null)
                {
                    await _cartMovies.InsertOneAsync(cartMovie);
                    return cartMovie;
                }
            }

            return null;

        }




        public async Task<CartMovie> GetCartMovie(string id)
        {
            var carts = await _carts.Find(x => true).ToListAsync();
            var cartMovies = await _cartMovies.Find(x => true).ToListAsync();
            return (from cart in carts
                    join cartMovie in cartMovies
                    on cart.Id equals cartMovie.CartId
                    where cartMovie.Id == id
                    select new CartMovie
                    {
                        Id = cartMovie.Id,
                        CartId = cartMovie.CartId,
                        MovieId = cartMovie.MovieId,
                        Quantity = cartMovie.Quantity
                    }).SingleOrDefault();
        }

        public async Task<IEnumerable<CartMovie>> GetCartMovies(string userId)
        {
            var carts = await _carts.Find(x => true).ToListAsync();
            var cartMovies = await _cartMovies.Find(x => true).ToListAsync();
            return (from cart in carts
                    join cartMovie in cartMovies
                    on cart.Id equals cartMovie.CartId
                    where cart.UserId == userId
                    select new CartMovie
                    {
                        Id = cartMovie.Id,
                        CartId = cartMovie.CartId,
                        MovieId = cartMovie.MovieId,
                        Quantity = cartMovie.Quantity
                    }).ToList();
        }




        public async Task<CartMovie> RemoveMovie(string id)
        {
            var ExisitingMovie = await _cartMovies.Find(x => x.Id == id).SingleOrDefaultAsync();
            if (ExisitingMovie != null)
            {
                await _cartMovies.DeleteOneAsync(x => x.Id == id);
            }
            return ExisitingMovie;

        }


        public async Task<Movie> GetMovieById(string id) => await _movies.Find(x => x.Id == id).SingleOrDefaultAsync();
    }
}


 