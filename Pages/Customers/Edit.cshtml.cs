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

            Customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);

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

            // Confirm that the Customer record exists in the database
            var customerToUpdate = await _context.Customers.FirstOrDefaultAsync(c => c.Id == Customer.Id);
            if (customerToUpdate == null)
            {
                return NotFound();
            }

            // Only update fields that are allowed to be edited
            customerToUpdate.document_number = Customer.document_number;
            customerToUpdate.firts_name = Customer.firts_name;
            customerToUpdate.last_name = Customer.last_name;
            customerToUpdate.address = Customer.address;
            customerToUpdate.birthday = Customer.birthday;
            customerToUpdate.phone_numbers = Customer.phone_numbers;
            customerToUpdate.email = Customer.email;

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

