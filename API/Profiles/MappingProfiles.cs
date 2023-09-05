
using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pais, PaisDto>().ReverseMap();
            CreateMap<Departamento, DepartamentoDto>().ReverseMap();

            CreateMap<Pais,PaisxDepaDto>().ReverseMap();
        }
    }
