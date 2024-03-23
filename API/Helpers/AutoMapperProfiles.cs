using API.Data.Models;
using API.DTOs;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserDTO, User>().ReverseMap();

            CreateMap<ListDTO, ListItem>();
            CreateMap<ListItem, ListDTO>();

            CreateMap<CardDTO, Card>();
            CreateMap<Card, CardDTO>();
        }
    }
}
