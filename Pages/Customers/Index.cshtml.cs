using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarkerEF.Data;
using SupermarketWeb.Models;
using SupermarketWEB.Models;

namespace SupermarketWeb.Pages.Customers
{
	public class IndexModel : PageModel
	{
		private readonly SupermarketContext _context;
#pragma warning disable IDE0290 // Usar constructor principal
		public IndexModel(SupermarketContext context)
#pragma warning restore IDE0290 // Usar constructor principal
		{
			_context = context;
		}
		public IList<Customer> Customers { get; set; } = default!;

		public async Task OnGetAsync()
		{
			if (_context.Customers != null)
			{
				Customers = await _context.Customers.ToListAsync();
			}
		}
	}
    }

