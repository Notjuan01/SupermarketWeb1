using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarkerEF.Data;
using SupermarketWeb.Models;

namespace SupermarketWeb.Pages.PayMode
{
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;

        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PayModel PayMode { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PayMode = await _context.PayModes.FindAsync(id);

            if (PayMode == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PayModes == null)
            {
                return NotFound();
            }

            var payMode = await _context.PayModes.FindAsync(id);

            if (payMode == null)
            {
                return NotFound();
            }

            _context.PayModes.Remove(payMode); 
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

