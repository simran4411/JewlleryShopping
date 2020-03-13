using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JewlleryShopping.Bussiness;
using JewlleryShopping.Data;

namespace JewlleryShopping.Pages.Customer
{
    public class EditModel : PageModel
    {
        private readonly JewlleryShopping.Data.ApplicationDbContext _context;

        public EditModel(JewlleryShopping.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JewlleryShopping.Bussiness.Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers
                .Include(c => c.Category)
                .Include(c => c.Jewellery).SingleOrDefaultAsync(m => m.ID == id);

            if (Customer == null)
            {
                return NotFound();
            }
           ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name");
           ViewData["JewelleryID"] = new SelectList(_context.Jewelleries, "ID", "Name");
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
                if (!CustomerExists(Customer.ID))
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
            return _context.Customers.Any(e => e.ID == id);
        }
    }
}
