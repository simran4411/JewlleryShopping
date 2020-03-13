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
    public class IndexModel : PageModel
    {
        private readonly JewlleryShopping.Data.ApplicationDbContext _context;

        public IndexModel(JewlleryShopping.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<JewlleryShopping.Bussiness.Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers
                .Include(c => c.Category)
                .Include(c => c.Jewellery).ToListAsync();
        }
    }
}
