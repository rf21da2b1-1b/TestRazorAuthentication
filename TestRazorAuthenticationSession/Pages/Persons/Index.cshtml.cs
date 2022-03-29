using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAuthenticationLib.model;
using TestRazorAuthenticationSession.Services;

namespace TestRazorAuthenticationSession.Pages.Persons
{
    
    public class IndexModel : PageModel
    {

        public static User LoggedInUser { get; set; } = null;
        private readonly IUserService _userService;


        
        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            if (LoginModel.LoggedInUser == null)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToPage("/Index");
            }

            return Page();
        }

        
    }
}
