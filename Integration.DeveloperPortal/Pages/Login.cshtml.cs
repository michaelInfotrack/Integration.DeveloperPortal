using Integration.DeveloperPortal.Logic.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Integration.DeveloperPortal.Pages.Authentication
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginCredentialsModel LoginCredentialModel { get; set; }
        [BindProperty]
        public string ReturnUrl { get; set; }
        private Logic.Interfaces.IAuthenticationService _authenticationService;

        public LoginModel(Logic.Interfaces.IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        
        public IActionResult OnPostLogin(string returnUrl = null)
        {
            Console.WriteLine("It is hitting the post");

            try
            {
                var appUser = _authenticationService.Login(LoginCredentialModel.Username, LoginCredentialModel.Password);

                if (appUser != null && appUser.IsAuthenticated)
                {
                    var userClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, appUser.Username, ClaimValueTypes.String, "app"),
                            new Claim(ClaimTypes.Email, appUser.EmailAddress, ClaimValueTypes.String, "app")
                        };

                    var principal =
                        new ClaimsPrincipal(new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme));

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        principal, new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.UtcNow.AddYears(1),
                            IsPersistent = true,
                            AllowRefresh = false

                        });

                    if (returnUrl == null)
                    {
                        return RedirectToPage("/Index");
                    }

                    return RedirectToPage(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Login failed");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
           
            return Page();
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage();
        }
    }
}