using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewlleryShopping.Bussiness;
using JewlleryShopping.Data;

namespace JewlleryShopping.Pages.Jewellery
{
    public class DeleteModel : PageModel
    {
        private readonly JewlleryShopping.Data.ApplicationDbContext _context;

        public DeleteModel(JewlleryShopping.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JewlleryShopping.Bussiness.Jewellery Jewellery { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Jewellery = await _context.Jewelleries.SingleOrDefaultAsync(m => m.ID == id);

            if (Jewellery == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Jewellery = await _context.Jewelleries.FindAsync(id);

            if (Jewellery != null)
            {
                _context.Jewelleries.Remove(Jewellery);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
