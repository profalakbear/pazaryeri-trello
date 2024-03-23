using API.Data.Models;
using API.DTOs;

namespace API.ServiceContracts
{
    public interface ICardsService
    {
        Task<Card?> GetCardAsync(int cardId);
        Task<List<Card>> GetAllCardsAsync();
        Task<List<Card>> GetCardsByListAsync(int listId);
        Task<Card> AddCardAsync(CardDTO card);
        Task<Card?> UpdateCardAsync(Card card);
        Task<bool> DeleteCardAsync(int cardId);
    }
}
