using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace TrafficPoliceBlazor.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        // Accesing local storage
        public CustomAuthStateProvider(ILocalStorageService localStorage) 
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Creating empty claims
            var state = new AuthenticationState(new ClaimsPrincipal());

            // Checking if user name is not empty in local storage.
            string username = await _localStorage.GetItemAsStringAsync("username");
            if(!string.IsNullOrEmpty(username))
            {
                // Creating a new identity for claims
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)  
                }, "testing authentication type");

                state = new AuthenticationState(new ClaimsPrincipal(identity));
            }

            // Event to inform os authentication state change
            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
    }
}
