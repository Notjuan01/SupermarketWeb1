using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarkerEF.Data;
using SupermarketWeb.Models;

namespace SupermarketWeb.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly SupermarketContext _context;

        public CreateModel(SupermarketContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customers { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Customers == null || Customers == null)
            {
                return Page();
            }

            _context.Customers.Add(Customers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
