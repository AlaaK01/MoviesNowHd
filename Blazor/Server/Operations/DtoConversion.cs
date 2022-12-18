using Blazor.Shared.Dto;
using Blazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Operations
{
    public static class DtoConversion
    {
        public static IEnumerable<CartDto> GenreToDto(this IEnumerable<Genre> Genres)
        {
            return (from genre in Genres
                    select new CartDto
                    {
                        Id = genre.Id,
                        Name = genre.genreName
                    }).ToList();
        }

        public static IEnumerable<MovieDto> MoviesToDto(this IEnumerable<Movie> movies)
        {
            return (from movie in movies
                    select new MovieDto
                    {
                        Id = movie.Id,
                        Title = movie.Title,
                        Genre = movie.Genre,
                        Year = movie.Year,
                        Rate = movie.Rate,
                        Price = movie.Price,
                        Summary = movie.Summary,
                        Actors = movie.Actors,
                        ImageUrl = movie.ImageUrl
                    }).ToList();

        }

        public static MovieDto MovieToDto(this Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Year = movie.Year,
                Rate = movie.Rate,
                Price = movie.Price,
                Summary = movie.Summary,
                Actors = movie.Actors,
                ImageUrl = movie.ImageUrl
            };
        }

        public static IEnumerable<CartMovieDto> CartMoviesToDto(this IEnumerable<CartMovie> cartMovies,
                                                            IEnumerable<Movie> movies)
        {
            return (from cartMovie in cartMovies
                    join movie in movies
                    on cartMovie.MovieId equals movie.Id
                    select new CartMovieDto
                    {
                        Id = cartMovie.Id,
                        MovieId = cartMovie.MovieId,
                        CartId = cartMovie.MovieId,
                        Title = movie.Title,
                        Genre = movie.Genre,
                        Year = movie.Year,
                        Rate = movie.Rate,
                        Summary = movie.Summary,
                        Actors = movie.Actors,
                        ImageUrl = movie.ImageUrl,
                        Price = movie.Price,
                        Quantity = cartMovie.Quantity,
                        TotalPrice = movie.Price * cartMovie.Quantity
                    }).ToList();
        }

        public static CartMovieDto CartMovieToDto(this CartMovie cartMovie, Movie movie)
        {
            return new CartMovieDto
            {
                Id = cartMovie.Id,
                MovieId = cartMovie.MovieId,
                CartId = cartMovie.MovieId,
                Title = movie.Title,
                Genre = movie.Genre,
                Year = movie.Year,
                Rate = movie.Rate,
                Summary = movie.Summary,
                Actors = movie.Actors,
                ImageUrl = movie.ImageUrl,
                Price = movie.Price,
                Quantity = cartMovie.Quantity,
                TotalPrice = movie.Price * cartMovie.Quantity
            };
        }
    }
}
