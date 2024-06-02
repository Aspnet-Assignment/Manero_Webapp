using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components;
using Manero_WebApp.Data;

namespace Manero_WebApp.Services
{
    public class LoginService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IdentityRedirectManager _redirectManager;

        public LoginService(SignInManager<ApplicationUser> signInManager, IdentityRedirectManager redirectManager)
        {
            _signInManager = signInManager;
            _redirectManager = redirectManager;
        }

        public string? ErrorMessage { get; set; }

        [SupplyParameterFromForm]
        public InputModel Input { get; set; } = new();

        [SupplyParameterFromQuery]
        public string? ReturnUrl { get; set; }

        public async Task LoginUser()
        {
            var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _redirectManager.RedirectTo("/producthome");
            }
        }

        public sealed class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = "";

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = "";

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
    }

    public class IdentityRedirectManager
    {
        private readonly NavigationManager _navigationManager;

        public IdentityRedirectManager(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        [DoesNotReturn]
        public void RedirectTo(string? uri)
        {
            uri ??= "";
            _navigationManager.NavigateTo(uri);
            throw new InvalidOperationException($"{nameof(IdentityRedirectManager)} can only be used during static rendering.");
        }
    }
}
