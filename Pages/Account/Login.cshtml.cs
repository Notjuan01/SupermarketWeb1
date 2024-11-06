using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWeb.Models;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs;

namespace SupermarketWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            Console.WriteLine("User: " + user.Email + " Password: " + user.Password);
        }
    }
}
