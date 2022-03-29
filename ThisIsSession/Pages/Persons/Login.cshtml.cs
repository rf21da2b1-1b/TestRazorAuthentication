using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAuthenticationLib.model;
using TestRazorAuthenticationSession.Services;

namespace ThisIsSession.Pages.Persons
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;



        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }



        [BindProperty]
        public String UserName { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public String Message { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            User user = new User(UserName, Password);
            _userService.ContainsAndGiveRole(user);
            // sætter session 
            HttpContext.Session.SetString(Konfig.Login, JsonSerializer.Serialize(user));

            if (user.IsGuest)
            {
                Message = "Fortsæt som gæst eller login";
                return Page();
            }

            return RedirectToPage("/Persons/Index");
        }
    }
}
