
using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pais, PaisDto>().ReverseMap();
        }
    }