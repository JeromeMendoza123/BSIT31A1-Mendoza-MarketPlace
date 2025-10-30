using BSIT31A1_Mendoza_MarketPlace.Infrastructure;

namespace BSIT31A1_Mendoza_MarketPlace.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<Item?> GetItemByIdAsync(int id);
        Task AddItemAsync(Item item);
        Task DeleteItemAsync(int id);
    }
}
