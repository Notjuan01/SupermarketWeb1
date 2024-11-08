using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarkerEF.Data;
using SupermarketWEB.Models;

namespace SupermarketWeb.Pages.Categories
{
    [Authorize]
    public class IndexModel : PageModel
    {
       
        private readonly SupermarketContext _context;
#pragma warning disable IDE0290 // Usar constructor principal
		public IndexModel(SupermarketContext context)
#pragma warning restore IDE0290 // Usar constructor principal
		{
            _context = context;
        }
        public IList<Category> Categories { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Categories = await _context.Categories.ToListAsync();
            }
        }

        }
}
