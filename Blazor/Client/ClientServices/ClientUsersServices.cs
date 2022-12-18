using Blazor.Shared.Dto;
using System.Net.Http;
using System.Net.Http.Json;

namespace Blazor.Client.ClientServices
{
    public class ClientUsersServices : IClientUsersServices
    {
        private readonly HttpClient _httpClient;
        public ClientUsersServices(HttpClient httpClient) => _httpClient = httpClient;




        public async Task<CartMovieDto> AddMovie(CartMovieToAddDto cartMovieToAddDto)
        {
            var response = await _httpClient.PostAsJsonAsync<CartMovieToAddDto>("api/ShoppingCart", cartMovieToAddDto);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default(CartMovieDto);
                }

                return await response.Content.ReadFromJsonAsync<CartMovieDto>();

            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status:{response.StatusCode} Message -{message}");
            }
        }

        public async Task<CartMovieDto> DeleteMovie(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/ShoppingCart/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CartMovieDto>();
            }
            return default(CartMovieDto);
        }

        public async Task<List<CartMovieDto>> GetMovies(string userId)
        {
            var response = await _httpClient.GetAsync($"api/ShoppingCart/{userId}/GetMovies");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<CartMovieDto>().ToList();
                }
                return await response.Content.ReadFromJsonAsync<List<CartMovieDto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
            }
        }
    }
}
