using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BSIT31A1_Mendoza_MarketPlace.Infrastructure;

namespace BSIT31A1_Mendoza_MarketPlace.Pages_Interests
{
    public class CreateModel : PageModel
    {
        private readonly BSIT31A1_Mendoza_MarketPlace.Infrastructure.MarketplaceDbContext _context;

        public CreateModel(BSIT31A1_Mendoza_MarketPlace.Infrastructure.MarketplaceDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Interest Interest { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Interests.Add(Interest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
