using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarkerEF.Data;
using SupermarketWeb.Models;

namespace SupermarketWeb.Pages.Customers
{
    public class IndexModel : PageModel
    {
			private readonly SupermarketContext _context;

			public IndexModel(SupermarketContext context)
			{
				_context = context;
			}

			public IList<Customer> Customers { get; set; }

			public async Task OnGetAsync()
			{
				Customers = await _context.Customers.ToListAsync();
			}
		}
}
