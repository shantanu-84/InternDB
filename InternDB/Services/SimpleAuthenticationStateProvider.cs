using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace InternDB.Services
{
    public class SimpleAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;

        public SimpleAuthenticationStateProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var cookieValue = await _jsRuntime.InvokeAsync<string>("eval", "document.cookie.split('; ').find(row => row.startsWith('AdminLoggedIn='))?.split('=')[1]");
                
                if (cookieValue == "true")
                {
                    // Check if it's admin or intern login
                    var roleCookie = await _jsRuntime.InvokeAsync<string>("eval", "document.cookie.split('; ').find(row => row.startsWith('UserRole='))?.split('=')[1]");
                    
                    var role = roleCookie == "Intern" ? "Intern" : "Admin";
                    var name = roleCookie == "Intern" ? "intern" : "admin";
                    
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, name),
                        new Claim(ClaimTypes.NameIdentifier, name),
                        new Claim(ClaimTypes.Role, role),
                        new Claim("IsAuthenticated", "true")
                    };

                    var identity = new ClaimsIdentity(claims, "simple");
                    var principal = new ClaimsPrincipal(identity);
                    return new AuthenticationState(principal);
                }
            }
            catch
            {
                // Ignore errors and return unauthenticated state
            }

            return new AuthenticationState(new ClaimsPrincipal());
        }

        public void NotifyUserAuthentication(string role = "Admin")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, role.ToLower()),
                new Claim(ClaimTypes.NameIdentifier, role.ToLower()),
                new Claim(ClaimTypes.Role, role),
                new Claim("IsAuthenticated", "true")
            };

            var identity = new ClaimsIdentity(claims, "simple");
            var principal = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
        }

        public void NotifyUserLogout()
        {
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }
    }
}
