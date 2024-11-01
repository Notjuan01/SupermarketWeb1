using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarkerEF.Data;
using SupermarketWeb.Models;
using SupermarketWEB.Models;

namespace SupermarketWeb.Pages.Product
{
    public class EditModel : PageModel
    {
		private readonly SupermarketContext _context;

		public EditModel(SupermarketContext context)
		{
			_context = context;
		}
		[BindProperty]
		public product Products { get; set; } = default!;
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Products = await _context.Products.FindAsync(id);

			if (Products == null)
			{
				return NotFound();
			}

			return Page();
		}



		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			var productInDb = await _context.Products.FindAsync(Products.Id);

			if (productInDb == null)
			{
				return NotFound();
			}


			_context.Entry(productInDb).CurrentValues.SetValues(Products);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{

			}

			return RedirectToPage("./Index");
		}
		private bool productExists(int id)
		{
			return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
