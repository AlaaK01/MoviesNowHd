using Blazor.Shared.Models;
using Blazor.Shared.MongoSittingServices;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace Blazor.Server.Services
{
    public class MoviesServices : IMoviesServices
    {
        private readonly IMongoCollection<Movie> _movies;
        private readonly IMongoCollection<Genre> _genres;
        public MoviesServices(IOptions<MoviesDatabaseSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _movies = client.GetDatabase(options.Value.DatabaseName).GetCollection<Movie>(options.Value.CollectionMovies);
            _genres = client.GetDatabase(options.Value.DatabaseName).GetCollection<Genre>(options.Value.CollectionGenres);
        }

        public async Task<IEnumerable<Genre>> GetGenres() => await _genres.Find(x => true).ToListAsync();

        public async Task<IEnumerable<Movie>> GetAllMovies() => await _movies.Find(x => true).ToListAsync();
        public async Task<Movie> GetMovieById(string id) => await _movies.Find(x => x.Id == id).SingleOrDefaultAsync();
        public async Task<Genre> GetGenreById(string id) => await _genres.Find(x => x.Id == id).SingleOrDefaultAsync();
        public async Task<Movie> GetMovieByGenre(string genre) => await _movies.Find(x => x.Genre == genre).SingleOrDefaultAsync();


        //Get By Movie Title
        public async Task<IEnumerable<Movie>> GetMovieByTitle(string title) => await _movies.Find(x => x.Title.ToLower().Contains(title.ToLower())).ToListAsync();


        public async Task<Movie> CreateAsync(string title, string genre, int yers, double rate, string summary, List<string> actors, string url)
        {
            var movie = new Movie();
            movie.Title = title;
            movie.Genre = genre;
            movie.Year = yers;
            movie.Rate = rate;
            movie.Summary = summary;
            movie.Actors = actors;
            movie.ImageUrl = url;
            await _movies.InsertOneAsync(movie);
            return movie;
        }
        public async Task Update(string id, Movie updateMovie) => await _movies.ReplaceOneAsync(id, updateMovie);

        public async Task Remove(string id) => await _movies.DeleteOneAsync(m => m.Id == id);

        public async Task<IEnumerable<Movie>> GetMoviesByGenre (string id)
        {
            var genre = await _genres.Find(g => g.Id == id).SingleOrDefaultAsync();
            var movies = await _movies.Find(m => m.Genre == genre.genreName).ToListAsync();
                                    
            return movies;
        }
    }
}
