using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarkerEF.Data;
using SupermarketWeb.Models;


namespace SupermarketWeb.Pages.PayMode
{
    [Authorize]
    public class IndexModel : PageModel
	{
		private readonly SupermarketContext _context;

		public IndexModel(SupermarketContext context)
		{
			_context = context;
		}

		public IList<PayModel> PayModes { get; set; }

		public async Task OnGetAsync()
		{
			PayModes = await _context.PayModes.ToListAsync();
		}
	}
}
