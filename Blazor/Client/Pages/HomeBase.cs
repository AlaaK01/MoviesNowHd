using Blazor.Client.ClientServices;
using Blazor.Shared.Dto;
using Microsoft.AspNetCore.Components;

namespace Blazor.Client.Pages
{
    public class HomeBase : ComponentBase
    {
        [Inject]
        public IClientMoviesServices ClientMoviesServices { get; set; }
        public IEnumerable<MovieDto> _movies { get; set; }
        protected override async Task OnInitializedAsync()
        {
            _movies = await ClientMoviesServices.GetMovies();
        }
    }
}
