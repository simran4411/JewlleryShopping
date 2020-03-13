using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JewlleryShopping.Bussiness;
using JewlleryShopping.Data;

namespace JewlleryShopping.Pages.Category
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
        public JewlleryShopping.Bussiness.Category Category { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}