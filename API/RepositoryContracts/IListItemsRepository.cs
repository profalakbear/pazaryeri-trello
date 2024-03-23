using API.Data.Models;

namespace API.RepositoryContracts
{
    public interface IListItemsRepository
    {
        Task<List<ListItem>> GetAllListItemsAsync();
        Task<List<ListItem>> GetListItemsByUserAsync(int userId);
        Task<ListItem?> GetListItemAsync(int listItemId);
        Task<ListItem> AddListItemAsync(ListItem listItem);
        Task<ListItem?> UpdateListItemAsync(ListItem listItem);
        Task<bool> DeleteListItemAsync(int listItemId);
    }
}
