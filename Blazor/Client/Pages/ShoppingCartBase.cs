using Blazor.Client.ClientServices;
using Blazor.Shared.Dto;
using Microsoft.AspNetCore.Components;
using ShopApp.client;

namespace Blazor.Client.Pages
{
    public class ShoppingCartBase : ComponentBase
    {
        [Inject]
        public IClientUsersServices _clientUsersServices { get; set; }
        public List<CartMovieDto> _cartMovies { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _cartMovies = await _clientUsersServices.GetMovies(HardCoded.UserId);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
