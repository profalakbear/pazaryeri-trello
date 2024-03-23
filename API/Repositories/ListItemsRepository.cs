using API.Data;
using API.Data.Models;
using API.RepositoryContracts;
using API.UoW;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class ListItemsRepository : IListItemsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ListItemsRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ListItem>> GetAllListItemsAsync()
        {
            return await _context.Lists.ToListAsync();
        }

        public async Task<List<ListItem>> GetListItemsByUserAsync(int userId)
        {
            return await _context.Lists
                .Include(list => list.Cards)
                .Where(item => item.UserID == userId)
                .ToListAsync();
        }

        public async Task<ListItem?> GetListItemAsync(int listItemId)
        {
            return await _context.Lists.FindAsync(listItemId);
        }

        public async Task<ListItem> AddListItemAsync(ListItem listItem)
        {
            await _context.Lists.AddAsync(listItem);
            await _unitOfWork.SaveChangesAsync();
            return listItem;
        }

        public async Task<ListItem?> UpdateListItemAsync(ListItem listItem)
        {
            var existingListItem = await _context.Lists.FindAsync(listItem.ID);

            if (existingListItem == null)
            {
                return null;
            }

            _context.Entry(existingListItem).CurrentValues.SetValues(listItem);
            await _unitOfWork.SaveChangesAsync();

            return existingListItem;
        }

        public async Task<bool> DeleteListItemAsync(int listItemId)
        {
            var listItem = await _context.Lists.FindAsync(listItemId);
            if (listItem == null)
                return false;

            _context.Lists.Remove(listItem);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
