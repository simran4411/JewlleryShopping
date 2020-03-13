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

namespace JewlleryShopping.Pages.Jewellery
{
    public class EditModel : PageModel
    {
        private readonly JewlleryShopping.Data.ApplicationDbContext _context;

        public EditModel(JewlleryShopping.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Jewellery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JewelleryExists(Jewellery.ID))
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

        private bool JewelleryExists(int id)
        {
            return _context.Jewelleries.Any(e => e.ID == id);
        }
    }
}
