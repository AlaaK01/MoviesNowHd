using Blazor.Shared.Dto;
using Microsoft.AspNetCore.Components;

namespace Blazor.Client.Pages
{
    public class CardMovieBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<MovieDto> movies { get; set; }
    }
}
