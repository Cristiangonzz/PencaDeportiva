using AngularApp1.Server.Infraestructure.Dto;
using AutoMapper;

namespace AngularApp1.Server.Domain.Entities
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Equipo, EquipoDTO>(); // Mapeo de Equipo a EquipoDTO
            CreateMap<EquipoDTO, Equipo>(); // Mapeo de Equipo a EquipoDTO

            //CreateMap<Clasificacion, ClasificacionDTO>()
            //    .ForMember(dest => dest.Equipo, opt => opt.MapFrom(src => src.Equipo)); // Mapeo de Clasificacion a ClasificacionDTO, incluyendo los detalles del Equipo
        }
    }
}
