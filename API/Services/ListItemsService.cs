using API.Data.Models;
using API.DTOs;
using API.Repositories;
using API.RepositoryContracts;
using API.ServiceContracts;
using AutoMapper;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class ListItemsService : IListItemsService
    {
        private readonly IListItemsRepository _listItemsRepository;
        private readonly IMapper _mapper;

        public ListItemsService(IListItemsRepository listItemsRepository, IMapper mapper)
        {
            _listItemsRepository = listItemsRepository;
            _mapper = mapper;
        }

        public async Task<List<ListDTO>> GetAllListItemsAsync()
        {
            var lists = _listItemsRepository.GetAllListItemsAsync();
            return _mapper.Map<List<ListDTO>>(lists);
        }

        public async Task<List<ListItem>> GetListItemsByUserAsync(int userId)
        {
            var lists = await _listItemsRepository.GetListItemsByUserAsync(userId);
            return lists;
        }

        public async Task<ListDTO?> GetListItemAsync(int listItemId)
        {
            var list = _listItemsRepository.GetListItemAsync(listItemId);
            return _mapper.Map<ListDTO>(list);
        }

        public async Task<ListDTO> AddListItemAsync(ListDTO listItem)
        {
            var listModel = _mapper.Map<ListItem>(listItem);
            var result = await _listItemsRepository.AddListItemAsync(listModel);
            return _mapper.Map<ListDTO>(result);
        }

        public Task<ListDTO?> UpdateListItemAsync(ListDTO listItem)
        {
            return null;
        }

        public Task<bool> DeleteListItemAsync(int listItemId)
        {
            return _listItemsRepository.DeleteListItemAsync(listItemId);
        }
    }
}
