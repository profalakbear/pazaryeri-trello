using API.Data.Models;
using API.DTOs;
using API.Repositories;
using API.RepositoryContracts;
using API.ServiceContracts;
using API.UoW;
using AutoMapper;

namespace API.Services
{
    public class CardsService : ICardsService
    {
        private readonly ICardsRepository _cardsRepository;
        private readonly IMapper _mapper;

        public CardsService(ICardsRepository cardsRepository, IMapper mapper)
        {
            _cardsRepository = cardsRepository;
            _mapper = mapper;
        }

        public Task<Card?> GetCardAsync(int cardId)
        {
            return _cardsRepository.GetCardAsync(cardId);
        }

        public Task<List<Card>> GetAllCardsAsync()
        {
            return _cardsRepository.GetAllCardsAsync();
        }

        public Task<List<Card>> GetCardsByListAsync(int listId)
        {
            return _cardsRepository.GetCardsByListAsync(listId);
        }

        public async Task<Card> AddCardAsync(CardDTO card)
        {
            var cardModel = _mapper.Map<Card>(card);
            var result = await _cardsRepository.AddCardAsync(cardModel);
            return _mapper.Map<Card>(result);
        }

        public Task<Card?> UpdateCardAsync(Card card)
        {
            return _cardsRepository.UpdateCardAsync(card);
        }

        public Task<bool> DeleteCardAsync(int cardId)
        {
            return _cardsRepository.DeleteCardAsync(cardId);
        }
    }
}
