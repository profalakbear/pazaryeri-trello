using API.Data.Models;
using API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.ServiceContracts
{
    public interface IListItemsService
    {
        Task<List<ListDTO>> GetAllListItemsAsync();
        Task<List<ListItem>> GetListItemsByUserAsync(int userId);
        Task<ListDTO?> GetListItemAsync(int listItemId);
        Task<ListDTO> AddListItemAsync(ListDTO listItem);
        Task<ListDTO?> UpdateListItemAsync(ListDTO listItem);
        Task<bool> DeleteListItemAsync(int listItemId);
    }
}
