using API.Data.Models;
using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Repositories;
using API.UoW;
using API.RepositoryContracts;

namespace API.Repositories
{
    public class CardsRepository : ICardsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CardsRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }


        public async Task<Card?> GetCardAsync(int cardId)
        {
            return await _context.Cards.FindAsync(cardId);
        }

        public async Task<List<Card>> GetAllCardsAsync()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task<List<Card>> GetCardsByListAsync(int listId)
        {
            return await _context.Cards.Where(c => c.ListID == listId).ToListAsync();
        }

        public async Task<Card> AddCardAsync(Card card)
        {
            _context.Cards.Add(card);
            await _unitOfWork.SaveChangesAsync();
            return card;
        }

        public async Task<Card?> UpdateCardAsync(Card card)
        {
            var existingCard = await _context.Cards.FindAsync(card.ID);

            if (existingCard == null)
            {
                return null;
            }

            _context.Entry(existingCard).CurrentValues.SetValues(card);
            await _unitOfWork.SaveChangesAsync();

            return existingCard;
        }

        public async Task<bool> DeleteCardAsync(int cardId)
        {
            var card = await _context.Cards.FindAsync(cardId);
            if (card == null)
                return false;

            _context.Cards.Remove(card);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
