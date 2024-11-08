using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarkerEF.Data;
using SupermarketWeb.Models;

namespace SupermarketWeb.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SupermarketContext _context;

        public RegisterModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (_context.Users.Any(u => u.Email == User.Email))
            {
                ModelState.AddModelError(string.Empty, "Email already exists.");
                return Page();
            }


            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Login");

        }
    }
}
