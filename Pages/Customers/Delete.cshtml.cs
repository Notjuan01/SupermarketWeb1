using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarkerEF.Data;
using SupermarketWeb.Models;

namespace SupermarketWeb.Pages.Customers
{
	public class DeleteModel : PageModel
	{
		private readonly SupermarketContext _context;

		public DeleteModel(SupermarketContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Customer Customer { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Customer = await _context.Customers.FindAsync(id);

			if (Customer == null)
			{
				return NotFound();
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var customer = await _context.Customers.FindAsync(id);

			if (customer == null)
			{
				return NotFound();
			}

			_context.Customers.Remove(customer);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
