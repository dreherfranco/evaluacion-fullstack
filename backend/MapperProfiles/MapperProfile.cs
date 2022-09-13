using AutoMapper;
using backend.DTOs.Client;
using backend.Models;

namespace backend.MapperProfiles
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Client, ClientDTO>()
                .ReverseMap();
            CreateMap<ClientCreateDTO, Client>();
            CreateMap<ClientUpdateDTO, Client>();

        }
    }
}
