using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blazor.Shared.Models;
using Blazor.Server.Services;
using Blazor.Shared.Dto;
using Blazor.Server.Operations;

namespace Blizor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesServices _services;

        public MoviesController(IMoviesServices services) => _services = services;




        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            var movies = await _services.GetAllMovies();
            if (movies == null)
            {
                return NotFound();
            }
            else
            {
                var movieDtos = movies.MoviesToDto();
                return Ok(movieDtos);
            }
        }





        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetItem(string id)
        {
            var movie = await _services.GetMovieById(id);

            if (movie == null)
            {
                return BadRequest();
            }
            else
            {
                var movieDto = movie.MovieToDto();
                return Ok(movieDto);
            }
        }

        [HttpGet]
        [Route(nameof(GetGenres))]
        public async Task<ActionResult<IEnumerable<CartDto>>> GetGenres()
        {
            var genres = await _services.GetGenres();
            var genreDtos = genres.GenreToDto();
            return Ok(genreDtos);

        }


        [HttpGet]
        [Route("{genreId}/GtMovieByGenre")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovieByGenre(string genreId)
        {
            var movies = await _services.GetMovieByGenre(genreId);
            var moviesDtos = movies.MovieToDto();
            return Ok(moviesDtos);
        }
    }
}













        //// GET: api/<MoviesController>
        //[HttpGet]
        //public async Task<ActionResult<List<Movie>>> Get()
        //{
        //    var movies = await _services.();
        //    return Ok(movies);
        //}

        //// GET api/<MoviesController>/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Movie>> Get(string id)
        //{
        //    var movie = await _services.GetById(id);
        //    return (movie == null) ? NotFound($"Movie with Id = {id} not found") : Ok(movie);
        //}

        //[HttpGet("title")]
        //public async Task<ActionResult<List<Movie>>> GetByTitle(string title)
        //{
        //    var movies = await _services.GetByTitle(title);
        //    return (movies == null) ? NotFound($"Movies with title = {title} not found") : Ok(movies);
        //}

        ////// POST api/<MoviesController>
        ////[HttpPost]
        ////public async Task<ActionResult<Movie>> Crate(string title, int yers, double rate, string summary, List<string> actors, string url)
        ////{
        ////    var newMovie = await _services.CreateAsync(title, yers, rate, summary, actors, url);
        ////    return (newMovie);
        ////}

        //// POST api/<MoviesController>
        //[HttpPost]
        //public async Task<ActionResult<Movie>> Crate([FromForm]Movie movie)
        //{
        //    var newMovie = _services.CreateAsync(movie.Title, movie.Genre, movie.Year, movie.Rate, movie.Summary, movie.Actors, movie.ImageUrl) ;
        //    return Ok(newMovie);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(string id, [FromBody]Movie updateMovie)
        //{
        //    var ExistingMovie = await _services.GetById(id);
        //    if (ExistingMovie is null) return NotFound($"Movie with Id = {id} not found");
        //    await _services.Update(id, updateMovie);
        //    return Ok(ExistingMovie);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(string id)
        //{
        //    var ExistingMovie = await _services.GetById(id);
        //    if (ExistingMovie is null) return NotFound($"Movie with Id = {id} not found");
        //    await _services.Remove(id);
        //    return Ok(ExistingMovie);
        //}


    

