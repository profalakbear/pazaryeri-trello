using API.Data.Models;

namespace API.RepositoryContracts
{
    public interface ICardsRepository
    {
        Task<Card?> GetCardAsync(int cardId);
        Task<List<Card>> GetAllCardsAsync();
        Task<List<Card>> GetCardsByListAsync(int listId);
        Task<Card> AddCardAsync(Card card);
        Task<Card?> UpdateCardAsync(Card card);
        Task<bool> DeleteCardAsync(int cardId);
    }
}
