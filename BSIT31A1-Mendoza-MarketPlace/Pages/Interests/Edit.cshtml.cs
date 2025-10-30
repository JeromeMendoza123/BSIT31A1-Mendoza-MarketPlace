using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BSIT31A1_Mendoza_MarketPlace.Infrastructure;

namespace BSIT31A1_Mendoza_MarketPlace.Pages_Interests
{
    public class EditModel : PageModel
    {
        private readonly BSIT31A1_Mendoza_MarketPlace.Infrastructure.MarketplaceDbContext _context;

        public EditModel(BSIT31A1_Mendoza_MarketPlace.Infrastructure.MarketplaceDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Interest Interest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interest =  await _context.Interests.FirstOrDefaultAsync(m => m.Id == id);
            if (interest == null)
            {
                return NotFound();
            }
            Interest = interest;
           ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Interest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterestExists(Interest.Id))
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

        private bool InterestExists(int id)
        {
            return _context.Interests.Any(e => e.Id == id);
        }
    }
}
