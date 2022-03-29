using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAuthenticationLib.model;
using TestRazorAuthenticationSession.Services;

namespace ThisIsSession.Pages.Persons
{
    public class IndexModel : PageModel
    {
        public User user { get; private set; }
        public IActionResult OnGet()
        {
            if (!(HttpContext.Session.IsAvailable && HttpContext.Session.Keys.Contains(Konfig.Login)))
            {
                return RedirectToPage("/Persons/Login");
            }

            user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString(Konfig.Login));

            return Page();
        }
    }
}
