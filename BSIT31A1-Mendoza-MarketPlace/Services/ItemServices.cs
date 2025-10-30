using BSIT31A1_Mendoza_MarketPlace.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BSIT31A1_Mendoza_MarketPlace.Services
{
    public class ItemService : IItemService
    {
        private readonly MarketplaceDbContext _context;
        public ItemService(MarketplaceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _context.Items.Include(i => i.Interests).ToListAsync();
        }

        public async Task<Item?> GetItemByIdAsync(int id)
        {
            return await _context.Items.Include(i => i.Interests).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddItemAsync(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
