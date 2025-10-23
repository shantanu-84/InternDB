using Microsoft.AspNetCore.Identity;
using InternDB.Data;

namespace InternDB.Services;

public class AuthenticationService
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    
    public AuthenticationService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    
    public async Task<SignInResult> LoginAsync(string userName, string password, bool rememberMe = true)
    {
        try
        {
            return await _signInManager.PasswordSignInAsync(userName, password, rememberMe, lockoutOnFailure: false);
        }
        catch (Exception)
        {
            return SignInResult.Failed;
        }
    }
    
    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
    
    public async Task<ApplicationUser?> GetCurrentUserAsync(System.Security.Claims.ClaimsPrincipal user)
    {
        return await _userManager.GetUserAsync(user);
    }
}
