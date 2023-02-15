using AutoMapper;
using VentasServicios.Modelo;

namespace VentasServicios.Aplicacion
{
    public class MappingProfile : Profile
    {
        //crea un mapa entre autor libro a autodtio
        public MappingProfile()
        {
            CreateMap<VentaTienda, VentaDto>();
        }
    }
}