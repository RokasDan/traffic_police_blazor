﻿using Microsoft.AspNetCore.Components;

namespace TrafficPoliceBlazor.Pages
{
    public partial class Index : ComponentBase
    {

        // Just testing how C# logic works with razor mark up.
        private string headerName = "Traffic Police";


        // Using NavigationManager provided by Brazor to switch go to other page components.
        private void NavigateToPage()
        {
            NavigationManager.NavigateTo("/login");
        }
    }
}
