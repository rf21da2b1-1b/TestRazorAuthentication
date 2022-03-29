using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAuthenticationLib.model;
using TestRazorAuthenticationSession.Services;

namespace TestRazorAuthenticationSession.Pages.Persons
{
    public class LoginModel : PageModel
    {

        public static User LoggedInUser { get; set; } = null;
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

            if (_userService.Contains(user))
            {
                LoggedInUser = user;

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, UserName),
                    new Claim(ClaimTypes.Role, RoleType.Member.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                return RedirectToPage("/Persons/Index");
            }

            Message = "Invalid attempt";
            return Page();

        }
    }
}
