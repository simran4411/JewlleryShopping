using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JewlleryShopping.Bussiness;
using JewlleryShopping.Data;

namespace JewlleryShopping.Pages.Customer
{
    public class CreateModel : PageModel
    {
        private readonly JewlleryShopping.Data.ApplicationDbContext _context;

        public CreateModel(JewlleryShopping.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name");
        ViewData["JewelleryID"] = new SelectList(_context.Jewelleries, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public JewlleryShopping.Bussiness.Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}