using Microsoft.AspNetCore.Components;
using TrafficPoliceBlazor.Shared;


namespace TrafficPoliceBlazor.Client.Components
{
    public partial class CriminalScum : ComponentBase
    {
        private void GoToLogin()
        {
            NavigationManager.NavigateTo($"/Login");
        }
    }
}
