using Microsoft.AspNetCore.Components;

namespace TrafficPoliceBlazor.Pages
{
    public partial class Index : ComponentBase
    {
        public string headerName = "Traffic Police";

        private void NavigateToPage()
        {
            NavigationManager.NavigateTo("/login");
        }
    }
}
