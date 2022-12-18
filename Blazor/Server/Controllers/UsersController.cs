using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blazor.Shared.Models;
using Blazor.Shared.Dto;
using Blazor.Server.Services;
using Blazor.Server.Operations;

namespace Blizor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _usersServices;
        public UsersController (IUsersServices usersServices) => _usersServices = usersServices;



        [HttpGet]
        [Route("{userId}/GetMovieItem")]
        public async Task<ActionResult<IEnumerable<CartMovieDto>>> GetMovieItem(string userId)
        {
            var cartMovies = await _usersServices.GetCartMovies(userId);

            if (cartMovies == null)
            {
                return NoContent();
            }

            var movies = await _usersServices.GetAllMovies();

            if (movies == null)
            {
                throw new Exception("No movies exist in the system");
            }

            var cartMoviesDto = cartMovies.CartMoviesToDto(movies);

            return Ok(cartMoviesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartMovieDto>> GetMovie(string id)
        {
            var cartMovie = await _usersServices.GetCartMovie(id);
            if (cartMovie == null)     return NotFound(); 

            var movie = await _usersServices.GetMovieById(cartMovie.MovieId);
            if (movie == null) return NotFound();
                
            var cartMovieDtos = cartMovie.CartMovieToDto(movie);
            return Ok(cartMovieDtos);
        }

        [HttpPost]
        public async Task<ActionResult<CartMovieDto>> AddMovie([FromBody] CartMovieToAddDto cartMovieToAddDto)
        {
            var newCartMovie = await _usersServices.AddMovie(cartMovieToAddDto);  
            if (newCartMovie == null) return NoContent();

            var movie = await _usersServices.GetMovieById(newCartMovie.MovieId);
            if (movie == null) return NotFound();

            var cartMovieDto = newCartMovie.CartMovieToDto(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = cartMovieDto.Id }, cartMovieDto);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CartMovieDto>> DeleteMovie(string id)
        {
            var cartMovie = await _usersServices.RemoveMovie(id);
            if (cartMovie == null) return NotFound();

            var movie = await _usersServices.GetMovieById(cartMovie.MovieId);
            if (movie == null) return NotFound();

            var cartMovieDto = cartMovie.CartMovieToDto(movie);
            return Ok(cartMovieDto);

        }

        
    }
}
