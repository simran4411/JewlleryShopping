using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewlleryShopping.Bussiness;
using JewlleryShopping.Data;

namespace JewlleryShopping.Pages.Customer
{
    public class DetailsModel : PageModel
    {
        private readonly JewlleryShopping.Data.ApplicationDbContext _context;

        public DetailsModel(JewlleryShopping.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
