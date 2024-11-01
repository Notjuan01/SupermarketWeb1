using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarkerEF.Data;
using SupermarketWeb.Models;

namespace SupermarketWeb.Pages.Customers
{
    public class EditModel : PageModel
    {
			private readonly SupermarketContext _context;

			public EditModel(SupermarketContext context)
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

			public async Task<IActionResult> OnPostAsync()
			{
				if (!ModelState.IsValid)
				{
					return Page();
				}

				_context.Attach(Customer).State = EntityState.Modified;

				try
				{
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CustomerExists(Customer.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}

				return RedirectToPage("./Index");
			}

			private bool CustomerExists(int id)
			{
				return _context.Customers.Any(e => e.Id == id);
			}
		}

	}

