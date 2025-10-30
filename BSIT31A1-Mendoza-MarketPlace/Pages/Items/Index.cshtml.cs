using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BSIT31A1_Mendoza_MarketPlace.Infrastructure;

namespace BSIT31A1_Mendoza_MarketPlace.Pages_Items
{
    public class IndexModel : PageModel
    {
        private readonly BSIT31A1_Mendoza_MarketPlace.Infrastructure.MarketplaceDbContext _context;

        public IndexModel(BSIT31A1_Mendoza_MarketPlace.Infrastructure.MarketplaceDbContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Item = await _context.Items.ToListAsync();
        }
    }
}
