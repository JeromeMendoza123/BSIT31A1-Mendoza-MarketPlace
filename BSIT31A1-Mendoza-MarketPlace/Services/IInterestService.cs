using BSIT31A1_Mendoza_MarketPlace.Infrastructure;

namespace BSIT31A1_Mendoza_MarketPlace.Services
{
    public interface IInterestService
    {
        Task<IEnumerable<Interest>> GetInterestsByItemIdAsync(int itemId);
        Task AddInterestAsync(Interest interest);
        Task RemoveInterestAsync(int interestId);
    }
}
