using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SupermarkerEF.Data;
using SupermarketWEB.Models;

namespace SupermarketWeb.Pages.Categories
{
    public class EditModel : PageModel
    {
     private readonly SupermarketContext _context;

    public EditModel(SupermarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Category Category { get; set; } = default!;
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Category = await _context.Categories.FindAsync(id);

			if (Category == null)
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

			var categoryInDb = await _context.Categories.FindAsync(Category.Id);

			if (categoryInDb == null)
			{
				return NotFound();
			}

			_context.Entry(categoryInDb).CurrentValues.SetValues(Category);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{

			}

			return RedirectToPage("./Index");
		}
		private bool CategoryExists(int id)
        {
            return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
	}
}
