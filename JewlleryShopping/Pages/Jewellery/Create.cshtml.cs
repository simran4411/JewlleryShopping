using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JewlleryShopping.Bussiness;
using JewlleryShopping.Data;

namespace JewlleryShopping.Pages.Jewellery
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
            return Page();
        }

        [BindProperty]
        public JewlleryShopping.Bussiness.Jewellery Jewellery { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Jewelleries.Add(Jewellery);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}