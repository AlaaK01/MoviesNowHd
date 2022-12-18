using Blazor.Shared.Dto;
using Blazor.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text.Json;

namespace Blazor.Client.ClientServices
{
    public class ClientMoviesServices : IClientMoviesServices
    {
        private readonly HttpClient _httpClient;
        public ClientMoviesServices(HttpClient httpClient) => _httpClient = httpClient;


        public async Task<IEnumerable<MovieDto>> GetMovies()
        {

            var response = await _httpClient.GetAsync("api/Movies");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<MovieDto>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<MovieDto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }

        }

        public async Task<MovieDto> GetMovie(string id)
        {
            var response = await _httpClient.GetAsync($"api/Movies/{id}");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default(MovieDto);
                }

                return await response.Content.ReadFromJsonAsync<MovieDto>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status code: {response.StatusCode} message: {message}");
            }
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByGenre(string genreId)
        {
            var response = await _httpClient.GetAsync($"api/Movies/{genreId}/GetMoviesByGenre");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<MovieDto>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<MovieDto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
            }


        }

        public async Task<IEnumerable<GenreDto>> GetGenres()
        {
            var response = await _httpClient.GetAsync("api/Movies/GetGenres");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<GenreDto>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<GenreDto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
            }
        }
    }
}

