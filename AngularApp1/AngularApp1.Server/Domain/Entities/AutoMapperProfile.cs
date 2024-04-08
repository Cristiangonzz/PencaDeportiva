using AngularApp1.Server.Infraestructure.Dto;
using AutoMapper;

namespace AngularApp1.Server.Domain.Entities
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Equipo, EquipoDTO>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.activo));// Mapeo de Equipo a EquipoDTO
            CreateMap<EquipoDTO, Equipo>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.activo));// Mapeo de Equipo a EquipoDTO
        }
    }
}
