using Blazor.Client.ClientServices;
using Blazor.Shared.Dto;
using Microsoft.AspNetCore.Components;

namespace Blazor.Client.Pages
{
    public class MovieDetailsBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        public IClientMoviesServices _clientMoviesServices { get; set; }
        [Inject]
        public IClientUsersServices _clientUsersServices { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public MovieDto _movie { get; set; }
        public string ErrorMessage { get; set; }
        public List<CartMovieDto> Items { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                _movie = await _clientMoviesServices.GetMovie(Id);
            }
            catch (Exception ex) { ErrorMessage = ex.Message; }
        }

    }
}
