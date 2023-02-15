using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using VentasServicios.Modelo;
using VentasServicios.Persistencia;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace VentasServicios.Aplicacion
{
    public class ConsultaFiltro
    {
        //Clase autor unico, es aparte
        //Hereda un Ireques(interfaz) recibe Autor Dto, el controlado recibira AutorDto
        public class VentaUnico : IRequest<VentaDto>
        {
            //esta llave es escencial para otros microcervicios
            public string VentaGuid { get; set; }
        }

        //Clase que manejar las peticiones de Autor unico, Pasa AutorDto y regresa AutorUnico
        public class Manejador : IRequestHandler<VentaUnico, VentaDto>
        {
            //mandas llamar contexto para dto
            private readonly ContextoVenta _context;
            //mapeas dto
            private readonly IMapper _mapper;
            //CDI inyectando la clase contexto autor y mapper
            //crear el objeto
            public Manejador(ContextoVenta context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }
            //Medofo Hadler te pide lo que vas a manejar
            //Autor unico y cancelar y devolver la operacion
            public async Task<VentaDto> Handle(VentaUnico request, CancellationToken cancellationToken)
            {
                //Solo puede tener un solo metodo
                //que sea igual que el que venga a la peticion
                var venta = await _context.Ventas
                    .Where(p => p.VentaTiendaGuid == request.VentaGuid).FirstOrDefaultAsync();

                // si el autor es nulo regresa la excepcion
                if (venta == null)
                {
                    throw new Exception("No se entro la venta");
                }

                //mapper convierte aurot libro a autor dto, por que recibio autorLibro
                var autorDto = _mapper.Map<VentaTienda, VentaDto>(venta);
                return autorDto;
            }

        }
    }
}
