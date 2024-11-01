using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarkerEF.Data;
using SupermarketWeb.Models;
using SupermarketWEB.Models;
using System.Threading.Tasks;

namespace SupermarketWeb.Pages.PayMode
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
		public PayModel Paymode { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.PayModes == null || Paymode == null)
			{
				return Page();
			}

			_context.PayModes.Add(Paymode);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
