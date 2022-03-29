using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRazorAuthenticationSession.Services;

namespace ThisIsSession.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if (!(HttpContext.Session.IsAvailable && HttpContext.Session.Keys.Contains(Konfig.Login)))
            {
                return RedirectToPage("/Persons/Login");
            }

            return Page();
        }
    }
}
