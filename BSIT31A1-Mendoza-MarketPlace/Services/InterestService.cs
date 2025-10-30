using BSIT31A1_Mendoza_MarketPlace.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BSIT31A1_Mendoza_MarketPlace.Services
{
    public class InterestService : IInterestService
    {
        private readonly MarketplaceDbContext _context;
        public InterestService(MarketplaceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Interest>> GetInterestsByItemIdAsync(int itemId)
        {
            return await _context.Interests.Where(i => i.ItemId == itemId).ToListAsync();
        }

        public async Task AddInterestAsync(Interest interest)
        {
            _context.Interests.Add(interest);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveInterestAsync(int interestId)
        {
            var interest = await _context.Interests.FindAsync(interestId);
            if (interest != null)
            {
                _context.Interests.Remove(interest);
                await _context.SaveChangesAsync();
            }
        }
    }
}
