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
		public Customer Customer { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Customers.Add(Customer);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}

	}
}
