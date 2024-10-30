using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarkerEF.Data;
using SupermarketWEB.Models;

namespace SupermarketWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;
        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null || _context.Categories == null)
            {
                return NotFound();
            }
            var category =await _context.Categories.FirstAsync();

            if (category == null)
            {
                Category = category;
                _context.Categories.Remove(Category);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
